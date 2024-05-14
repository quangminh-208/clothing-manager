using System;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace clothes_manager.Controllers
{
    [ApiController]
    [Route("orderitem")]
    public class OrderItemController : ControllerBase
    {
        public ILoggerManager _logger;
        public IRepositoryWrapper _repository;
        public OrderItemController(ILoggerManager logger, IRepositoryWrapper repository) 
        {
            _logger = logger;
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrderItems() 
        {
            try
            {
                var orderItem = await _repository.OrderItem.GetAllOrderItems();
                return Ok(orderItem);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOrderItems action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
