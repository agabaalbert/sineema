namespace VideoLibrary.BusinessEntities.Models.Model
{
    public class AuditTrail : ModelBase
    {
        public string TableName { get; set; }
        public string UserName { get; set; }
        public string Actions { get; set; }
        public string OldData { get; set; }
        public string NewData { get; set; }
        public string ChangedColums { get; set; }
        public string TableIdValue { get; set; }

    }
}
