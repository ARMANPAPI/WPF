using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProjectWpf
{
    public class human
    {
        public int id { get; set; }

        public string Name { get; set; }
      //  [Column(TypeName ="datatime2")]
        public string Family { get; set; }

        public int Age { get; set; }
    }
}
