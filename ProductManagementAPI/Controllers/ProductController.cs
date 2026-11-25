using CRNproduct.Domain;
using CRNproduct_management.DTO;
using Microsoft.AspNetCore.Mvc;
using CRNproduct_management.Interface;
using Microsoft.AspNetCore.Authorization;

namespace ProductManagementAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllAsync();
            return Ok(products);
        }

        // GET: api/Product/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateDto dto)
        {
            var product = await _service.CreateAsync(dto);
            return Ok(product);
        }

        // PUT: api/Product/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductUpdateDto dto)
        {
            var product = await _service.UpdateAsync(id, dto);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // DELETE: api/Product/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _service.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            await _service.DeleteAsync(id);

            return Ok("Product deleted successfully");
        }



    }
}
