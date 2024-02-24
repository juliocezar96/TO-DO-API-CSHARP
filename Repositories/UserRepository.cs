using crud.Data;
using crud.Models;
using crud.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace crud.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly TaskSystemDBContext dBContext;

        public UserRepository(TaskSystemDBContext taskSystemDBContext)
        {

            dBContext = taskSystemDBContext;

        }

        public async Task<List<User>> getAllUsers()
        {
            return await dBContext.Users.ToListAsync();
        }

        public async Task<User> getById(int id)
        {
            return await dBContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<User> addUser(User user)
        {
            await dBContext.Users.AddAsync(user);
            await dBContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> removeUser(int id)
        {
            User userId = await getById(id);
            if (userId == null)
            {
                throw new Exception($"User with ID: {id} was not found.");
            }

            dBContext.Users.Remove(userId);
            await dBContext.SaveChangesAsync();

            return true;

        }

        public async Task<User> updateUser(User user, int id)
        {
            User userId = await getById(id);
            if (userId == null)
            {
                throw new Exception($"User with ID: {id} was not found.");

            }

            userId.Name = user.Name;
            userId.Email = user.Email;
            dBContext.Users.Update(userId);
            await dBContext.SaveChangesAsync();

            return userId;


        }
    }
}
