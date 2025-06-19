using Desafio_Final_Arquitetura_de_Software.Models.Entities;
using Desafio_Final_Arquitetura_de_Software.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Final_Arquitetura_de_Software.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsService _service;

        public ProductsController(ProductsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetAll()
        {
            var products = await _service.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("ByName")]
        public async Task<ActionResult<Products>> GetAllByName(string name)
        {
            var products = await _service.GetAllByNameAsync(name);
            if (products == null || products.Count() <= 0) return NotFound();
            return Ok(products);
        }

        [HttpGet("Count")]
        public async Task<ActionResult<Products>> GetCount()
        {
            var count = await _service.CountAllAsync();
            return Ok(count);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetById(int id)
        {
            var products = await _service.GetByIdAsync(id);
            if (products == null) return NotFound();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Products products)
        {
            await _service.CreateAsync(products);
            return CreatedAtAction(nameof(GetById), new { id = products.Id }, products);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Products products)
        {
            if (id != products.Id) return BadRequest();
            await _service.UpdateAsync(products);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
