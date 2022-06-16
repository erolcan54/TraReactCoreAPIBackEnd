using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Helper.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(Kullanici kullanici);
    }
}
