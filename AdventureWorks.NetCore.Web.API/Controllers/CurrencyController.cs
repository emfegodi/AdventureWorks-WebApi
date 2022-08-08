using Microsoft.AspNetCore.Mvc;
using AdventureWorks.NetCore.Repository.IRepository;
using AdventureWorks.NetCore.Repository.Models;

namespace AdventureWorks.NetCore.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CurrencyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Products
        [HttpGet]
        public IActionResult GetAll()
        {
            if (_unitOfWork.Currency == null)
            {
                return NotFound();
            }
            var res = _unitOfWork.Currency.GetAll();
            return Ok(res);
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Currency))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetById(string id)
        {

            var cur = _unitOfWork.Currency.GetById(id);

            if (cur == null)
            {
                return NotFound();
            }

            return Ok(cur);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCurrency(string id, Currency cur)
        {
            if (id != cur.CurrencyCode)
            {
                return BadRequest();
            }

            _unitOfWork.Currency.Update(cur);
            _unitOfWork.Save();

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Currency>> PostCurrency(Currency cur)
        {
            if (_unitOfWork.Currency == null)
            {
                return Problem("No existe la entidad");
            }
            _unitOfWork.Currency.Add(cur);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = cur.CurrencyCode }, cur);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurrency(string id)
        {
            if (_unitOfWork.Currency == null)
            {
                return NotFound();
            }
            var cur = (Currency)_unitOfWork.Currency.GetById(id).FirstOrDefault();
            if (cur == null)
            {
                return NotFound();
            }

            _unitOfWork.Currency.Delete(cur);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
