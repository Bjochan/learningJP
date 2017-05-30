using System;
using System.Data;
using System.Data.SqlClient;

namespace LearningJapanese.LogicClass
{
    class clsData
    {
    }

    class DataConfig
    {
        public SqlConnection getConnection()
        {
            return new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["strConnection"].ToString());
        }

        public void CloseConnection()
        {
            SqlConnection connection = this.getConnection();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public void ExecStore(string StoreName, string[] param1, object[] value)
        {
            try
            {
                SqlConnection connection = this.getConnection();
                SqlCommand command = new SqlCommand();
                connection.Open();
                command.CommandText = StoreName;
                command.CommandType = CommandType.StoredProcedure;
                int length = param1.Length;
                for (int i= 0; i<length;i++)
                {
                    command.Parameters.Add(new SqlParameter(param1[i], value[i]));
                }
                command.Connection = connection;
                command.ExecuteNonQuery();
                connection.Close();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable GetStoreDataTable(string StoreName, string[] param1, object[] value)
        {
            DataSet set2;
            try
            {
                SqlConnection connection = this.getConnection();
                using (SqlCommand command = new SqlCommand(StoreName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    int length = param1.Length;
                    for (int i=0; i<length; i++)
                    {
                        command.Parameters.Add(new SqlParameter(param1[i], value[i]));
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    connection.Close();
                    set2 = dataSet;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            if (set2 != null && set2.Tables.Count > 0)
                return set2.Tables[0];
            return null;
        }

        public DataTable getTable (string sql)
        {
            SqlConnection conn = getConnection();
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        public void Excute(String sql)
        {
            SqlConnection conn = getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }
    }

    //users
    class User
    {
        DataConfig dc = new DataConfig();
        public DataTable showUser()
        {
            DataTable dt = new DataTable();
            dt = dc.GetStoreDataTable("showUser ", new string[] { }, new object[] { });
            return dt;
        }

        public DataTable GetInfoUser (string UID, string PID)
        {
            DataTable dt = new DataTable();
            dt = dc.GetStoreDataTable("LoginForm", new string[] { "@username", "@pass" }, new object[] { UID, PID });
            return dt;
        }
        public DataTable ChangePass (string User, string pass, string newpass)
        {
            DataTable dt = new DataTable();
            dt = dc.GetStoreDataTable("ChangePass", new string[] { "@username", "@pass", "NewPass" }, new object[] { User, pass, newpass });
            return dt;
        }
    }
}
