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
    public class CustomerController : ControllerBase
    {
        ICustomerRepository iCustomerRepository;

        public CustomerController(ICustomerRepository iCusRepo)
		{
            iCustomerRepository = iCusRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(iCustomerRepository.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(iCustomerRepository.GetById(id));
        }

		[HttpPost]
		public IActionResult Create([FromBody] Customer request)
		{
			if (request == null)
			{
				return BadRequest("Customer is Empty");
			}
			iCustomerRepository.Add(request);
			return Ok(request);
		}
	}
}
