using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.DTO;
using OrderManagement.Application.Interfaces;
using OrderManagement.Application.Services;
using OrderManagement.Domain.Entities;

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductRepository iProductRepository;

        public ProductController(IProductRepository iProRepo)
        {
            this.iProductRepository = iProRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetAll()
        {
            return Ok(iProductRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product request)
        {
            if (request == null) 
            {
                return BadRequest("Product Data is Empty");
            }
            iProductRepository.Add(request);
            return Ok(request);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetById(int id)
        {
            return Ok(iProductRepository.GetById(id));
        }
    }
    public record CreateProductRequest(string Name, decimal Price);
}
