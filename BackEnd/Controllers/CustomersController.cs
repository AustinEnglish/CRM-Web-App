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
    [Route("api/Customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private CrmContext _context;
        public CustomerController(CrmContext context)
        {
            _context = context;
        
        }


        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            if(_context.customers.ToList().Count == 0)
            {
                return NotFound();
            }
            
            return Ok(_context.customers.Include(c=>c.detail).ToList());
        }

        //GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Customer customer= _context.customers.Include(c=>c.detail).FirstOrDefault(w=>w.customer_id == id);

            if(customer == null)
            {
                return NotFound();
            }
            
                return Ok(customer);
        }

         // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if(customer == null)
            {
                return BadRequest();
            }

                _context.customers.Add(customer);
                _context.SaveChanges();
               return Ok(_context.customers.Include(c=>c.detail).ToList());

                
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Customer customer)
        {
             Customer tempCustomer = _context.customers.FirstOrDefault(w => w.customer_id == id);

            if(tempCustomer == null){return NotFound("Could not find a tweet");}
           
                _context.customers.Remove(tempCustomer);
                _context.Add(customer);
                _context.SaveChanges();
                return Ok(_context.customers.Include(c=>c.detail).ToList());
            
            

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Customer tempCustomer = _context.customers.FirstOrDefault(w => w.customer_id == id);
            if(tempCustomer == null)
            {
                return NotFound();
            }
                _context.customers.Remove(tempCustomer);
                _context.SaveChanges();
              return Ok(_context.customers.Include(c=>c.detail).ToList());

             

        }
    }
}
