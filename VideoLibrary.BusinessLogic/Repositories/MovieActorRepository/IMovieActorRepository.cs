using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Repositories.MovieActorRepository
{
    public interface IMovieActorRepository
    {
        Task AddMovieActor(MovieActor movieActor);

        Task<List<MovieActor>> ActorsForMovies(int movieId);
    }
}
