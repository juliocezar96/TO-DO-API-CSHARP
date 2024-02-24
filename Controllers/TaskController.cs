using crud.Models;
using crud.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

using Task = crud.Models.Task;

namespace crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {

            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Task>>> getAllTasks()
        {
            List<Task> tasks = await _taskRepository.getAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Task>> getTaskById(int id)
        {
            Task task = await _taskRepository.getById(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<Task>> create([FromBody] Task task)
        {
            Task taskResponse = await _taskRepository.addTask(task);
            return Ok(taskResponse);

        }

        [HttpPut]
        public async Task<ActionResult<Task>> update([FromBody] Task task, int id)
        {
            task.Id = id;
            Task taskResponse = await _taskRepository.updateTask(task, id);
            return Ok(taskResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Task>> delete(int id)
        {
            Boolean remove = await _taskRepository.removeTask(id);
            return Ok(remove);
        }


    }
}
