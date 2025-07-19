using MovieManage.Models;
using MovieManage.Repository.Interfaces;

namespace MovieManage.Repository.Implementation
{
    public class MovieRepository : IMovieRepostory
    {

        private readonly UserMovieDbContext _context;

        public MovieRepository(UserMovieDbContext context)
        {
            _context = context;
        }

        public void Add(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public List<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(m => m.MovieId == id);
        }

        public void UpdateMovie(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }

        public bool DeleteMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);
            if (movie == null)
            {
                return false;
                throw new ArgumentException("Movie not found", nameof(id));
            }
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return true;
        }
    }
}
