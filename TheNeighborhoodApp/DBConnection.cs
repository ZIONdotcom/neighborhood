using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TheNeighborhoodApp
{
    public class DBConnection
    {
        SqlConnection cnn = new SqlConnection();
        SqlCommand cmm = new SqlCommand();
        SqlDataReader dr;
        public string MyConnection()
        {
            string con = @"Data Source=LAPTOP-SDGJ5NAJ;Initial Catalog=TheNeighborhoodApp;Integrated Security=True";
            return con;
        }

    }
}
