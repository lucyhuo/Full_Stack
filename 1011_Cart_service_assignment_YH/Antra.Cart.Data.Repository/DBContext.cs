using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace Antra.Cart.Data.Repository
{
    class DBContext
    {
        public IDbConnection GetConnection()
        {
            string conn = "Data Source=.;Initial Catalog=Mydatabase;Integrated Security=True";
            return new SqlConnection(conn);
        }
    }
}
