using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//sql table
/*
CREATE TABLE priority_types(
     priority_id SERIAL PRIMARY KEY,
     type VARCHAR(50)
     
 );*/

namespace CRM
{

     public class Priority_Type
    {
        [Key]
        public int priority_id { get; set; }

        public string type { get; set; }
        

    }


}