using crud.Data;
using crud.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

using Task = crud.Models.Task;

namespace crud.Repositories
{
    public class TaskRepository : ITaskRepository
    {

        private readonly TaskSystemDBContext dBContext;

        public TaskRepository(TaskSystemDBContext taskSystemDBContext)
        {

            dBContext = taskSystemDBContext;

        }

        public async Task<List<Task>> getAllTasks()
        {
            return await dBContext.Tasks
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<Task> getById(int id)
        {
            return await dBContext.Tasks
                .Include(x => x.User)
                .FirstOrDefaultAsync(task => task.Id == id);
        }

        public async Task<Task> addTask(Task task)
        {
            await dBContext.Tasks.AddAsync(task);
            await dBContext.SaveChangesAsync();

            return task;
        }

        public async Task<bool> removeTask(int id)
        {
            Task taskId = await getById(id);
            if (taskId == null)
            {
                throw new Exception($"Task with ID: {id} was not found.");
            }

            dBContext.Tasks.Remove(taskId);
            await dBContext.SaveChangesAsync();

            return true;

        }

        public async Task<Task> updateTask(Task task, int id)
        {
            Task taskId = await getById(id);
            if (taskId == null)
            {
                throw new Exception($"Task with ID: {id} was not found.");

            }

            taskId.Name = task.Name;
            taskId.Description = task.Description;
            taskId.Status = task.Status;
            taskId.UserId = task.UserId;

            dBContext.Tasks.Update(taskId);
            await dBContext.SaveChangesAsync();

            return taskId;


        }
    }
}
