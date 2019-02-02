using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//sql table
/*CREATE TABLE customers(
     customer_id SERIAL PRIMARY KEY,
     name VARCHAR(50),
     email VARCHAR(50),
     phone VARCHAR(50),
     age INT,
     detail_id INTEGER REFERENCES details(detail_id)
 ); */

namespace CRM
{

     public class Customer
    {
        [Key]
        public int customer_id { get; set; }

        public string name { get; set; }
        public string email { get; set; }
         public string phone { get; set; }

         public int age { get; set; }
         
        [ForeignKey("detail_id")]
        public int detail_id { get; set;}
         


         //objects
         public Detail detail {get;set;}

        

         
       


    }




}