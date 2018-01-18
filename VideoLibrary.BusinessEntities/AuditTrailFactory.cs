using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessEntities
{
    public class AuditTrailFactory
    {
        private DbContext context;
        //http://www.softcodearticle.com/2013/07/entity-framework-auditing-implementation/
        //http://www.codeproject.com/Articles/34491/Implementing-Audit-Trail-using-Entity-Framework-Pa

        public AuditTrailFactory(DbContext context)
        {
            this.context = context;
        }
        public AuditTrail GetAudit(DbEntityEntry entry)
        {
            var currentcontext = HttpContext.Current;

            

            AuditTrail audit = new AuditTrail();
            audit.UserName = "Current User";
            audit.TableName = GetTableName(entry);
            audit.TableIdValue = GetKeyValue(entry);

            //public string UserName { get; set; }

            //entry is Added 
            if (entry.State == EntityState.Added)
            {
                var newValues = new StringBuilder();
                SetAddedProperties(entry, newValues);
                audit.NewData = newValues.ToString();
                //audit.NewData = GetEntryValueInString(entry, false);
                audit.Actions = AuditActions.I.ToString();
            }
            //entry in deleted
            else if (entry.State == EntityState.Deleted)
            {
                var oldValues = new StringBuilder();
                SetDeletedProperties(entry, oldValues);
                audit.OldData = oldValues.ToString();
                audit.Actions = AuditActions.D.ToString();
            }
            //entry is modified
            else if (entry.State == EntityState.Modified)
            {
                var oldValues = new StringBuilder();
                var newValues = new StringBuilder();
                SetModifiedProperties(entry, oldValues, newValues);
                audit.OldData = oldValues.ToString();
                audit.NewData = newValues.ToString();
                audit.Actions = AuditActions.U.ToString();

                var modifiedProperties = entry.CurrentValues.PropertyNames.Where(propertyName => entry.Property(propertyName).IsModified).ToList();
                var properties = string.Join("||", modifiedProperties.ToList());
                audit.ChangedColums = properties;

            }

            return audit;
        }

        private void SetAddedProperties(DbEntityEntry entry, StringBuilder newData)
        {
            foreach (var propertyName in entry.CurrentValues.PropertyNames)
            {
                var newVal = entry.CurrentValues[propertyName];
                if (newVal != null)
                {
                    newData.AppendFormat("{0}={1} || ", propertyName, newVal);
                }
            }
            if (newData.Length > 0)
                newData = newData.Remove(newData.Length - 3, 3);
        }

        private void SetDeletedProperties(DbEntityEntry entry, StringBuilder oldData)
        {
            DbPropertyValues dbValues = entry.GetDatabaseValues();
            foreach (var propertyName in dbValues.PropertyNames)
            {
                var oldVal = dbValues[propertyName];
                if (oldVal != null)
                {
                    oldData.AppendFormat("{0}={1} || ", propertyName, oldVal);
                }
            }
            if (oldData.Length > 0)
                oldData = oldData.Remove(oldData.Length - 3, 3);
        }

        private void SetModifiedProperties(DbEntityEntry entry, StringBuilder oldData, StringBuilder newData)
        {
            DbPropertyValues dbValues = entry.GetDatabaseValues();
            foreach (var propertyName in entry.OriginalValues.PropertyNames)
            {
                var oldVal = dbValues[propertyName];
                var newVal = entry.CurrentValues[propertyName];
                if (oldVal != null && newVal != null && !Equals(oldVal, newVal))
                {
                    newData.AppendFormat("{0}={1} || ", propertyName, newVal);
                    oldData.AppendFormat("{0}={1} || ", propertyName, oldVal);
                }
            }
            if (oldData.Length > 0)
                oldData = oldData.Remove(oldData.Length - 3, 3);
            if (newData.Length > 0)
                newData = newData.Remove(newData.Length - 3, 3);

        }

        private string GetKeyValue(DbEntityEntry entry)
        {
            var objectStateEntry = ((IObjectContextAdapter)context).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
            string id = "0";
            if (objectStateEntry.EntityKey.EntityKeyValues != null)
                id = objectStateEntry.EntityKey.EntityKeyValues[0].Value.ToString();

            return id;
        }

        private string GetTableName(DbEntityEntry dbEntry)
        {
            TableAttribute tableAttr = dbEntry.Entity.GetType().GetCustomAttributes(typeof(TableAttribute), false).SingleOrDefault() as TableAttribute;
            string tableName = tableAttr != null ? tableAttr.Name : dbEntry.Entity.GetType().Name;
            return tableName;
        }


        private string GetEntryValueInString(DbEntityEntry entry, bool isOrginal)
        {
            if (entry.Entity is EntityObject)
            {
                object target = CloneEntity((EntityObject)entry.Entity);
                foreach (string propName in entry.CurrentValues.PropertyNames)
                {
                    object setterValue = null;
                    if (isOrginal)
                    {
                        //Get orginal value 
                        setterValue = entry.OriginalValues[propName];
                    }
                    else
                    {
                        //Get orginal value 
                        setterValue = entry.CurrentValues[propName];
                    }
                    //Find property to update 
                    PropertyInfo propInfo = target.GetType().GetProperty(propName);
                    //update property with orgibal value 
                    if (setterValue == DBNull.Value)
                    {//
                        setterValue = null;
                    }
                    propInfo.SetValue(target, setterValue, null);
                }//end foreach

                XmlSerializer formatter = new XmlSerializer(target.GetType());
                XDocument document = new XDocument();

                using (XmlWriter xmlWriter = document.CreateWriter())
                {
                    formatter.Serialize(xmlWriter, target);
                }
                return document.Root.ToString();
            }
            return null;
        }

        private EntityObject CloneEntity(EntityObject obj)
        {
            DataContractSerializer dcSer = new DataContractSerializer(obj.GetType());
            MemoryStream memoryStream = new MemoryStream();

            dcSer.WriteObject(memoryStream, obj);
            memoryStream.Position = 0;

            EntityObject newObject = (EntityObject)dcSer.ReadObject(memoryStream);
            return newObject;
        }
    }

    public enum AuditActions
    {
        /// <summary>
        /// Insert
        /// </summary>
        I,
        /// <summary>
        /// Update
        /// </summary>
        U,
        /// <summary>
        /// Delete
        /// </summary>
        D
    }


}
