using Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using Entities.Models;
using Entities.DataTransferObjects;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using clothes_manager.Method;
using System.Linq;
using clothes_manager.Action;

namespace clothes_manager.Controllers
{
    [ApiController]
    [Route("clothing")]
    public class ClothingController : ControllerBase
    {
        private ILoggerManager _logger;
        private ApplicationContext _context;
        private IMapper _mapper;
        private IClothingAction _clothingAction;
        public ClothingController(ApplicationContext context, ILoggerManager logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public IClothingAction ClothingAction
        {
            get
            {
                if (_clothingAction == null)
                    _clothingAction = new ClothingAction(_context);
                return _clothingAction;
            }
        }

        [HttpGet("/clothing")]
        public async Task<IActionResult> GetAllClothings()
        {
            try
            {
                var clothings = await ClothingAction.GetAllClothings();

                _logger.LogInfo($"Returned all clothings from database.");
                return Ok(clothings);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllClothings action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "ClothingById")]
        public async Task<IActionResult> GetClothingById(int id)
        {
            try
            {
                var clothing = await ClothingAction.GetClothingById(id);
                if (clothing == null)
                {
                    _logger.LogError($"Clothing with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned clothing with id: {id}");

                    var clothingResult = _mapper.Map<ClothingDto>(clothing);

                    //return Ok("okk");
                    return Ok(clothingResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetClothingById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateClothing([FromBody] ClothingForCreationDto clothing)
        {
            try
            {
                if (clothing is null)
                {
                    _logger.LogError("Clothing object sent from client is null.");
                    return BadRequest("Clothing object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid clothing object sent from client");
                    return BadRequest("Invalid model object");
                }

                var clothingEntity = _mapper.Map<Clothing>(clothing);
                ClothingAction.Create(clothingEntity);
                await _context.SaveChangesAsync();
                var createClothing = _mapper.Map<ClothingDto>(clothingEntity);

                return CreatedAtRoute("ClothingById", new { id = createClothing.Id }, createClothing);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateClothing action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClothing(int id, [FromBody] ClothingForUpdateDto clothing)
        {
            try
            {
                if (clothing is null)
                {
                    _logger.LogError("Clothing object sent from client is null.");
                    return BadRequest("Clothing object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid clothing object sent from client");
                    return BadRequest("Invalid model object");
                }

                var clothingEntity = await ClothingAction.GetClothingById(id);
                if (clothingEntity is null)
                {
                    _logger.LogError($"Clothing with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(clothing, clothingEntity);
                ClothingAction.UpdateClothing(clothingEntity);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateClothing action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClothing(int id)
        {
            try
            {
                var clothing = await ClothingAction.GetClothingById(id);
                if (clothing == null)
                {
                    _logger.LogError($"Clothing with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                ClothingAction.DeleteClothing(clothing);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteClothing action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

