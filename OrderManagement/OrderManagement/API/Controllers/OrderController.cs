using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.DTO;
using OrderManagement.Application.Interfaces;
using OrderManagement.Application.Services;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Repositories;

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderRepository iOrderRepository;

        public OrderController(IOrderRepository iOrdRepo)
        {
            iOrderRepository = iOrdRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(iOrderRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody] Order request)
        {
            if (request == null)
            {
                return BadRequest("Order Data is Empty");
            }
            iOrderRepository.Add(request);
            return Ok(request);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(iOrderRepository.GetById(id));
        }

      
    }
}
