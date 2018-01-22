using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using VideoLibrary.BusinessEntities;
using VideoLibrary.BusinessEntities.Models.Model;


namespace VideoLibrary.Controllers
{
    public class loginController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: login
        public ActionResult Index()
        {
			Session.Abandon(); //kill any active session prior to logging in
            return View();
        }

        // POST: login
        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            //Session.Abandon(); //kill any active session prior to logging in

            //get a user by the supplied username
            //if this user exists, compare his password with the supplied password
            //if above is true, then allow him to view dashboard, else display "invalid username or password" message

            //////List<SystemUser> usersList = db.SystemUsers.ToList();
            //////var systemUser = from sysUser in usersList where sysUser.UserName == username && sysUser.Password == SystemUser.EncryptPwd(password) select sysUser;

            var systemUser = (from sysUser in db.SystemUsers.ToList() where sysUser.UserName.ToUpper() == username.ToUpper() && sysUser.Password == SystemUser.EncryptPwd(password) select sysUser).ToList();

            if (systemUser != null && systemUser.Count>0)
            {
                Session["LoggedInUser"] = (SystemUser)systemUser.ToList()[0]; //THE RETREIVED SYSTEMUSER OBJECT IS STORED IN A SESSION

                return RedirectToAction("Index", "Home");
            }

			ViewBag.AuthenticationMsg = "Login failed, either your username or password is incorrect";

			return View();
        }
    }
}