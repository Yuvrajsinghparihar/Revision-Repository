using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Revision.Data
{
    public class Students_Info
    {
        [Key]
        public int Student_Id { get; set; }
        public string Student_Name { get; set; }
        public int Student_Age { get; set; }
    }
}
