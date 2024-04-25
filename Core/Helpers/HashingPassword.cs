using System.Security.Cryptography;
using System.Text;

namespace Core.Helpers;

public class HashingPassword
{
    public static string HashPassword(string password)
    {
        using(SHA256 sha256Hash = SHA256.Create())
        {  
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            // İşlenmiş veriyi base64 stringine dönüştür
            StringBuilder builder = new StringBuilder();
            for(int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString().ToUpper();
        }
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        string hashedPasswordInput = HashPassword(password);
        return hashedPasswordInput == hashedPassword;
    }
}