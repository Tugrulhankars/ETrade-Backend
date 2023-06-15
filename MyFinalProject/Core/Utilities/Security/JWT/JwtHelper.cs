using Core.Entities.Concrete;
using Core.Utilities.Security.Enciription;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Core.Extensions;

namespace Core.Utilities.Security.JWT
{

    public class JwtHelper : ITokenHelper
    {
        //IConfiguration api deki appconfiguration'ı okumamızı sağlar
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

        }
        //token oluşturur
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,//Tokenın yayıncısını temsil eder. tokenOptions.Issuer kullanılır.
                audience: tokenOptions.Audience,//Tokenın hedef kitlesini temsil eder. tokenOptions.Audience kullanılır.
                expires: _accessTokenExpiration,//Tokenın süresinin dolacağı tarih ve saat. _accessTokenExpiration kullanılır.
                notBefore: DateTime.Now,// Tokenın geçerlilik süresinin başladığı tarih ve saat. DateTime.Now kullanılır.
                claims: SetClaims(user, operationClaims),// Tokena eklenen talepleri temsil eder. SetClaims fonksiyonu kullanılır.
                signingCredentials: signingCredentials//Tokenın imzalanması için kullanılan kimlik bilgileri. signingCredentials parametresi kullanılır.
            );
            return jwt;
        }

        //Bu kod parçası, kullanıcının JWT içinde taşınacak taleplerini (claims) ayarlar.JWT'nin doğrulanması ve yetkilendirilmesi için kullanılırlar.
        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }


}
