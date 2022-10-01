using System.Security.Cryptography;
using System.Text;

namespace jcGAI.WebAPI.Common
{
    public static class Extensions
    {
        public static string ToSHA256(this string str)
        {
            using var sha = SHA256.Create();

            return BitConverter.ToString(sha.ComputeHash(Encoding.ASCII.GetBytes(str)));
        }
    }
}
