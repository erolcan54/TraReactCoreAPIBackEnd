using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Helper.Security.JWT;
using Business.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IKullaniciService
    {
        Task<IDataResult<Kullanici>> GetByLoginAsync(UserForLoginDto userForLoginDto);
        Task<IDataResult<AccessToken>> CreateAccessTokenAsync(Kullanici kullanici);
    }
}
