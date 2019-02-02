using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//sql table
/*--
CREATE TABLE interactions(
     interaction_id SERIAL PRIMARY KEY,
     comment VARCHAR(255),
     date_time VARCHAR(50),
     duration INT,
     lead_id INTEGER REFERENCES leads(lead_id),
     employee_id INTEGER REFERENCES employees(employee_id)
 );*/

namespace CRM
{

     public class Interaction
    {
        [Key]
        public int interaction_id { get; set; }

        public string comment { get; set; }
        public DateTime date_time { get; set; }

        public int duration { get; set; }
       

         public int lead_id {get;set;}
         [ForeignKey("lead_id")]

        
         public int employee_id {get;set;}
         [ForeignKey("employee_id")]


        //objects
         public Employee employee{get;set;}
         public Lead lead{get;set;}


         

    }




}