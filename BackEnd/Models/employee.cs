using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//sql table
/*-- 
CREATE TABLE employees(
     employee_id SERIAL PRIMARY KEY,
     name VARCHAR(50),
     email VARCHAR(50),
     phone VARCHAR(50)
 );*/

namespace CRM
{

     public class Employee
    {
        [Key]
        public int employee_id { get; set; }

        public string name { get; set; }
        public string email { get; set; }
         public string phone { get; set; }




         
       


    }




}