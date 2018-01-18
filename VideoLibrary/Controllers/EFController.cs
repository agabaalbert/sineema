using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using VideoLibrary.BusinessEntities;
using VideoLibrary.BusinessEntities.Models.Model;
using VideoLibrary.BusinessLogic.Repositories.MovieRepository;

namespace VideoLibrary.Controllers
{
    public class EFController : Controller
    {
        private readonly LibraryContext _db = new LibraryContext();
        private readonly IMovieRepository _movieRepository;
        public EFController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // GET: EF
        public ActionResult Index()
        {
            // ReSharper disable once JoinDeclarationAndInitializer
            List<Movie> movies;
/*

            #region Loading related entities
            
            // Lazy loading
            movies = _db.Movies.ToList(); // First get all the movies
            foreach (var mov in movies)
            {
                var actor = mov.Actor; // Database query is executed every time this line is hit
                actor = _db.Actors.Find(mov.LeadActorId); // This is unacceptable :)
            }

            // Eager loading
            movies = _db.Movies.Include(m => m.Actor).ToList(); // All data loaded from database

            #endregion

            #region Minimise the Data Requested
            // Dont do this:
            movies = _db.Movies.Include(q => q.Actor).ToList(); // Do you really need all the columns?

            // Do this instead
            movies = _db.Movies.Include(q => q.Actor).Select(m => new Movie
            {
                Id = m.Id,
                Title = m.Title,
                Actor = new Actor
                {
                    Id = m.Actor.Id,
                    Name = m.Actor.Name
                }
            }).ToList();
            #endregion

            #region Do Not Count After Query Execution

            int count = 0;
            count = _db.Movies.Where(m => m.IsActive).ToList().Count; // returns all matching employees and then executes a count
            count = _db.Movies.Count(m => m.IsActive); //only executes a SQL COUNT

            #endregion

            #region Filter Before ToList()

            var top50Movies = _db.Movies.ToList().Where(m => m.IsActive && m.Duration > 1).Take(50); // ToList() executed too early
            top50Movies = _db.Movies.Where(m => m.IsActive && m.Duration > 1).Take(50).ToList(); // ToList() executed last

            #endregion

            #region Don’t Load Entities To Delete Them

            // Executes a second hit to the database
            var movie = _db.Movies.Find(2);
            if (movie != null)
            {
                _db.Movies.Remove(movie);
                _db.SaveChangesAsync();
            }

            // Executes a single hit to the database
            movie = new Movie { Id = 2 };
            _db.Movies.Attach(movie);
            _db.Movies.Remove(movie);
            _db.SaveChanges();

            #endregion

            #region Query In-Memory Entities First

            movie = _db.Movies.FirstOrDefault(m => m.Id == 2); // Always queries the database
            movie = _db.Movies.Find(2); // Queries the cache first. If entry is not found, then it goes to the database.

            #endregion

            #region Profile Generated SQL

            var moviesQuery = _db.Movies.Include(m => m.Actor).ToString();
            // Raw SQL should be
            // select * from movies m join actors a on m.actorId = a.id;

            #endregion

            #region Don’t Rely on Entity Framework Exclusively For Data Access

            movies = _db.Database.SqlQuery<Movie>("select * from movies m join actors a on m.actorId = a.id").ToList();

            #endregion
*/

            return View();
        }
    }
}