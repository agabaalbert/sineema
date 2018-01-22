using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLibrary.BusinessEntities.Models.Model
{
    public class SystemUser : ModelBase
    {
        /*
        THID MODEL CLASS WILL DEPICT A USER ENTITY. 
        GIVEN ENOUGH TIME WE COULD ALSO MODIFY IT FURTHER TO ADD A ROLEID PROPERTY THAT ACTS AS A FOREIGN KEY IN THE 
        USERROLES TABLE THAT WILL PROVIDE ROLES FOR SYSTEM USERS
        */

        public string UserName { get; set; }
        public string FullName { get; set; }
        private string _password;
        public string Password { get; set; }


        //THE PROPERTY BELOW COULD BE ADDED TO LINK TO THE ROLES TABLE/ENTITY & FOR THE USER'S ROLES IN TEH SYSTEM e.g. ADMINISTRATOR, NORMAL USER, etc. THIS REQUIRES ADDING A ROLES TABLE
        //public virtual ICollection<Movie> Roles { get; set; }

        public static string EncryptPwd(string plainPass)
        {
            //simple password encryption using SHA256 Algorithm
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(plainPass);
            byte[] hash = sha256.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }

    }
}


