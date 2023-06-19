using System.Security.Cryptography;


namespace Northwind.Utilities;
public  class TokenUtility

    
{
    public static string GenerateKey(int size)
    {
        byte[] key = new byte[size / 8]; // Divide by 8 to convert from bits to bytes
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(key);
        }
        return Convert.ToBase64String(key);
    }
}
