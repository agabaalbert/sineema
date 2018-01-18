using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VideoLibrary.BusinessEntities.Models.Model;
using VideoLibrary.BusinessLogic.Repositories.MovieActorRepository;
using VideoLibrary.BusinessLogic.Services.ActorCrudService;

namespace VideoLibrary.Controllers
{
    public class MovieActorController : Controller
    {
        private readonly IActorService _actorService;
        private readonly IMovieActorRepository _movieActorRepository;

        public MovieActorController(IActorService actorService, IMovieActorRepository movieActorRepository)
        {
            _actorService = actorService;
            _movieActorRepository = movieActorRepository;
        }
        // GET: MovieActor
        public ActionResult Index(int id)
        {
            var movieActors = Task.Run(() => _movieActorRepository.ActorsForMovies(id)).Result;
            return View(movieActors);
        }

        public async Task<ActionResult> AddActorOnMovie(int id)
        {
            
            var movieActor = new MovieActor()
            {
                MovieId =  id
            };

            var actors = (await _actorService.GetActors()).Select(x => new SelectListItem()
            {
                Text = x.Name, Value = x.Id.ToString()
            }).ToList();
            ViewBag.ActorOptions = actors;

            return View(movieActor);
        }

        [HttpPost]
        public async Task<ActionResult> AddActorOnMovie(MovieActor model)
        {
            if (ModelState.IsValid)
            {
                await _movieActorRepository.AddMovieActor(model);
                return RedirectToAction("Details", "Movies");
            }
            ModelState.AddModelError("", "Could not save changes, something went wrong.");
            return View(model);
        } 
    }
}