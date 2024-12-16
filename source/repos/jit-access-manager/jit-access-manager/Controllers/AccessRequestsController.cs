using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jit_access_manager.Data;
using jit_access_manager.Models;

namespace jit_access_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessRequestsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AccessRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AccessRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccessRequest>>> GetAccessRequests()
        {
            return await _context.AccessRequests.ToListAsync();
        }

        // GET: api/AccessRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccessRequest>> GetAccessRequest(int id)
        {
            var accessRequest = await _context.AccessRequests.FindAsync(id);

            if (accessRequest == null)
            {
                return NotFound();
            }

            return accessRequest;
        }

        // PUT: api/AccessRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccessRequest(int id, AccessRequest accessRequest)
        {
            if (id != accessRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(accessRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccessRequestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AccessRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AccessRequest>> PostAccessRequest(AccessRequest accessRequest)
        {
            _context.AccessRequests.Add(accessRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccessRequest", new { id = accessRequest.Id }, accessRequest);
        }

        // DELETE: api/AccessRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccessRequest(int id)
        {
            var accessRequest = await _context.AccessRequests.FindAsync(id);
            if (accessRequest == null)
            {
                return NotFound();
            }

            _context.AccessRequests.Remove(accessRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccessRequestExists(int id)
        {
            return _context.AccessRequests.Any(e => e.Id == id);
        }
    }
}
