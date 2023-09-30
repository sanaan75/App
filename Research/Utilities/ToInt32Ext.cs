namespace Entities.Utilities
{
    public static class ToInt32Ext
    {
        public static int ToInt32(this object obj)
        {
            return obj.ToInt32(default);
        }

        public static int ToInt32(this object obj, int defaultValue)
        {
            return obj.ToNullableInt32() ?? defaultValue;
        }

        public static int? ToNullableInt32(this object obj)
        {
            return obj.ToNullable<int>();
        }
    }
}