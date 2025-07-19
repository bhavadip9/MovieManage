using MovieManage.ViewModel;

namespace MovieManage.Service.Interfaces
{
    public interface IMovieService
    {
        void AddMovie(MovieViewModel model);

        void UpdateMovie(MovieViewModel model);

        MovieViewModel GetMovieById(int id);

        List<MovieViewModel> GetAllMovies();

        bool DeleteMovie(int id);
    }
}
