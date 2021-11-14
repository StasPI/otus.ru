using Entities;
using EntityFramework;
using Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
   [ApiController]
   [Route("api/customers")]
   public class CustomerController : ControllerBase
   {
      private readonly DatabaseContext _context;
      private readonly ILogger<CustomerController> _logger;

      public CustomerController(DatabaseContext context, ILogger<CustomerController> logger)
      {
         _context = context;
         _logger = logger;
      }

      [HttpGet("{id:long}")]
      public async Task<ActionResult<Customer>> Get([FromRoute] long id)
      {
         Repository<Customer, long> customerGet = new Repository<Customer, long>(_context);
         Customer cGet = await customerGet.GetAsync(id);
         if (cGet != null)
         {
            return Ok(cGet);
         }
         else
         {
            return NotFound();
         }
      }

      [HttpPost("")]
      public async Task<ActionResult<Customer>> Post([FromBody] Customer customerPost)
      {
         Repository<Customer, long> customerCheck = new Repository<Customer, long>(_context);
         Customer cCheck = await customerCheck.GetAsync(customerPost.Id);
         if (cCheck == null)
         {
            await _context.AddAsync(customerPost);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Post), new { id = customerPost.Id }, customerPost);
         }
         else
         {
            return Conflict();
         }
      }
   }
}