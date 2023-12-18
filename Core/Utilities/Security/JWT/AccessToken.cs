using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        //AccessToken --> erişim anahtarı
        //anlamsız değerlerden oluşan bir metindir
        //token = json web token
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

    }
}
