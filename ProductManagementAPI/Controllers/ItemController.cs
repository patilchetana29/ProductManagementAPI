using CRNproduct_management.DTO;
using CRNproduct_management.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _service;

        public ItemController(IItemService service)
        {
            _service = service;
        }

        // GET: api/Item
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        // GET: api/Item/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // POST: api/Item
        [HttpPost]
        public async Task<IActionResult> Create(ItemCreateDTO dto)
        {
            var item = await _service.CreateAsync(dto);
            return Ok(item);
        }

        // PUT: api/Item/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ItemUpdateDTO dto)
        {
            var item = await _service.UpdateAsync(id, dto);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // DELETE: api/Item/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result)
                return NotFound();

            return Ok("Item deleted successfully");

        }
    }
}
