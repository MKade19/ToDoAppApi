using System.Security.Cryptography;
using System.Text;
using ToDoApp.Auth.Services.Abstract;

namespace ToDoApp.Auth.Services
{
    public class HashService : IHashService
    {
        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public string GetHash(string stringToHash, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(keySize);

            var hash = Rfc2898DeriveBytes.Pbkdf2
            (
                Encoding.UTF8.GetBytes(stringToHash),
                salt,
                iterations,
                hashAlgorithm,
                keySize
            );

            return Convert.ToHexString(hash);
        }

        
        public bool VerifyHash(string stringToCompare, string hashedString, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(stringToCompare, salt, iterations, hashAlgorithm, keySize);
            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hashedString));
        }
    }
}
