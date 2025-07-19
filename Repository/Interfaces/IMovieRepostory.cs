using MovieManage.Models;

namespace MovieManage.Repository.Interfaces
{
    public interface IMovieRepostory
    {

        void Add(Movie movie);

        List<Movie> GetAllMovies();
        Movie GetMovieById(int id);

        void UpdateMovie(Movie movie);

        bool DeleteMovie(int id);
    }
}
