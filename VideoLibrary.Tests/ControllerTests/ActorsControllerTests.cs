using Moq;
using NUnit.Framework;
using VideoLibrary.BusinessEntities.Models.Model;
using VideoLibrary.Controllers;

namespace VideoLibrary.Tests.ControllerTests
{
    [TestFixture]
    public class ActorsControllerTests
    {
        private Mock<Client> _mockClient;

        private ActorsController _actorsController;

        [SetUp]
        public void SetUp()
        {
            _mockClient = new Mock<Client>();
            _actorsController = new ActorsController();
        }

        [TearDown]
        public void TearDown()
        {
            _actorsController = null;
        }

        //[Test]
        //public async Task TestsMethod()
        //{
            
        //    var result = await _actorsController.Details(2) as ViewResult;
        //    var client = (Client)result.ViewData.Model;
        //    Assert.AreEqual("Laptop", client.Name);
        //    Assert.AreEqual("Details", result.ViewName);
        //    Assert.IsInstanceOf(typeof(Client), client);
        //}


    }
}
