using crud.Models;

namespace crud.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> getAllUsers();
        Task<User> getById(int id);
        Task<User> addUser(User user);
        Task<bool> removeUser(int id);
        Task<User> updateUser(User user, int id);
    }
}
