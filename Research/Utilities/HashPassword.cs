using System.Text;
using Entities.Utilities.TextHelper;

namespace Entities.Utilities
{
    public static class HashPassword
    {
        public static string Hash(string username, string plainPassword)
        {
            var maxLength = username.Length > plainPassword.Length ? username.Length : plainPassword.Length;
            username = username.PadLeft(maxLength, '$');
            plainPassword = plainPassword.PadLeft(maxLength, '$');

            var sb = new StringBuilder();

            for (var i = 0; i < maxLength; i++)
            {
                sb.Append(username[i]);
                sb.Append(plainPassword[i]);
            }

            return StringHashHelper.CalculateStringSha512HashString(sb.ToString());
        }
    }
}