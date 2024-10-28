using BusinessObject;

namespace DataAccess.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        void RegisterUser(User user);
        string Login(string email, string password);
        void UpdateUser(int id, User user);
        void DeleteUser(int id);
    }
}
