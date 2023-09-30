namespace Entities.Utilities
{
    public static class ToExt
    {
        public static T To<T>(this object obj) where T : struct
        {
            return obj.To(default(T));
        }

        public static T To<T>(this object obj, T defaultValue) where T : struct
        {
            var result = obj.ToNullable<T>();
            return result ?? defaultValue;
        }

        public static T? ToNullable<T>(this object obj) where T : struct
        {
            if (obj == null)
                return null;

            try
            {
                return (T)Convert.ChangeType(obj, typeof(T));
            }
            catch
            {
                try
                {
                    return (T)obj;
                }
                catch (Exception)
                {
                    try
                    {
                        return Enum.Parse(typeof(T), obj.ToString()).To<T>();
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
        }
    }
}