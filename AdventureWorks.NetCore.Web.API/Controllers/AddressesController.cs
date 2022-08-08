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
    public class AddressesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddressesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Addresses
        [HttpGet]
        public  IActionResult GetAll()
        {
          if (_unitOfWork.Address == null)
          {
              return NotFound();
          }
            var res=  _unitOfWork.Address.GetAll();
            return Ok(res);
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Address))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public  ActionResult GetById(int id)
        {
          
            var address =  _unitOfWork.Address.GetById(id);

            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        // PUT: api/Addresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress(int id, Address address)
        {
            if (id != address.AddressId)
            {
                return BadRequest();
            }

            _unitOfWork.Address.Update(address);
            _unitOfWork.Save();           

            return NoContent();
        }

        // POST: api/Addresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
          if (_unitOfWork.Address == null)
          {
              return Problem("No existe la entidad");
          }
            _unitOfWork.Address.Add(address);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetAddress", new { id = address.AddressId }, address);
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            if (_unitOfWork.Address == null)
            {
                return NotFound();
            }
            var address = (Address) _unitOfWork.Address.GetById(id);
            if (address == null)
            {
                return NotFound();
            }

            _unitOfWork.Address.Delete(address);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();        }

       
    }
}
