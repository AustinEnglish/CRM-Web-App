using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//sql table
/*-- lead type(need a priority type object here and a list of interactions)
CREATE TABLE leads(
     lead_id SERIAL PRIMARY KEY,
     last_contact VARCHAR(50),
     status_id INTEGER REFERENCES status_types(status_id),
     priority_id INTEGER REFERENCES priority_types(priority_id),
     customer_id INTEGER REFERENCES customers(customer_id),
     employee_id INTEGER REFERENCES employees(employee_id)
 );*/

namespace CRM
{

     public class Lead
    {
        [Key]
        public int lead_id { get; set; }

        public DateTime last_contact { get; set; }
       
         [ForeignKey("priority_id")]
        public int priority_id { get; set;}

         [ForeignKey("status_id")]
         public int status_id {get;set;}

          [ForeignKey("customer_id")]
        //[ForeignKey("CustomerForeignKey")]
          public int customer_id {get;set;}

         [ForeignKey("employee_id")]
         public int employee_id {get;set;}



        //reference objects
          public Priority_Type priority_type {get; set;}
          public Status_Type status_type {get; set;}

          public Customer customer {get; set;}
          public Employee employee {get; set;}


 

         
       


    }




}