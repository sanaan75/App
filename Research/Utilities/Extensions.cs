using System.Data;
using System.Reflection;

namespace Entities.Utilities
{
    public static class Extensions
    {
        public static List<T> ToList<T>(this DataTable table) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            List<T> result = new List<T>();

            foreach (var row in table.Rows)
            {
                var item = CreateItemFromRow<T>((DataRow)row, properties);
                result.Add(item);
            }

            return result;
        }

        public static List<T> SetToList<T>(this DataSet dataSet) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            List<T> result = new List<T>();

            foreach (var row in dataSet.Tables[0].Rows)
            {
                var item = CreateItemFromRow<T>((DataRow)row, properties);
                result.Add(item);
            }

            return result;
        }

        private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            T item = new T();
            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(System.DayOfWeek))
                {
                    DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), row[property.Name].ToString());
                    property.SetValue(item, day, null);
                }
                else
                {
                    if (row[property.Name] == DBNull.Value)
                        property.SetValue(item, null, null);
                    else
                    {
                        if (Nullable.GetUnderlyingType(property.PropertyType) != null)
                        {
                            //nullable
                            object convertedValue = null;
                            try
                            {
                                convertedValue = System.Convert.ChangeType(row[property.Name],
                                    Nullable.GetUnderlyingType(property.PropertyType));
                            }
                            catch (Exception ex)
                            {
                            }

                            property.SetValue(item, convertedValue, null);
                        }
                        else
                            property.SetValue(item, row[property.Name], null);
                    }
                }
            }

            return item;
        }
    }
}