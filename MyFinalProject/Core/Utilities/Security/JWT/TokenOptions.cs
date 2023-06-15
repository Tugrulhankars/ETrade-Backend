using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class TokenOptions
    {
        public string Audience { get; set; }//token'in hitap ettiği kitle
        public string Issuer { get; set; }//token'in yayıncısını
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
