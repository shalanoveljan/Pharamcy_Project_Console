using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Core.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
