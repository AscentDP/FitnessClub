using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _3ISP919_Naliv_LoginReg
{
    class DB
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-N9EM8FE\SQLEXPRESS;Initial Catalog=QashqaiFitness;Integrated Security=True");
        public void openConnection()
        {
            if(sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void closeConnection()
        {
            if ( sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection getConnection()
        {
            return sqlConnection;
        }
    }

}
