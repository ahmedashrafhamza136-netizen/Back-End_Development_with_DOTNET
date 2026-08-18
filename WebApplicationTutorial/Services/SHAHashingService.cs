using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace WebApplicationTutorial.Interfaces
{
    public class SHAHashingService : IHashingService
    {
        public Boolean VerifyHash(string hashed, object o)
        {
            if (GetHash(o).Equals(hashed))
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
            byte[] hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(serialized_text ?? ""));
            return Convert.ToBase64String(hashBytes);
        }


    }
}