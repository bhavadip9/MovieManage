using MovieManage.Models;

namespace MovieManage.Repository.Interfaces
{
    public interface ILoginRepository
    {
        User GetUserByEmail(string email);

        User AddUser(User user);
        bool IsUserExists(string email);
    }
}
