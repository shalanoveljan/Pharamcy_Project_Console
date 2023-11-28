using Pharamcy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Service.Interfaces
{
    public interface IAccountService
    {
        void Login();
        void Register(Employe employe);
    }
}
