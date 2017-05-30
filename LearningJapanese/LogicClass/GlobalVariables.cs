using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningJapanese.LogicClass
{
    class GlobalVariables
    {
        public static String ApplicationName = "できる日本語";
        public class Item
        {
            public string Name;
            public string Value;

            public Item(string name, string value)
            {
                Name = name; Value = value;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        public static string Version;
        public static string User;
        public static string userName;
        public static int IsAdmin = 0;

        public class DataTableHelper
        {
            public DataTable SelectDistinct (string TableName, DataTable SourceTable, string FieldName, string fillter)
            {
                DataTable dt = new DataTable(TableName);
                dt.Columns.Add(FieldName, SourceTable.Columns[FieldName].DataType);

                object LastValue = null;
                foreach (DataRow dr in SourceTable.Select(fillter, FieldName))
                {
                    if(LastValue ==null || !(ColumnEqual(LastValue, dr[FieldName])))
                    {
                        LastValue = dr[FieldName];
                        dt.Rows.Add(new object[] { LastValue });
                    }
                }
                return dt;
            }

            private bool ColumnEqual(object lastValue, object B)
            {
                if (lastValue == DBNull.Value && B == DBNull.Value)
                    return true;
                if (lastValue == DBNull.Value || B == DBNull.Value)
                    return false;
                return (lastValue.Equals(B));
            }
        }
    }
}



