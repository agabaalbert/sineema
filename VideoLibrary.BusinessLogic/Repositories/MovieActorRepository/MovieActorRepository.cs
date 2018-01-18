using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Repositories.MovieActorRepository
{
    public class MovieActorRepository : IMovieActorRepository
    {
        public async Task AddMovieActor(MovieActor movieActor)
        {
            using (var db = new LibraryContext())
            {
                db.MovieActors.Add(movieActor);
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<MovieActor>> ActorsForMovies(int movieId)
        {
            using (var db = new LibraryContext())
            {
                return await db.MovieActors.Include(x => x.Actor).Where(x => x.MovieId == movieId).ToListAsync();
            }
        } 
    }
}
