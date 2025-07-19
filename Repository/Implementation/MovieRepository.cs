

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
            var parameters = new[]
            {
                new SqlParameter("@Title", movie.Title),
                new SqlParameter("@Detail", movie.Detail),
                new SqlParameter("@ReleaseDate", movie.ReleaseDate)
            };

            _context.Database.ExecuteSqlRaw("EXEC AddMovie @Title, @Detail, @ReleaseDate", parameters);
        }

        public List<Movie> GetAllMovies()
        {
            return _context.Movies
                .FromSqlRaw("EXEC GetAllMovies")
                .ToList();
        }

        public Movie GetMovieById(int id)
        {
            var param = new SqlParameter("@MovieId", id);
            return _context.Movies
                .FromSqlRaw("EXEC GetMovieById @MovieId", param)
                .AsEnumerable()
                .FirstOrDefault();
        }

        public void UpdateMovie(Movie movie)
        {
            var parameters = new[]
            {
                new SqlParameter("@MovieId", movie.MovieId),
                new SqlParameter("@Title", movie.Title),
                new SqlParameter("@Detail", movie.Detail),
                new SqlParameter("@ReleaseDate", movie.ReleaseDate)
            };

            _context.Database.ExecuteSqlRaw("EXEC UpdateMovie @MovieId, @Title, @Detail, @ReleaseDate", parameters);
        }

        public bool DeleteMovie(int id)
        {
            var param = new SqlParameter("@MovieId", id);

            var movie = GetMovieById(id);
            if (movie == null)
                return false;

            _context.Database.ExecuteSqlRaw("EXEC DeleteMovie @MovieId", param);
            return true;
        }
    }
}
