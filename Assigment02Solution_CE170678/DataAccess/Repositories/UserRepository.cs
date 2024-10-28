using BusinessObject;
using DataAccess.DAOs;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void RegisterUser(User user)
        => UserDAO.RegisterUser(user);

        public string Login(string email, string password)
        => UserDAO.Login(email, password);

        public List<User> GetAllUsers()
        => UserDAO.GetUsers();

        public User GetUserById(int id)
        => UserDAO.GetUserById(id);

        public void UpdateUser(int id, User user)
        => UserDAO.UpdateUser(id, user);

        public void DeleteUser(int id)
        => UserDAO.DeleteUser(id);
    }
}
