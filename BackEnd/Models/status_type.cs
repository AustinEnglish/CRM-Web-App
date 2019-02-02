using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//sql table
/*-- status types
CREATE TABLE status_types(
     status_id SERIAL PRIMARY KEY,
     type VARCHAR(50)
     
 );*/

namespace CRM
{

     public class Status_Type
    {
        [Key]
        public int status_id { get; set; }

        public string type { get; set; }
       

    }


}