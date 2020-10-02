using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using HiTech.Business;
using System.Windows.Forms;

namespace HiTech.DataAccess
{
    class CustomerDB
    {
        public static SqlConnection connDB = UtilityDB.ConnectDB();
        public static SqlCommand cmd = new SqlCommand();

        public static bool SaveCustomer(Customer cust)
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
                cmd.CommandText = string.Format("insert into Customers values( '{0}', '{1}','{2}','{3}','{4}','{5}', '{6}')",
                cust.Name, cust.Street, cust.City, cust.PostalCode, cust.PhoneNumber, cust.FaxNumber, cust.CreditLimit);
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

        public static bool UpdateCustomer(Customer cust)
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
                cmd.CommandText = string.Format("UPDATE Customer SET Street ='{0}', City ='{1}', " +
                    "PostalCode ='{2}' , PhoneNumber ='{3}', FaxNumber ='{4}', CreditLimit ={5}" +
                    " WHERE CustomerId='{5}'", cust.Street, cust.City, cust.PostalCode, cust.PhoneNumber, cust.FaxNumber, cust.CreditLimit, cust.CustomerId);
                cmd.ExecuteNonQuery();
                connDB.Close();
            }

            catch (Exception)
            {
                result = false;
                throw;
            }
            return result;

        }

        public static bool DeleteCustomer(int CustomerId)
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
                cmd.CommandText = string.Format("delete from Customer where CustomerId ='{0}'", CustomerId);
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

        public static DataTable ListAllCustomers()
        {
            if (connDB.State == ConnectionState.Closed)
            {
                connDB = UtilityDB.ConnectDB();
                cmd = new SqlCommand();
            }

            cmd.Connection = connDB;
            cmd.CommandText = "select * from Customer";
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            cmd.Dispose();
            connDB.Close();
            return dt;
        }

        public static string SearchCustomer(Customer customer)
        {
            if (connDB.State == System.Data.ConnectionState.Closed)
            {
                connDB = UtilityDB.ConnectDB();
                cmd = new SqlCommand();
            }
            
            cmd.Connection = connDB;
            cmd.CommandText = string.Format("SELECT Name FROM [Customer] WHERE CustomerId='{0}'", customer.CustomerId);
            string Name = (String)cmd.ExecuteScalar();
            connDB.Close();
            return Name;
        }
    }
}
