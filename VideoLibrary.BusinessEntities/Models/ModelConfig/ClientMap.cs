using System.Data.Entity.ModelConfiguration;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessEntities.Models.ModelConfig
{
    public class ClientMap : EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            Property(p => p.FirstName).IsRequired();
            Property(p => p.LastName).IsRequired();

            Ignore(p => p.Name);
        }
    }
}
