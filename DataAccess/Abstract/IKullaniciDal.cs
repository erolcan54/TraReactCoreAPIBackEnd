using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Respository;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IKullaniciDal:IEntityRepository<Kullanici>
    {
    }
}
