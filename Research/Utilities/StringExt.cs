using System.Text;

namespace Entities.Utilities
{
    public static class StringExt
    {
        public static string Join(this IEnumerable<string> items, string delim)
        {
            return StringHelper.Join(delim, items);
        }

        public static DateTime? GetDate(this string date)
        {
            return StringHelper.GetDate(date);
        }

        public static string JoinByComma(this IList<string> items)
        {
            if (items == null || items.Count == 0)
                return string.Empty;

            if (items.Count == 1)
                return items.Single();

            var result = new StringBuilder();

            for (var i = 0; i < items.Count - 1; i++)
                result.Append(items[i] + "، ");

            result.Append("و " + items.Last());

            return result.ToString();
        }

        public static byte[] ToUtf8Bytes(this string str)
        {
            return new UTF8Encoding().GetBytes(str);
        }

        public static string ToStaticFileUrl(this string path)
        {
            var keyword = "/wwwroot/";
            var index = path.IndexOf(keyword);

            return path.Substring(index).Replace(keyword, "/");
        }
    }
}