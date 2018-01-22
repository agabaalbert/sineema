using System;

namespace VideoLibrary.BusinessEntities.Models.Model
{
    public partial class Client : ModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
    }
}



//using System;
//using System.ComponentModel.DataAnnotations;

//namespace VideoLibrary.BusinessEntities.Models.Model
//{
//    public partial class Client : ModelBase
//    {
//        [Required(ErrorMessage ="{0} is required")]
//        [Display(Name = "First Name")]
//        public string FirstName { get; set; }

//        [Required(ErrorMessage = "{0} is required")]
//        [Display(Name = "Last Name")]
//        public string LastName { get; set; }

//        //public string Name { get; set; }

//        [Display(Name = "Date Of Birth")]
//        public DateTime DateOfBirth { get; set; }

//        public Gender Gender { get; set; }
//    }
//}
