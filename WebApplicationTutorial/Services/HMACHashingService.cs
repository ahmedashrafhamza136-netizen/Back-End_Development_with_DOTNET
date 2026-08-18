using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace WebApplicationTutorial.Interfaces
{
    public class HMACHashingService : IHashingService
    {
        private String secretKey;

        public HMACHashingService(IConfiguration configuration)
        {
            secretKey = configuration["Hmac:SecretKey"]
                ?? throw new InvalidOperationException("HMAC secret key is not configured.");
        }
        public Boolean VerifyHash(string hashed, object o)
        {
            if(GetHash(o).Equals(hashed))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetHash(object o)
        {
            String serialized_text = JsonSerializer.Serialize(o);
            byte[] hashBytes = HMACSHA256.HashData(Encoding.UTF8.GetBytes(secretKey), Encoding.UTF8.GetBytes(serialized_text ?? ""));
            return Convert.ToBase64String(hashBytes);
        }


    }
}