using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace HiTech.DataAccess
{
    public static class UtilityDB
    {
        public static SqlConnection ConnectDB()
        {
            SqlConnection connDB = new SqlConnection("data source=(local)\\MSSQLSERVER01; database=HiTechDB; Integrated Security= SSPI");
            connDB.Open();
            return connDB;
        }
    }
}
