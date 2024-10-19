using System.Data;
using System.Reflection;
using System.Xml.Linq;

namespace LT.Application.Utilities
{
    public static class Converter
    {
        /// <summary>
        ///  Convert Data table columns into list with dictionary column mapping
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataTable"></param>
        /// <param name="columnMapping"> Key indicate the class property name and Value indicates data table column name</param>
        /// <returns></returns>
        public static List<T> ToList<T>(this DataTable dataTable, Dictionary<string, string> columnMapping = null) where T : class
        {
            List<T> list = [];
            Dictionary<string, string> properties = typeof(T).GetProperties().
                Select(c => new KeyValuePair<string, string>(c.Name, c.Name)).ToDictionary(i => i.Key, i => i.Value);
            if (columnMapping != null)
            {
                foreach (KeyValuePair<string, string> item in columnMapping)
                {
                    properties[item.Key] = item.Value;
                }
            }
            foreach (DataRow row in dataTable.Rows)
            {
                T obj = Class<T>(row, properties);
                list.Add(obj);
            }
            return list;
        }

        public static T Class<T>(DataRow row) where T : class
        {
            string[] properties = typeof(T).GetProperties().Select(x => x.Name).ToArray();
            T obj = Class<T>(row, properties);
            return obj;
        }

        public static string XML<T>(List<T> list) where T : class
        {
            XElement xmlList = new("RootNode");
            PropertyInfo[] propertyInfos = typeof(T).GetProperties();
            foreach (T item in list)
            {
                XElement xml = new("DataNode");
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    xml.Add(new XElement(propertyInfo.Name, propertyInfo.GetValue(item)));
                }
                xmlList.Add(xml);
            }
            return xmlList.ToString();
        }

        private static T Class<T>(DataRow row, string[] properties) where T : class
        {
            T obj = Activator.CreateInstance<T>();
            var propertiesToCheck = properties.Where(x => row.Table.Columns.Contains(x));
            foreach (string property in propertiesToCheck)
            {
                PropertyInfo propertyInfo = obj.GetType().GetProperty(property);
                if (propertyInfo.PropertyType.IsGenericType)
                {
                    if (row[property] != DBNull.Value)
                    {
                        propertyInfo.SetValue(obj, Convert.ChangeType(row[property], propertyInfo.PropertyType.GetGenericArguments()[0]));
                    }
                }
                else
                {
                    propertyInfo.SetValue(obj, Convert.ChangeType(row[property], propertyInfo.PropertyType));
                }
            }
            return obj;
        }

        private static T Class<T>(DataRow row, Dictionary<string, string> properties) where T : class
        {
            T obj = Activator.CreateInstance<T>();
            foreach (KeyValuePair<string, string> property in properties.Where(p => row.Table.Columns.Contains(p.Value)))
            {
                PropertyInfo propertyInfo = obj.GetType().GetProperty(property.Key);
                if (propertyInfo.PropertyType.IsGenericType)
                {
                    if (row[property.Value] != DBNull.Value)
                    {
                        propertyInfo.SetValue(obj, Convert.ChangeType(row[property.Value], propertyInfo.PropertyType.GetGenericArguments()[0]));
                    }
                }
                else
                {
                    propertyInfo.SetValue(obj, Convert.ChangeType(row[property.Value], propertyInfo.PropertyType));
                }
            }
            return obj;
        }

        public static T ToClass<T>(this DataTable dataTable, Dictionary<string, string> columnMapping = null) where T : class, new()
        {
            T obj = new();
            try
            {
                Dictionary<string, string> properties = typeof(T).GetProperties().
               Select(c => new KeyValuePair<string, string>(c.Name, c.Name)).ToDictionary(i => i.Key, i => i.Value);
                if (columnMapping != null)
                {
                    foreach (KeyValuePair<string, string> item in columnMapping)
                    {
                        properties[item.Key] = item.Value;
                    }
                }
                foreach (DataRow row in dataTable.Rows)
                {
                    obj = Class<T>(row, properties);
                }
                return obj;
            }
            catch (Exception)
            {
                return obj;
            }
        }
        public static DataTable ConvertListToDataTable<AnyType>(List<AnyType> items)
        {
            DataTable dataTable = new();
            PropertyInfo[] Props = typeof(AnyType).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                dataTable.Columns.Add(prop.Name);
            }
            foreach (AnyType list in items)
            {
                DataRow dr = dataTable.NewRow();
                foreach (PropertyInfo prop in Props)
                {
                    dr[prop.Name] = prop.GetValue(list);
                }
                dataTable.Rows.Add(dr);
            }
            return dataTable;
        }
    }
}
