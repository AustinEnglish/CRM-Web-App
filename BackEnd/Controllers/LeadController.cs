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
    [Route("api/leads")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private CrmContext _context;
        public LeadsController(CrmContext context)
        {
            _context = context;
        
        }


        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            if(_context.leads.ToList().Count == 0)
            {
                return NotFound();
            }
            
            return Ok(_context.leads.Include(l => l.customer.detail).Include(l => l.employee).Include(l => l.status_type).Include(l => l.priority_type).ToList());
        }

        //GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Lead lead= _context.leads.Include(l => l.customer.detail).Include(l => l.employee).Include(l => l.status_type).Include(l => l.priority_type).FirstOrDefault(l=>l.lead_id == id);

            if(lead == null)
            {
                return NotFound();
            }
            
                return Ok(lead);
        }

         // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Lead lead)
        {
            if(lead == null)
            {
                return BadRequest();
            }

                //add customer

                //need to add a new detail to customer
                 _context.details.Add(lead.customer.detail);
                lead.customer.detail_id =  _context.details.Count();
                _context.customers.Add(lead.customer);
                lead.customer_id = _context.customers.Count();
        
            
                //add status type
                Status_Type status = new Status_Type();
                status.type = "In progress";
                 _context.status_types.Add(status);
                 lead.status_id =  _context.status_types.Count();

                 //add priority type
                 _context.priority_types.Add(lead.priority_type);
                 lead.status_id =  _context.priority_types.Count();
                                           

                //hook up random employee to lead
                 Random rnd = new Random();
                lead.employee_id = rnd.Next(1, _context.employees.Count()+1);
                

                //get date
                string today =   
                System.DateTime.Now.Year.ToString() + "-" +
                System.DateTime.Now.Month.ToString() + "-" +
                System.DateTime.Now.Day.ToString()  + " " +
                System.DateTime.Now.Hour.ToString() +  ":" +
                System.DateTime.Now.Minute.ToString() + ":" +
                System.DateTime.Now.Second.ToString();

                lead.last_contact = Convert.ToDateTime(today);


                 _context.leads.Add(lead);
                _context.SaveChanges();
                return Ok(_context.leads.Include(l => l.customer.detail).Include(l => l.employee).Include(l => l.status_type).Include(l => l.priority_type).ToList());

                
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Lead lead)
        {
             Lead tempLead = _context.leads.FirstOrDefault(l=> l.lead_id == id);

            if(tempLead == null){return NotFound("Could not find a lead");}
           
                _context.leads.Remove(tempLead);
                _context.Add(lead);
                _context.SaveChanges();
                return Ok(_context.leads.Include(l => l.customer.detail).Include(l => l.employee).Include(l => l.status_type).Include(l => l.priority_type).ToList());
            
            

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Lead tempLead = _context.leads.FirstOrDefault(l=> l.lead_id == id);
            if(tempLead == null)
            {
                return NotFound();
            }
                _context.leads.Remove(tempLead);
                _context.SaveChanges();
              return Ok(_context.leads.Include(l => l.customer.detail).Include(l => l.employee).Include(l => l.status_type).Include(l => l.priority_type).ToList());

             

        }
    }
}
