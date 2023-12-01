using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace NewProjectWpf
{
    public class db:DbContext
    {
        public db() : base("Constr") { }
        public DbSet<human>  humen { get; set; }
       
    }
}
