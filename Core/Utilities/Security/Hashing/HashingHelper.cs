using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //bizim için bir araç o yüzden açık/public kalabilir
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //passwordhash oluşturulur
            //string password ile bir password göndeririz ve dışarıya out byte[] passwordHash,out byte[] passwordSalt ile bir şifre çıkarıcaz
            //desposable pattern
            //.net in cryptograpy kütüphanesini kullanacağız
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                //!!!! neden using kullanıldı !!!!!
                //HMACSHA512() şu yapı ile birer passwordsalt ve passwordhash oluşturacağız
                passwordSalt = hmac.Key; //ilgili algoritmanın Key değerini kullanıyoruz
                //Key her kullanıcı için farklı bir key değeri oluşturur.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                //bir string in byte değerini almak istiyorsak Encoding.UTF8.GetBytes()


            }

        }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            //passwordhash i doğrulama
            //burada parametrede out keywordünü kullanmamıza gerek yok çünkü değerleri biz vereceğiz
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                //HMACSHA512 key olarak salt şifremizi parametre içinde yazmamızı istiyor
                //password ü hashlememiz gerekiyor. burada password kullanıcının girdiği parola
                //burada kullanıcı şifreyi tekrardan sisteme giriyor
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                //computed hesaplanan
                //hesaplama yöntemi - oluşan değer bir byte[] ve bunu karşılaştırmamız gerekiyor

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        //hesaplanan ile hash şifremiz eşleşmiyorsa false değeri döner 
                        return false;
                    }
                }

            }
            return true;
        }
    }
}
