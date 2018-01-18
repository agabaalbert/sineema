using System.Collections.Generic;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Services.ClientCrudService
{
    public interface IClientCrudService
    {
        List<Client> GetAllClients();

        Client GetClient(long clientId);
    }
}