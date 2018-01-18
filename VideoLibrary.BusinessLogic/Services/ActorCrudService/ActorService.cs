using System.Collections.Generic;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities.Models.Model;
using VideoLibrary.BusinessLogic.Repositories.ActorRepository;

namespace VideoLibrary.BusinessLogic.Services.ActorCrudService
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;

        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public async Task<List<Actor>> GetActors()
        {
            
            return await _actorRepository.GetAll();
        }

        public async Task<List<Actor>> GetActors(Gender gender)
        {
          
            return await _actorRepository.GetAll(gender);
        }


        public async Task SaveActor(Actor model)
        {
            await _actorRepository.InsertAsync(model);
        }
    }
}
