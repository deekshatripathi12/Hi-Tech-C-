using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiTech.DataAccess;


namespace HiTech.Business
{
    public class User
    {
        private int employeeId;
        private string firstName;
        private string lastName;
        private int jobId;
        private string username;
        private string password;

        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int JobId { get => jobId; set => jobId = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public int Login(User user)
        {
            return UserDB.Login(user);
        }

        public bool SaveUser(User user)
        {
            return UserDB.SaveUser(user);
        }

        public bool UpdateUser(User user)
        {
            return UserDB.UpdateUser(user);
        }

        public int SearchUser(string FirstName)
        {
            return UserDB.SearchUser(FirstName);
        }

        public bool DeleteUser(int userId)
        {
            return UserDB.DeleteUsers(userId);
        }

        public DataTable ListUsers()
        {
            return UserDB.ListAllUsers();
        }

    }
}
