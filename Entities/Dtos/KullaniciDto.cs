using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.Dtos
{
    public class KullaniciDto : IDto
    {
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
