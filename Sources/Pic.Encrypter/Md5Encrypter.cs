using Microsoft.Extensions.Options;
using Pic.Shared.Configuration;
using Pic.Shared.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Pic.Encrypter
{
    public class Md5Encrypter : IEncrypter
    {
        private readonly string salt;

        public Md5Encrypter(IOptions<AppConfiguration> appConfiguration)
        {
            salt = appConfiguration.Value.Salt;
        }

        public string Encrypt(string toCipher)
        {
            using MD5 md5Hash = MD5.Create();

            return GetMd5Hash(md5Hash, $"{salt}{toCipher}");
        }

        private static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}