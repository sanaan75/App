namespace Entities.Utilities
{
    public static class EnumExt
    {
        public static string GetCaption(this Enum? en)
        {
            if (en is null)
                return string.Empty;
            return GlossaryExt.Get(en.ToString());
        }

        public static int GetValue(Enum en)
        {
            return int.Parse(Enum.Format(en.GetType(), en, "d"));
        }

        public static Dictionary<string, int> GetList<T>()
        {
            Dictionary<string, int> list = new Dictionary<string, int>();
            var fields = typeof(T).GetFields().Where(i => i.Name != "value__");

            foreach (var field in fields)
            {
                list.Add(GlossaryExt.Get(field.Name), Convert.ToInt32(field.GetValue(null)));
            }

            return list;
        }

        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}