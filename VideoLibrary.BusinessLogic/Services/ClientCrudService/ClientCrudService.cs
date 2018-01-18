using System.Collections.Generic;
using VideoLibrary.BusinessEntities.Models.Model;
using VideoLibrary.BusinessLogic.Repositories.ClientRepository;

namespace VideoLibrary.BusinessLogic.Services.ClientCrudService
{
    public class ClientCrudService : IClientCrudService
    {
        private readonly IClientRepository _clientRepository;

        public ClientCrudService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public List<Client> GetAllClients()
        {
            return _clientRepository.GetAll();
        }

        public Client GetClient(long clientId)
        {
            return _clientRepository.GetClient(clientId);
        }
    }
}