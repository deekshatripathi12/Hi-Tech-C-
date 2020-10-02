using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using HiTech.Business;

namespace HiTech.DataAccess
{
    public static class UserDB
    {
        public static SqlConnection connDB = UtilityDB.ConnectDB();
        public static SqlCommand cmd = new SqlCommand();
               
        public static int Login(User user)
        {
            int jobId = 0;

            if (connDB.State == ConnectionState.Closed)
            {
                connDB = UtilityDB.ConnectDB();
                cmd = new SqlCommand();
            }
            cmd.Connection = connDB;
            cmd.CommandText = string.Format("select jobId from [Employee] where username='{0}' and password='{1}'", user.Username, user.Password);
            SqlDataReader reader = cmd.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count++;
            }
            reader.Close();

            if (count > 0)
            {
                jobId = (Int32)cmd.ExecuteScalar();

            }
            else
            {
                jobId = 0;
            }
            cmd.Dispose();
            connDB.Close();
            return jobId;
        }


        public static bool SaveUser(User user)
        {
            bool result = true;
            try
            {
                if (connDB.State == ConnectionState.Closed)
                {
                    connDB = UtilityDB.ConnectDB();
                    cmd = new SqlCommand();
                }

                cmd.Connection = connDB;
                cmd.CommandText = string.Format("insert into Employee values('{0}', '{1}',{2},'{3}','{4}')",
                user.FirstName, user.LastName, user.JobId, user.Username, user.Password);
                cmd.ExecuteNonQuery();
                connDB.Close();
            }
            catch (Exception)
            {
                result = false;
                // throw;
            }
            return result;
        }

        public static bool UpdateUser(User user)
        {
            bool result = true;
            try
            {
                if (connDB.State == ConnectionState.Closed)
                {
                    connDB = UtilityDB.ConnectDB();
                    cmd = new SqlCommand();
                }
                cmd.Connection = connDB;
                cmd.CommandText = string.Format("UPDATE Employee SET FirstName ='{0}', LastName ='{1}', JobId ={2} , UserName ='{3}', Password ='{4}' WHERE EmployeeId={5}", user.FirstName, user.LastName, user.JobId, user.Username, user.Password, user.EmployeeId);
                cmd.ExecuteNonQuery();
                connDB.Close();
            }
              
            catch (Exception)
            {
                result = false;
                //throw;
            }
            return result;

        }

        public static bool DeleteUsers(int EmployeeId)
        {
            bool result = true;
            try
            {

                if (connDB.State == ConnectionState.Closed)
                {
                    connDB = UtilityDB.ConnectDB();
                    cmd = new SqlCommand();
                }
                cmd.Connection = connDB;
                cmd.CommandText = string.Format("delete from Employee where EmployeeId ='{0}'", EmployeeId);
                cmd.ExecuteNonQuery();
                connDB.Close();
            }
            catch (Exception)
            {
                result = false;
                // throw;
            }

            return result;
        }

        public static int SearchUser(string FirstName)
        {
            if (connDB.State == System.Data.ConnectionState.Closed)
            {
                connDB = UtilityDB.ConnectDB();
                cmd = new SqlCommand();
            }

            cmd.Connection = connDB;
            cmd.CommandText = string.Format("SELECT EmployeeId FROM Employee WHERE FirstName='{0}'", FirstName);
            int UserId = Convert.ToInt32(cmd.ExecuteScalar());
            connDB.Close();
            return UserId;
        }


        public static DataTable ListAllUsers()
        {
            if (connDB.State == ConnectionState.Closed)
            {
                connDB = UtilityDB.ConnectDB();
                cmd = new SqlCommand();
            }

            cmd.Connection = connDB;
            cmd.CommandText = "select * from Employee";
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            cmd.Dispose();
            connDB.Close();
            return dt;
        }


    }
}
