//namespace MovieManage.Service.Implementation
//{
//    public class MovieService
//    {

//    }
//}
using MovieManage.Models;
using MovieManage.Repository.Implementation;
using MovieManage.Repository.Interfaces;
using MovieManage.Service.Interfaces;
using MovieManage.ViewModel;

namespace MovieManage.Service.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepostory _movieRepository;

        public MovieService(IMovieRepostory movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public void AddMovie(MovieViewModel model)
        {
            var entity = new Movie
            {
                Title = model.Title,
                Detail = model.Detail,
                ReleaseDate = model.ReleaseDate
            };

            _movieRepository.Add(entity);
        }

        public void UpdateMovie(MovieViewModel model)
        {
            var entity = new Movie
            {
                MovieId = model.MovieId ?? 0,
                Title = model.Title,
                Detail = model.Detail,
                ReleaseDate = model.ReleaseDate
            };

            _movieRepository.UpdateMovie(entity);
        }

        public MovieViewModel GetMovieById(int id)
        {
            var movie = _movieRepository.GetMovieById(id);
            if (movie == null) return null;

            return new MovieViewModel
            {
                MovieId = movie.MovieId,
                Title = movie.Title,
                Detail = movie.Detail,
                ReleaseDate = movie.ReleaseDate
            };
        }

        public List<MovieViewModel> GetAllMovies()
        {
            return _movieRepository.GetAllMovies()
                .Select(m => new MovieViewModel
                {
                    MovieId = m.MovieId,
                    Title = m.Title,
                    Detail = m.Detail,
                    ReleaseDate = m.ReleaseDate
                }).ToList();
        }

        public bool DeleteMovie(int id)
        {
            return _movieRepository.DeleteMovie(id);
        }
    }
}
