using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Revision.Data
{
    public class Parents_Info
    {
        [Key]
        public int Parents_Id { get; set; }
        public Int64 Parents_Phone { get; set; }
        public string Parents_Address { get; set; }
        public string Parents_Name { get; set; }

    }
}
