using System.Data.Entity.ModelConfiguration;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessEntities.Models.ModelConfig
{
    public class MovieMap : EntityTypeConfiguration<Movie>
    {
        public MovieMap()
        {
            Property(p => p.Title).IsRequired();
            HasRequired(p => p.Actor).WithMany(p => p.Movies).HasForeignKey(f => f.LeadActorId);
        }
    }
}
