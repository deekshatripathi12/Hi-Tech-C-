using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiTech.DataAccess;

namespace HiTech.Business
{
    public class Customer
    {
        private int customerId;
        private string name;
        private string street;
        private string city;
        private string postalCode;
        private string phoneNumber;
        private string faxNumber;
        private float creditLimit;

        public int CustomerId { get => customerId; set => customerId = value; }
        public string Name { get => name; set => name = value; }
        public string Street { get => street; set => street = value; }
        public string City { get => city; set => city = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string FaxNumber { get => faxNumber; set => faxNumber = value; }
        public float CreditLimit { get => creditLimit; set => creditLimit = value; }
        

        public bool SaveCustomer(Customer cust)
        {
            return CustomerDB.SaveCustomer(cust);
        }

        public bool UpdateCustomer(Customer cust)
        {
            return CustomerDB.UpdateCustomer(cust);
        }

        public bool DeleteCustomer(int customerId)
        {
            return CustomerDB.DeleteCustomer(customerId);
        }

        public DataTable ListCustomers()
        {
            return CustomerDB.ListAllCustomers();
        }

        public string SearchCustomer(Customer customer)
        {
            return CustomerDB.SearchCustomer(customer);
        }
    }
}
