using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToSql.XmlHelper
{
    class DBHelper
    {
        private SqlConnection connection;

        public DBHelper()
        {
            if (connection == null)
            {
                connection = new SqlConnection();
            }
        }

        public ConnectionState connect()
        {
            connection.ConnectionString = getConnectionString();
            try
            {
                connection.Open();
                Console.WriteLine("State: {0}", connection.State);
                Console.WriteLine("ConnectionTimeout: {0}", connection.ConnectionTimeout);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return connection.State;
            }
            return connection.State;
        }

        private String getConnectionString(String connectionStr = "")
        {
            if(connectionStr == "")
            {
                return ConfigurationManager.ConnectionStrings["dbConnect"].ConnectionString;
            }

            return connectionStr;
        }

        public void inertToDB()
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO COUNTRY (COUNTRY_CODE, COUNTRY_NAME) VALUES (@CountryCode, @CountryName)",this.connection))
            {
                cmd.Parameters.Add(new SqlParameter("CountryCode", "DE"));
                cmd.Parameters.Add(new SqlParameter("CountryName", "Germany"));
                cmd.ExecuteNonQuery();
            }
        }

    }
}
