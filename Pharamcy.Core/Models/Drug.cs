using Pharamcy.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Core.Models
{
    public class Drug:BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DrugType DrugType { get; set; }
        public int Count { get; set; }
        public int PurchasePrice { get; set; }
        public int SalePrice { get; set; }
    }
}
