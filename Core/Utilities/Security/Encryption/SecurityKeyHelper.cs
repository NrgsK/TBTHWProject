using Microsoft.IdentityModel.Tokens; //****SecurityKey
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        //içerisinde şifreleme olan sistemlerde bizim herşeyi bir byte array formatında vermemiz gerekiyor.
        //bir string le key oluşturamıyoruz. json web token ların anlayacağı dilde yazmamız gerekir
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            //SecurityKey --> NuGet Microsoft.IdentityModel.Tokens
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            //simetrik ve asimetrik anahtarlar


        }
    }
}
