using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace POS_TPM__store
{
    public class Connection
    {
        public SqlConnection getConnected = new SqlConnection(@"Data Source=HPPAV14\HPPAV14;Initial Catalog=IOOP_Assignment_try2;Integrated Security=True");
        SqlConnection online = new SqlConnection();
        public SqlConnection Ready()
        {
            if (ConnectionState.Closed == getConnected.State) { getConnected.Open(); }
            return online;
        }

    }
}
