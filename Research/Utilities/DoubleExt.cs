namespace Entities.Utilities
{
    public static class DoubleExt
    {
        public static double ToDouble(this object obj, double defaultValue)
        {
            return obj.ToNullableDouble() ?? defaultValue;
        }

        public static double ToDouble(this object obj)
        {
            return obj.ToDouble(default);
        }

        public static double? ToNullableDouble(this object obj)
        {
            return obj.ToNullable<double>();
        }

        public static double Average(params double[] d)
        {
            return d.Average();
        }

        public static double Round(this double d, int digits)
        {
            return Math.Round(d, digits);
        }

        public static double? Round(this double? d, int digits)
        {
            if (d == null) return null;

            return Math.Round(d.Value, digits);
        }
    }
}