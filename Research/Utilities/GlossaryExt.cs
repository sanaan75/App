using Research.Utilities;

namespace Entities.Utilities
{
    public static class GlossaryExt
    {
        private static Dictionary<string, string> _glossary;

        public static string Get(string key)
        {
            if (_glossary == null)
            {
                _glossary = new Dictionary<string, string>();
                var fields = typeof(Glossary).GetFields();

                foreach (var field in fields)
                    _glossary.Add(field.Name, field.GetValue(null) as string);
            }

            try
            {
                if (key == null)
                    return string.Empty;

                return _glossary[key];
            }
            catch
            {
                return key;
            }
        }
    }
}