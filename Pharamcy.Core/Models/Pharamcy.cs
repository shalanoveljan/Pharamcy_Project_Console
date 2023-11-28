using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Core.Models
{
    public class Pharamcy:BaseModel
    {
        public string Name { get; set; }
        public float MinSalary { get; set; } = 300;
        public float Budget { get; set; } = 1000;
        public string Location { get; set; }

        public int EmployeId { get; set; }
        public Employe Employe { get; set; }


        //public List<Employe> employes { get; set; }

    }
}
