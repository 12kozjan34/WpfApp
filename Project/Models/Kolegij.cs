using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Kolegij
    {
        public int IDKolegij { get; set; }
        public string Name { get; set; }
        public Profesor? Profesor { get; set; }
        public List<Student>? Studenti { get; set; }
    }
}
