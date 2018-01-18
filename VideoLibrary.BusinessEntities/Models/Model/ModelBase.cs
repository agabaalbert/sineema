using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoLibrary.BusinessEntities.Models.Model
{
    public class ModelBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public bool IsActive
        {
            get { return _isActive ?? true; }
            set { _isActive = value; }
        }

        [UIHint("Date")]
        public DateTime DateAdded
        {
            get { return _dateCreated ?? DateTime.Now; }
            set { _dateCreated = value; }
        }

        public int? AddedBy
        {
            get { return _addedBy ?? 1; }
            set { _addedBy = value; }
        }


        private DateTime? _dateCreated;
        private Boolean? _isActive;
        private int? _addedBy;
    }
}
