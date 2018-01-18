using Moq;
using NUnit.Framework;
using VideoLibrary.BusinessLogic.Repositories.ActorRepository;
using VideoLibrary.BusinessLogic.Services.ActorCrudService;

namespace VideoLibrary.Tests.Services.ActorService
{
    [TestFixture]
    public class ActorServiceTests
    {

        private Mock<IActorRepository> _mockActorRepo;
        private IActorService _actorService;

        [SetUp]
        public void SetUp()
        {
            _mockActorRepo = new Mock<IActorRepository>() { CallBase = true };
            _actorService = new BusinessLogic.Services.ActorCrudService.ActorService(_mockActorRepo.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockActorRepo = null;
            _actorService = null;
        }
    }
}
