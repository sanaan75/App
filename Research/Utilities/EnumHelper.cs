using System.Globalization;

namespace Entities.Utilities
{
    public static class EnumHelper
    {
        public static bool EnumHasValidValues(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("Type must be Enum");
            }

            var allItems = GetAllItems(enumType);

            var lst = new List<object>();

            foreach (var item in allItems)
            {
                var value = GetInt64Value(enumType, item);

                if (!lst.Contains(value))
                {
                    lst.Add(value);
                }
                else
                {
                    var message = $"An item ({item}) has duplicated value in {enumType.Name} Enum";
                    throw new ArgumentException(message);
                }
            }

            return true;
        }

        public static IEnumerable<object> GetAllItems(Type enumType)
        {
            var all = Enum.GetValues(enumType);
            return from object item in all
                let en = Parse(enumType, item)
                select en;
        }

        public static IList<T> GetAllItems<T>() where T : Enum
        {
            var items = Enum.GetValues(typeof(T));

            return (from object item in items
                let en = Parse<T>(item)
                select en).ToArray();
        }

        public static IList<T> GetAllItemsExcept<T>(params T[] ignores) where T : Enum
        {
            return GetAllItems<T>().Where(i => ignores.Contains(i) == false).ToList();
        }

        public static T[] SplitItems<T>(T e) where T : Enum
        {
            var items = GetAllItems<T>();
            return items
                .Where(i => (GetValue(typeof(T), e) & GetValue(typeof(T), i)) > 0)
                .ToArray();
        }

        public static T All<T>() where T : Enum
        {
            return Parse<T>(AllValue<T>());
        }

        public static int AllValue<T>() where T : Enum
        {
            var allItems = GetAllItems<T>();
            var sumOfValues = (from i in allItems select GetValue<T>(i)).Sum();
            return sumOfValues;
        }

        public static T Parse<T>(int v)
        {
            return Parse<T>(v.ToString(CultureInfo.InvariantCulture));
        }

        public static T Parse<T>(string s)
        {
            return (T)Enum.Parse(typeof(T), s);
        }

        public static object Parse(Type enumType, object o)
        {
            return Enum.Parse(enumType, o.ToString());
        }

        public static T Parse<T>(object o)
        {
            return Parse<T>(o.ToString());
        }

        public static bool IsFlagEnum(Type e)
        {
            try
            {
                var f = (FlagsAttribute[])e.GetCustomAttributes(typeof(FlagsAttribute), false);
                return f.Length > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string GetCaption(Enum e)
        {
            if (e == null)
                return string.Empty;

            var enumType = e.GetType();
            if (IsFlagEnum(enumType))
            {
                var value = GetValue(enumType, e);

                var items = GetAllItems(enumType);
                var captions = new List<string>();

                foreach (var item in items)
                {
                    var enumItem = GetValue(enumType, item);

                    if ((value & enumItem) > 0)
                    {
                        captions.Add(GetCaption(enumType, enumItem));
                    }
                }

                return string.Join("، ", captions.ToArray());
            }

            return GetCaption(enumType, e);
        }

        public static string GetCaption(Type enumType, object obj)
        {
            var e = Parse(enumType, obj);

            if (e == null) return string.Empty;

            try
            {
                return GetEnumInfo(enumType, obj).Caption ?? GlossaryExt.Get(e.ToString());
            }
            catch (Exception)
            {
                return GlossaryExt.Get(e.ToString());
            }
        }

        public static int GetValue(Enum e)
        {
            return int.Parse(Enum.Format(e.GetType(), e, "d"));
        }

        public static int GetValue(Type enumType, object o)
        {
            return int.Parse(Enum.Format(enumType, o, "d"));
        }

        public static int GetValue<T>(object o)
        {
            return GetValue(typeof(T), o);
        }

        public static long GetInt64Value(Enum e)
        {
            return long.Parse(Enum.Format(e.GetType(), e, "d"));
        }

        public static long GetInt64Value(Type enumType, object o)
        {
            return long.Parse(Enum.Format(enumType, o, "d"));
        }

        public static bool IsSingleFlag(Enum e)
        {
            var value = e.ToNullableInt32();
            return value != 0 && (value & (value - 1)) == 0;
        }

        private static EnumInfoAttribute GetEnumInfo(Type enumType, object obj)
        {
            var e = Parse(enumType, obj);
            var name = e.ToString();
            var fieldInfo = enumType.GetField(name);
            var attributes = (EnumInfoAttribute[])fieldInfo.GetCustomAttributes(typeof(EnumInfoAttribute), false);
            return attributes.Any() ? attributes[0] : null;
        }
    }
}