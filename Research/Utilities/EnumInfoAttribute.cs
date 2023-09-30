namespace Entities.Utilities
{
    public class EnumInfoAttribute : Attribute
    {
        public string Caption { get; set; }

        public EnumInfoAttribute(string caption)
        {
            Caption = caption;
        }
    }
}