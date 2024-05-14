using System;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Threading.Tasks;


namespace clothes_manager.Controllers
{
    [ApiController]
    [Route("userorder")]
    public class UserOrderController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public UserOrderController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserOrders()
        {
            try
            {
                var userOrder = await _repository.UserOrder.GetAllUserOrders();
                _logger.LogInfo($"Return all user order from database.");
                return Ok(userOrder);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllUserOrders action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/orderitem")]
        public async Task<IActionResult> GetOrderWithItems(int id)
        {
            try
            {
                var userOrder = await _repository.UserOrder.GetOrderWithItems(id);
                if (userOrder == null)
                {
                    _logger.LogError($"UserOrder with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned UserOrder with id: {id}");

                    var userOrderResult = _mapper.Map<UserOrderDto>(userOrder);

                    //return Ok("okk");
                    return Ok(userOrderResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOrderWithItems action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
