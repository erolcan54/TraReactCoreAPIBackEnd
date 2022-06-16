using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Helper.Security.JWT;
using Business.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class KullaniciManager:IKullaniciService
    {
        private IKullaniciDal _kullaniciDal;
        private ITokenHelper _tokenHelper;

        public KullaniciManager(IKullaniciDal kullaniciDal, ITokenHelper tokenHelper)
        {
            _kullaniciDal = kullaniciDal;
            _tokenHelper = tokenHelper;
        }

        public async Task<IDataResult<Kullanici>> GetByLoginAsync(UserForLoginDto userForLoginDto)
        {
            var result = await _kullaniciDal.GetAsync(a =>
                a.KullaniciAdi == userForLoginDto.KullaniciAdi && a.Sifre == userForLoginDto.Sifre);
            if (result != null)
                return new SuccessDataResult<Kullanici>(result, "Kullanıcı Bulundu.");
            return new ErrorDataResult<Kullanici>(null, "Kullanıcı Bulunamadı.");
        }

        public async Task<IDataResult<AccessToken>> CreateAccessTokenAsync(Kullanici kullanici)
        {
            var accessToken = _tokenHelper.CreateToken(kullanici);
            return new SuccessDataResult<AccessToken>(accessToken, "Token oluşturuldu.");
        }
    }
}
