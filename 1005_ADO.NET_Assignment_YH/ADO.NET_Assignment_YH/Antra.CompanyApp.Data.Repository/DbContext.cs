using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace Antra.CompanyApp.Data.Repository
{
    class DbContext
    {

        public int Execute(string cmdText, Dictionary<string, object> parameters)
        {
            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=CompanyDB;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            try
            {
                connection.Open();
                cmd.CommandText = cmdText;
                if(parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }
                }
                cmd.Connection = connection;
                int r = cmd.ExecuteNonQuery(); // call this method to insert, update, delete 
                return r;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
                connection.Dispose();
                cmd.Dispose();
            }
            return 0;
        }

        public DataTable Query(string cmdText, Dictionary<string, object> parameters, CommandType cmdType=CommandType.Text)
        {
            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=CompanyDB;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            try
            {
                connection.Open();
                cmd.CommandText = cmdText;
                cmd.CommandType = cmdType;
                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }
                }
                cmd.Connection = connection;

                /*
                 * DataReader is readonly
                 * DataReader is forward only 
                 * Reader can be used in connected approach 
                 */
                SqlDataReader reader = cmd.ExecuteReader(); // call this method to select
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
                connection.Dispose();
                cmd.Dispose();
            }
            return null;
        }
    }
}


