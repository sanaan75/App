namespace Entities.Utilities
{
    public static class BooleanExt
    {
        public static string ToYesNo(this bool b)
        {
            return b ? "بله" : "خیر";
        }
    }
}