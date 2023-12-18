using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        //önlem olarak interface ile veriyoruz
        AccessToken CreateToken(User user,List<OperationClaim> operationClaims); //Token oluşturacak mekanizma

    }
}
//bizim api sistemimize kullanıcı adı ve şifresini gönderdikten sonra bu alan çalışacak
//eğer doğruysa ilgili kullanıcı için veritabanına gidecek 
//veritabanında claimlerine göre jwt üretecek ve buraya gönderecek