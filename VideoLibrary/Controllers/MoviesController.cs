using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using VideoLibrary.BusinessLogic.Services.ActorCrudService;
using VideoLibrary.BusinessLogic.Services.MovieCrudService;
using VideoLibrary.BusinessEntities.Models.Model;
using System.Linq;
using PagedList;
using PagedList.Mvc;

namespace VideoLibrary.Controllers
{
    [RoutePrefix("sineema")]
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IActorService _actorService;
        BusinessEntities.LibraryContext db = new BusinessEntities.LibraryContext();

        public MoviesController(IMovieService movieService, IActorService actorService)
        {
            _movieService = movieService;
            _actorService = actorService;
        }

        // GET: Movies
        [Route("")]
        public async Task<ActionResult> Index(string searchBy, string searchText, int? page, string sortBy)
        {
			//check if a user has no session, then redirect him to login page. Otherwise, proceed to the landing home page/dashboard
			if (Session["LoggedInUser"] == null)
			{
				return RedirectToAction("Index", "Login");
			}

			ViewBag.SortTitleParameter = string.IsNullOrEmpty(sortBy) ? "Title desc" : "";
            ViewBag.SortGenreParameter = sortBy== "Genre" ? "Genre desc" : "Genre";
            ViewBag.SortDurationParameter = sortBy== "Duration" ? "Duration desc" : "Duration";
            ViewBag.SortDateAddedParameter = sortBy == "DateAdded" ? "DateAdded desc" : "DateAdded";
            ViewBag.SortAddedByParameter = sortBy == "AddedBy" ? "AddedBy desc" : "AddedBy";

            var MoviesList = db.Movies.AsQueryable(); 

            if (string.IsNullOrEmpty(searchBy))
            {
                searchBy = string.Empty;
            }
            if (string.IsNullOrEmpty(searchText))
            {
                searchText = string.Empty;
            }

            if (searchBy.ToUpper() == "TITLE")
            {
                /*db.Movies.ToList().Where(x => x.Title == searchText || searchText == null).ToList()*/;
                MoviesList = MoviesList.Where(x => x.Title.ToUpper().StartsWith(searchText.ToUpper()) || searchText == null);

            }
            else if (searchBy.ToUpper() == "GENRE")
            {
                MoviesList = MoviesList.Where(x => x.Genre.ToString().ToUpper().StartsWith(searchText.ToUpper()) || searchText == null);

                //return View(db.Movies.ToList().Where(x => x.Genre.ToString().ToUpper().StartsWith(searchText.ToUpper()) || searchText == null).ToList().ToPagedList(page ?? 1, 15));

            }
            else if (searchBy.ToUpper() == "ADDEDBY")
            {
                MoviesList = MoviesList.Where(x => x.AddedBy == int.Parse(searchText) || searchText == null);

            }
            //else
            //{
            //    return View(db.Movies.ToList().ToPagedList(page ?? 1, 15));
            //}

            switch (sortBy)
            {
                case "Title desc":
                    MoviesList = MoviesList.OrderByDescending(x => x.Title);
                    break;
                case "Genre desc":
                    MoviesList = MoviesList.OrderByDescending(x => x.Genre.ToString());
                    break;
                case "Genre":
                    MoviesList = MoviesList.OrderBy(x => x.Genre.ToString());
                    break;
                case "Duration desc":
                    MoviesList = MoviesList.OrderByDescending(x => x.Duration);
                    break;
                case "Duration":
                    MoviesList = MoviesList.OrderBy(x => x.Duration);
                    break;
                case "DateAdded desc":
                    MoviesList = MoviesList.OrderByDescending(x => x.DateAdded);
                    break;
                case "DateAdded":
                    MoviesList = MoviesList.OrderBy(x => x.DateAdded);
                    break;
                case "AddedBy desc":
                    MoviesList = MoviesList.OrderByDescending(x => x.AddedBy);
                    break;
                case "AddedBy":
                    MoviesList = MoviesList.OrderBy(x => x.AddedBy);
                    break;
                default:
                    MoviesList = MoviesList.OrderBy(x => x.Title);
                    break;
            }

            return View(MoviesList.ToPagedList(page ?? 1, 15));
            
        }

        // GET: Movies/Details/5
        [Route("{id:int}/details")]
        public async Task<ActionResult> Details(int? id)
        {
            return View(await _movieService.GetMovieDetails(id));
        }

        // GET: Movies/Create
        [Route("add")]
        public async Task<ActionResult> Create()
        {
            ViewBag.ActorId = new SelectList(await _actorService.GetActors(), "Id", "Name");
            var actors = await _actorService.GetActors();

            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("add")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Duration,Genre,LeadActorId")] Movie movie)
        {
            if (ModelState.IsValid)
            {

                await _movieService.InsertMovie(movie);



                //await _movieService.InsertMovie(movie);
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        [Route("{id:int}/update")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var movie = await _movieService.GetMovieDetails(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{id:int}/update")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Duration,ActorId,Genre,DateAdded,AddedBy")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _movieService.UpdateMovie(movie);
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Delete/5
        [Route("{id:int}/delete")]
        public async Task<ActionResult> Delete(int? id)
        {
            var movie = await _movieService.GetMovie(id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("{id:int}/confirm/delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _movieService.DeleteMovie(id);

            return RedirectToAction("Index");
        }

    }
}
