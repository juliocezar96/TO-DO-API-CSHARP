using crud.Models;
using crud.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {

            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> getAllUsers()
        {
            List<User> users = await _userRepository.getAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> getUserById(int id)
        {
            User user = await _userRepository.getById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> create([FromBody] User user)
        {
            User userResponse = await _userRepository.addUser(user);
            return Ok(userResponse);

        }

        [HttpPut]
        public async Task<ActionResult<User>> update([FromBody] User user, int id)
        {
            user.Id = id;
            User userResponse = await _userRepository.updateUser(user, id);
            return Ok(userResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> delete(int id)
        {
            Boolean remove = await _userRepository.removeUser(id);
            return Ok(remove);
        }


    }
}
