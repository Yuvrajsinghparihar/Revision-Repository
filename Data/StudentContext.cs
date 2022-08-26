using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Revision.Data
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }

        public DbSet<Students_Info> Students_Info { get; set; }
        public DbSet<Parents_Info> Parents_Info { get; set; }
    }
}
