using Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using Entities.Models;
using Entities.DataTransferObjects;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace clothes_manager.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private ILoggerManager _logger;
        private ApplicationContext _context;
        private IMapper _mapper;    
        public UserController(ApplicationContext context, ILoggerManager logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("/user")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _context.Set<User>()
                    .AsNoTracking()
                    .ToListAsync();

                _logger.LogInfo($"Returned all users from database.");
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllUsers action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "UserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _context.Set<User>()
                    .AsQueryable()
                    .Where(u => u.Id == id)
                    .FirstOrDefaultAsync();
                if (user == null)
                {
                    _logger.LogError($"User with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned user with id: {id}");

                    var userResult = _mapper.Map<UserDto>(user);

                    //return Ok("okk");
                    return Ok(userResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetUserById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserForCreationDto user)
        {
            try
            {
                if (user is null)
                {
                    _logger.LogError("User object sent from client is null.");
                    return BadRequest("User object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid user object sent from client");
                    return BadRequest("Invalid model object");
                }

                var userEntity = _mapper.Map<User>(user);
                _context.Set<User>().Add(userEntity);
                await _context.SaveChangesAsync();
                var createUser = _mapper.Map<UserDto>(userEntity);

                return CreatedAtRoute("UserById", new { id = createUser.Id }, createUser);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateUser action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserForUpdateDto user)
        {
            try
            {
                if (user is null)
                {
                    _logger.LogError("User object sent from client is null.");
                    return BadRequest("User object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid user object sent from client");
                    return BadRequest("Invalid model object");
                }

                var userEntity = await _context.Set<User>()
                    .AsQueryable()
                    .Where(u => u.Id == id)
                    .FirstOrDefaultAsync();
                if (userEntity is null)
                {
                    _logger.LogError($"User with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(user, userEntity);
                _context.Set<User>().Update(userEntity);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateUser action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _context.Set<User>()
                    .AsQueryable()
                    .Where(u => u.Id == id)
                    .FirstOrDefaultAsync();
                if (user == null)
                {
                    _logger.LogError($"User with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _context.Set<User>().Remove(user);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteUser action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

