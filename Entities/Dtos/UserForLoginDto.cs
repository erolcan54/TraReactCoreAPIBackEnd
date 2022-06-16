﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.Dtos
{
    public class UserForLoginDto:IDto
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
    }
}
