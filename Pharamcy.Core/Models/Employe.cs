using Pharamcy.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Core.Models
{
    public class Employe : BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Salary { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public int RoleTypeId { get; set; }
        public RoleType? Role { get; set; }
        public List<Pharamcy>? pharamcies { get; set; }
        //public int PharamcyId { get; set; }

        //public Pharamcy Pharamcy { get; set; }
    }
}
