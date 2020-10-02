using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HiTech.Business
{
    class Employee
    {
        private string employeeId;
        private string firstName;
        private string lastName;
        private string jobId;
        private string userName;
        private string password;

        public string EmployeeId { get => employeeId; set => employeeId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string JobId { get => jobId; set => jobId = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }

       
    }


}
