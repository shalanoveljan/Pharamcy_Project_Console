using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Core.Models
{
    public class RoleType:BaseModel
    {
        public string RoleName { get; set; }
        public List<Employe> Employes { get; set; }
    }
}
