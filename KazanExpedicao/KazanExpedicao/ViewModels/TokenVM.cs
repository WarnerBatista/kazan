using System;
using System.Collections.Generic;
using System.Text;

namespace KazanExpedicao.ViewModels
{
    public class TokenVM
    {
        public string Token { get; set; } = "";
        public DateTime DataExpiracaoToken { get; set; }
    }
}
