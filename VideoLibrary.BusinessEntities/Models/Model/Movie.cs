using System.Collections.Generic;

namespace VideoLibrary.BusinessEntities.Models.Model
{
    public class Movie : ModelBase
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public Genre Genre { get; set; }

        public long LeadActorId { get; set; }

        public Actor Actor { get; set; }

        public ICollection<MovieActor> MovieActors { get; set; }

    }

    public enum Genre
    {
        Christian,
        Tteke,
        Masasi,
        Kinigeria,
        Kiyindi,
        Kinayuganda
    }
}
