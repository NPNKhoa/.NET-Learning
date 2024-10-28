using BusinessObject;
using BusinessObject.DTOs;
using BusinessObject.Mappers;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eBookStoreWebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Lấy danh sách tất cả người dùng
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            if (users == null || users.Count == 0)
            {
                return NotFound("No users found.");
            }
            return Ok(users);
        }

        // Lấy người dùng theo ID
        [HttpGet("{id}")]
        public IActionResult GetUserById([FromRoute] int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            return Ok(user);
        }

        // Đăng ký người dùng mới
        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] CreateUserDto dto)
        {
            var user = dto.ToEntityUser();

            // Kiểm tra xem người dùng đã tồn tại chưa
            var existingUser = _userRepository.GetAllUsers().FirstOrDefault(u => u.email_address == user.email_address);
            if (existingUser != null)
            {
                return BadRequest("User already exists.");
            }

            // Đăng ký người dùng mới
            _userRepository.RegisterUser(user);
            return StatusCode(201, "User registered successfully.");
        }

        // Đăng nhập người dùng và tạo JWT
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUserDto dto)
        {
            var token = _userRepository.Login(dto.email_address, dto.password);
            if (token == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            return Ok(new { Token = token });
        }

        // Cập nhật thông tin người dùng
        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromRoute] int id, [FromBody] CreateUserDto dto)
        {
            var existingUser = _userRepository.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound("User not found.");
            }

            // Cập nhật thông tin người dùng
            var userToUpdate = dto.ToEntityUser();
            _userRepository.UpdateUser(id, userToUpdate);

            return NoContent();
        }

        // Xóa người dùng
        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            var existingUser = _userRepository.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound("User not found.");
            }

            _userRepository.DeleteUser(id);
            return NoContent();
        }
    }
}
