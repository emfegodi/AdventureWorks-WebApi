using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AdventureWorks.NetCore.Repository.IRepository;
using AdventureWorks.NetCore.Repository.Models;
using AdventureWorks.NetCore.Repository;

namespace AdventureWorks.NetCore.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Products
        [HttpGet]
        public  IActionResult GetAll()
        {
          if (_unitOfWork.Product == null)
          {
              return NotFound();
          }
            var res=  _unitOfWork.Product.GetAll();
            return Ok(res);
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public  ActionResult GetById(int id)
        {
          
            var products =  _unitOfWork.Product.GetById(id);

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _unitOfWork.Product.Update(product);
            _unitOfWork.Save();           

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
          if (_unitOfWork.Product == null)
          {
              return Problem("No existe la entidad");
          }
            _unitOfWork.Product.Add(product);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_unitOfWork.Product == null)
            {
                return NotFound();
            }
            var product = (Product) _unitOfWork.Product.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            _unitOfWork.Product.Delete(product);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();        }

       
    }
}
