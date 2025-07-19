using MovieManage.Models;
using MovieManage.Repository.Interfaces;

namespace MovieManage.Repository.Implementation
{
    public class LoginRepository : ILoginRepository
    {
        private readonly UserMovieDbContext _context;

        public LoginRepository(UserMovieDbContext context)
        {
            _context = context;
        }


        public bool IsUserExists(string email)
        {
            try
            {
                return _context.Users.Any(m => m.Email.ToLower() == email.ToLower());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}\n{ex.InnerException?.Message}");
                return false;
            }
        }
        public User GetUserByEmail(string email)
        {
            try
            {
                return _context.Users.FirstOrDefault(m => m.Email.ToLower() == email.ToLower())!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}\n{ex.InnerException?.Message}");
                return new User();
            }
        }

        public User AddUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}\n{ex.InnerException?.Message}");
                return new User();
            }
        }
    }
}
