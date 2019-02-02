using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace CRM
{
    [Route("api/interactions")]
    [ApiController]
    public class InteractionsController : ControllerBase
    {
        private CrmContext _context;
        public InteractionsController(CrmContext context)
        {
            _context = context;
        
        }


        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            if(_context.interactions.ToList().Count == 0)
            {
                return NotFound();
            }
            
            return Ok(_context.interactions.Include(i => i.lead.customer).Include(i => i.lead.priority_type).Include(i => i.lead.status_type).Include(l => l.employee).ToList());
        }

        //GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Interaction interaction= _context.interactions.Include(i => i.lead.customer).Include(i => i.lead.priority_type).Include(i => i.lead.status_type).Include(l => l.employee).FirstOrDefault(i=>i.interaction_id == id);

            if(interaction == null)
            {
                return NotFound();
            }
            
                return Ok(interaction);
        }

         // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Interaction interaction)
        {
            if(interaction == null)
            {
                return BadRequest();
            }
           
                _context.interactions.Add(interaction);
                _context.SaveChanges();
              return Ok(_context.interactions.Include(i => i.lead.customer).Include(i => i.lead.priority_type).Include(i => i.lead.status_type).Include(l => l.employee).ToList());

                
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Interaction interaction)
        {
             Interaction tempInteraction = _context.interactions.FirstOrDefault(i=> i.interaction_id == id);

            if(tempInteraction == null){return NotFound("Could not find a lead");}
           
                _context.interactions.Remove(tempInteraction);
                _context.Add(interaction);
                _context.SaveChanges();
               return Ok(_context.interactions.Include(i => i.lead.customer).Include(i => i.lead.priority_type).Include(i => i.lead.status_type).Include(l => l.employee).ToList());
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Interaction tempInteraction = _context.interactions.FirstOrDefault(i=> i.interaction_id == id);
            if(tempInteraction == null)
            {
                return NotFound();
            }
                _context.interactions.Remove(tempInteraction);
                _context.SaveChanges();
              return Ok(_context.interactions.Include(i => i.lead.customer).Include(i => i.lead.priority_type).Include(i => i.lead.status_type).Include(l => l.employee).ToList());

             

        }
    }
}
