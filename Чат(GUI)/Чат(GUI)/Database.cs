using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Чат_GUI_
{
    internal class Database
    {
        SqlConnection connect = new SqlConnection(@"Data Source=WIN-7PCT79QT58P\SQLEXPRESS;Initial Catalog=test;Integrated Security=True");

        public void openConnection()
        {
            if(connect.State == System.Data.ConnectionState.Closed)
            {
                connect.Open();
            }
        }

        public void closeConnection()
        {
            if (connect.State == System.Data.ConnectionState.Open)
            {
                connect.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return connect;
        }
    }
}
