using System.Collections.Generic;
using VideoLibrary.BusinessEntities;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Repositories.ClientRepository
{
    public interface IClientRepository : IRepositoryBase
    {
        List<Client> GetAll();
        Client GetClient(long clientId);
        
    }
}