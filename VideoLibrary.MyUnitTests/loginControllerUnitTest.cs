using System;
using System.Data.Entity;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using VideoLibrary;
using VideoLibrary.Controllers;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VideoLibrary.MyUnitTests
{
	[TestClass]
	public class loginControllerUnitTest
	{
		[TestMethod]
		public void index()
		{
			//This tests the login functionality of the login controller.
			//the index action is passed user credentials

			//Arrange
			loginController lc = new loginController();

			//Act
			ViewResult result = lc.Index("sysUser", "12345") as ViewResult;

			//Assert
			Assert.IsNotNull(result);
		}
		
	}
}
