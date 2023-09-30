using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Entities.Utilities.TextHelper
{
    public static class StringHashHelper
    {
        private static byte[] GetUtf8Bytes(string str) => new UTF8Encoding().GetBytes(str);

        public static byte[] CalculateStringMD5Hash(string str)
        {
            byte[] utf8Bytes = StringHashHelper.GetUtf8Bytes(str);
            using (MD5CryptoServiceProvider cryptoServiceProvider = new MD5CryptoServiceProvider())
                return cryptoServiceProvider.ComputeHash(utf8Bytes);
        }

        public static byte[] CalculateStringSha1Hash(string str) =>
            new SHA1Managed().ComputeHash(StringHashHelper.GetUtf8Bytes(str));

        public static string CalculateStringSha1HashString(string str) =>
            Convert.ToBase64String(StringHashHelper.CalculateStringSha1Hash(str));

        public static byte[] CalculateStringSha512Hash(string str) =>
            new SHA512Managed().ComputeHash(StringHashHelper.GetUtf8Bytes(str));

        public static string CalculateStringSha512HashString(string str) =>
            Convert.ToBase64String(StringHashHelper.CalculateStringSha512Hash(str));
    }

    public static class StringGlossaryExt
    {
        public static string ApplyGlossary(this string str)
        {
            foreach (Match match in new Regex("\\[[^\\]]+\\]").Matches(str))
            {
                string key = match.Value.Trim('[', ']');
                str = str.Replace(match.Value, GlossaryExt.Get(key));
            }

            return str;
        }
    }
}