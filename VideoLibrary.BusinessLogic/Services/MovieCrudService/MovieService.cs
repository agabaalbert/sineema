using System.Collections.Generic;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities.Models.Model;
using VideoLibrary.BusinessLogic.Repositories.MovieRepository;

namespace VideoLibrary.BusinessLogic.Services.MovieCrudService
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public Task<List<Movie>> GetMovies()
        {
            return _movieRepository.GetAll();
        }

        public async Task<Movie> GetMovieDetails(long? id)
        {
            return await _movieRepository.Get(id);
        }

        public async Task<Movie> DeleteMovie(long? id)
        {
            var movie = await _movieRepository.Get(id);

            return await _movieRepository.DeleteAsync(movie);
        }

        public async Task<Movie> GetMovie(long? id)
        {
            return await _movieRepository.Get(id);
        }

        public async Task<Movie> InsertMovie(Movie model)
        {
            return await _movieRepository.InsertAsync(model);
        }

        public async Task<Movie> UpdateMovie(Movie model)
        {
            return await _movieRepository.UpdateAsync(model);
        }
    }
}