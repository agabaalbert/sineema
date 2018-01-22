using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessEntities
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("Name=VideoLibraryContext")
        {
            // If i want to out put the excuted sql to vs output window
            Database.Log = sql => Debug.Write(sql);
        }

        public DbSet<AuditTrail> Audit { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<SystemUser> SystemUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            try
            {
                modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            }
            catch (System.Exception)
            {

            }
            base.OnModelCreating(modelBuilder);
        }

        private AuditTrailFactory _auditFactory;
        private List<AuditTrail> auditList = new List<AuditTrail>();

        public override Task<int> SaveChangesAsync()
        {

            auditList.Clear();
            _auditFactory = new AuditTrailFactory(this);

            var entityList = ChangeTracker.Entries().Where(p =>
            p.State == EntityState.Added ||
            p.State == EntityState.Deleted ||
            p.State == EntityState.Modified ||
            !(p.Entity is AuditTrail) ||
            p.Entity != null);

            foreach (var entity in entityList)
            {
                AuditTrail audit = _auditFactory.GetAudit(entity);
                auditList.Add(audit);
            }

            //var retVal = base.SaveChanges();

            if (auditList.Count > 0)
            {
                auditList.ForEach(p => { Audit.Add(p); });

                //base.SaveChanges();
            }

            return base.SaveChangesAsync();
        }

    }
}
