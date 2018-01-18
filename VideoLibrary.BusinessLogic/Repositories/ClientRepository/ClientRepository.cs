using System.Collections.Generic;
using System.Linq;
using VideoLibrary.BusinessEntities;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Repositories.ClientRepository
{
    public class ClientRepository: RepositoryBase<LibraryContext>, IClientRepository
    {
        public List<Client> GetAll()
        {
            using (var db = new LibraryContext())
            {
                return db.Clients.ToList();
            }
        }

        public Client GetClient(long clientId)
        {
            using (var db = new LibraryContext())
            {
                return db.Clients.FirstOrDefault(q => q.Id == clientId);
            }
        }
    }
}
