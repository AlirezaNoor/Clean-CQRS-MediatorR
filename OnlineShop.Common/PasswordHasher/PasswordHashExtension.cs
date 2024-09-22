using System.Security.Cryptography;
using System.Text;

namespace OnlineShop.Common.PasswordHasher;

public static class PasswordHashExtension
{
    public static string Hashpassword(this string password, string salt)
    {
        var Saltedpassword = password + salt;

        using (var sha256=SHA256.Create())
        {
            var passwordBytes = Encoding.UTF8.GetBytes(Saltedpassword);
            
            // Compute the hash
            var hashBytes = sha256.ComputeHash(passwordBytes);

            // Convert the hash to a string (hexadecimal format)
            var hashString = new StringBuilder();
            foreach (var b in hashBytes)
            {
                hashString.Append(b.ToString("x2"));
            }

            return hashString.ToString();
        }
    }
    public static string GenerateSalt()
    {
        var saltBytes = new byte[16]; // 128-bit salt
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(saltBytes);
        }

        return Convert.ToBase64String(saltBytes);
    }
}