using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TheNeighborhoodApp
{
    public class DBConnection
    {
        SqlConnection cnn = new SqlConnection();
        SqlCommand cmm = new SqlCommand();
        //SqlDataReader dr;

        
        public string MyConnection()
        {
            //@"Data Source=DESKTOP-09ORH5O\MSSQLSERVER01;Initial Catalog=neighborhoodDB;Integrated Security=True;Pooling=False";
            string con = "";
           return con;
        }
        
    }
}
