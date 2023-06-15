using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Enciription
{
    public class SecurityKeyHelper
    {

        //bu kod bir güvenlik anahtarı oluşturur bu kod, verilen metin tabanlı güvenlik anahtarını
        //bir simetrik şifreleme anahtarı olarak kullanılan SymmetricSecurityKey nesnesine dönüştürür ve bu nesneyi geri döndürür.
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            //Encoding karakter kodlaması sağlayan bir sınıfdır
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
