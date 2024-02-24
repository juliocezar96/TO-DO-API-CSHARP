using crud.Models;
using Task = crud.Models.Task;

namespace crud.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<Task>> getAllTasks();
        Task<Task> getById(int id);
        Task<Task> addTask(Task task);
        Task<bool> removeTask(int id);
        Task<Task> updateTask(Task task, int id);
    }
}
