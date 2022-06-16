using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Utilities.Results;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        private IKullaniciService _kullaniciService;

        public KullaniciController(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            KullaniciDto kullaniciDto = new KullaniciDto();
            var userToLogin = _kullaniciService.GetByLoginAsync(userForLoginDto);
            if (!userToLogin.Result.Success)
            {
                return BadRequest(userToLogin.Result.Message);
            }

            var result = await _kullaniciService.CreateAccessTokenAsync(userToLogin.Result.Data);
            if (result.Success)
            {
                kullaniciDto.Id = userToLogin.Result.Data.Id;
                kullaniciDto.Soyad = userToLogin.Result.Data.Soyad;
                kullaniciDto.Ad = userToLogin.Result.Data.Ad;
                kullaniciDto.KullaniciAdi = userToLogin.Result.Data.KullaniciAdi;
                kullaniciDto.Expiration = result.Data.Expiration;
                kullaniciDto.Token = result.Data.Token;
                
                return Ok(kullaniciDto);
            }
            return BadRequest(userToLogin.Result.Message);
        }
    }
}
