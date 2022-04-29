using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;


namespace DAL.Helpers
{
    internal static class TableValueParameterHelper
    {
        public static DataTable EmptyIntTableValueParameter(string[] parameterName)
        {
            DataTable table = new DataTable();
            foreach (string paramName in parameterName)
            {
                table.Columns.Add(paramName, typeof(Int32));
            }


            return table;
        }
        public static DataTable EmptyTableValueParameter(string parameterName)
        {
            DataTable table = new DataTable();
            table.Columns.Add(parameterName, typeof(int));

            return table;
        }

        public static DataTable EmptyLongTableValueParameter(string[] parameterName)
        {
            DataTable table = new DataTable();
            foreach (string paramName in parameterName)
            {
                table.Columns.Add(paramName, typeof(long));
            }


            return table;
        }

        public static DataTable CreateTableValueParameter(long[] values, string parameterName)
        {
            DataTable table = new DataTable();
            table.Columns.Add(parameterName, typeof(long));

            foreach (long value in values)
            {
                table.Rows.Add(value);
            }

            return table;
        }

        public static DataTable CreateTableValueParameter(long value, string parameterName)
        {
            DataTable table = new DataTable();
            table.Columns.Add(parameterName, typeof(long));

            table.Rows.Add(value);

            return table;
        }

        public static DataTable CreateTableValueParameter(int[] values, string parameterName)
        {
            DataTable table = new DataTable();
            table.Columns.Add(parameterName, typeof(int));

            foreach (int value in values)
            {
                table.Rows.Add(value);
            }

            return table;
        }

        public static DataTable CreateTableValueParameter(int value, string parameterName)
        {
            DataTable table = new DataTable();
            table.Columns.Add(parameterName, typeof(int));

            table.Rows.Add(value);

            return table;
        }

        public static DataTable CreateTableListValueParameter<T>(List<T> obj, params string[] ignoreProperties)
        {
            DataTable table = new DataTable();

            foreach (PropertyInfo prop in obj.FirstOrDefault().GetType().GetProperties())
            {
                if (ignoreProperties == null || !ignoreProperties.Contains(prop.Name))
                {
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
            }
            foreach (T o in obj)
            {
                List<object> values = new List<object>();
                foreach (PropertyInfo prop in o.GetType().GetProperties())
                {
                    if (ignoreProperties == null || !ignoreProperties.Contains(prop.Name))
                    {
                        var val = prop.GetValue(o);
                        values.Add((val == null) ? DBNull.Value : val);
                    }
                }

                table.Rows.Add(values.ToArray());
            }

            return table;
        }

        public static DataTable CreateTableValueParameter<T>(T obj, params string[] ignoreProperties)
        {
            DataTable table = new DataTable();
            List<object> values = new List<object>();
            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                if (ignoreProperties == null || !ignoreProperties.Contains(prop.Name))
                {
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                    var val = prop.GetValue(obj);
                    values.Add((val == null) ? DBNull.Value : val);
                }
            }

            table.Rows.Add(values.ToArray());

            return table;
        }

    }
}
