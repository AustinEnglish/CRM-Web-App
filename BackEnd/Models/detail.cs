using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//sql table
/*CREATE TABLE details(
     detail_id SERIAL PRIMARY KEY,
     preferred_contact VARCHAR(255)
 );*/

namespace CRM
{

     public class Detail
    {
        [Key]
        public int detail_id { get; set; }

        public string preferred_contact { get; set; }
        

    }


}