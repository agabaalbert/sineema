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
	public class SystemUsersControllerTest
	{
		[TestMethod]
		public void index()
		{
			//This tests displaying of the index view.

			//Arrange
			SystemUsersController sysuser = new SystemUsersController();

			//Act
			ViewResult result = sysuser.Index() as ViewResult;

			//Assert
			Assert.IsNull(result);
		}

		[TestMethod]
		public void Details()
		{
			//This tests the Details() method & tries to test retrieving a systemuser details. use system user with id = 1

			//Arrange
			SystemUsersController sysuser = new SystemUsersController();

			//Act
			ViewResult result = sysuser.Details(1) as ViewResult;

			//Assert
			Assert.IsNotNull(result);
		}

		
	}
}
