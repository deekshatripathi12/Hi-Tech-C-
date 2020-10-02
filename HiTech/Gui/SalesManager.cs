using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiTech.Business;
using System.Data.SqlClient;

namespace HiTech.Gui
{
    public partial class SalesManager : Form
    {

        DataSet dshitechDB;
        DataTable dtCustomer;
        SqlDataAdapter da;


        public SalesManager()
        {
            InitializeComponent();
        }

        private void ClearTextBox()
        {
            txtCustomerId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtStreet.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtPostalCode.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtFax.Text = string.Empty;
            txtCreditLimit.Text = string.Empty;
        }

        private void SalesManager_Load(object sender, EventArgs e)
        {
            //txtCustomerId.Enabled = false;
            SqlConnection connDB = new SqlConnection("data source=(local)\\MSSQLSERVER01 ; database=HiTechDB ; Integrated Security = SSPI");
            dshitechDB = new DataSet("hitechDB");
            dtCustomer = new DataTable("Customer");
            dtCustomer.Columns.Add("CustomerId", typeof(Int32));
            dtCustomer.Columns.Add("Name", typeof(string));
            dtCustomer.Columns.Add("Street", typeof(string));
            dtCustomer.Columns.Add("City", typeof(string));
            dtCustomer.Columns.Add("PostalCode", typeof(string));
            dtCustomer.Columns.Add("PhoneNumber", typeof(string));
            dtCustomer.Columns.Add("FaxNumber", typeof(string));
            dtCustomer.Columns.Add("CreditLimit", typeof(float));
            dtCustomer.PrimaryKey = new DataColumn[] { dtCustomer.Columns["CustomerId"] };
            dshitechDB.Tables.Add(dtCustomer);
            da = new SqlDataAdapter("select * from customer", connDB);
            da.Fill(dshitechDB.Tables["Customer"]);
            dataGridView1.DataSource = dtCustomer;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection connDB = new SqlConnection("data source=(local)\\MSSQLSERVER01 ; database=HiTechDB ; Integrated Security = SSPI");
            int customerId = Convert.ToInt32(txtCustomerId.Text);
            string name = txtName.Text;
            string street = txtStreet.Text;
            string city = txtCity.Text;
            string postalCode = txtPostalCode.Text;
            string phoneNumber = txtPhone.Text;
            string faxNumber = txtFax.Text;
            float creditLimit = Convert.ToSingle(txtCreditLimit.Text);
            dtCustomer.Rows.Add(customerId, name, street, city, postalCode, phoneNumber, faxNumber, creditLimit);
            string que = string.Format("Insert into Customer values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6})", name, street, city, postalCode, phoneNumber, faxNumber, creditLimit);
            da.InsertCommand = new SqlCommand(que, connDB);
            da.Update(dshitechDB, "Customer");
            connDB.Close();
            ClearTextBox();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection connDB = new SqlConnection("data source=(local)\\MSSQLSERVER01 ; database=HiTechDB ; Integrated Security = SSPI");
            int customerId = Convert.ToInt32(txtCustomerId.Text);
            string name = txtName.Text;
            string street = txtStreet.Text;
            string city = txtCity.Text;
            string postalCode = txtPostalCode.Text;
            string phoneNumber = txtPhone.Text;
            string faxNumber = txtFax.Text;
            float creditLimit = Convert.ToSingle(txtCreditLimit.Text);
            DataRow drCustomer = dtCustomer.Rows.Find(customerId);
            drCustomer["Name"] = name;
            drCustomer["Street"] = street;
            drCustomer["City"] = city;
            drCustomer["PostalCode"] = postalCode;
            drCustomer["PhoneNumber"] = phoneNumber;
            drCustomer["FaxNumber"] = faxNumber;
            drCustomer["CreditLimit"] = creditLimit;
            //da = new SqlDataAdapter();
            string que = string.Format("update Customer set Name='{0}', Street='{1}', City='{2}', PostalCode='{3}', PhoneNumber='{4}', FaxNumber='{5}', CreditLimit='{6}' WHERE CustomerId={7}", name, street, city, postalCode, phoneNumber, faxNumber, creditLimit, customerId);
            da.UpdateCommand = new SqlCommand(que, connDB);
            da.Update(dshitechDB, "Customer");
            connDB.Close();
            ClearTextBox();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection connDB = new SqlConnection("data source=(local)\\MSSQLSERVER01 ; database=HiTechDB ; Integrated Security = SSPI");
            int customerId = Convert.ToInt32(txtCustomerId.Text);
            DataRow drCustomer = dtCustomer.Rows.Find(customerId);
            drCustomer.Delete();
            string que = "delete from Customer where CustomerId=" + customerId;
            da = new SqlDataAdapter();
            da.DeleteCommand = new SqlCommand(que, connDB);
            da.Update(dshitechDB, "Customer");
            connDB.Close();
            ClearTextBox();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection connDB = new SqlConnection("data source=(local)\\MSSQLSERVER01 ; database=HiTechDB ; Integrated Security = SSPI");
            string searchName = txtSearch.Text;
            DataTable newCustomerTable = new DataTable();
            DataTable dtCustomer2 = new DataTable();
            dtCustomer2 = dtCustomer.Copy();
            newCustomerTable = dtCustomer.Copy();
            newCustomerTable.Clear();
            if (dshitechDB.Tables.Contains("newCustomerTable") == false)
            {
                dshitechDB.Tables.Add("newCustomerTable");
            }
            foreach (DataRow row in dtCustomer2.Rows)
            {
                if (row["Name"].ToString() == searchName)
                {
                    newCustomerTable.ImportRow(row);
                }
            }
            string que = string.Format("select * from Customer where Name = '{0}'", searchName);
            da = new SqlDataAdapter(que, connDB);

            da.Fill(dshitechDB.Tables["newCustomerTable"]);
            dataGridView2.DataSource = newCustomerTable;
            connDB.Close();
            txtSearch.Text = string.Empty;
            ClearTextBox();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtCustomerId.Text = row.Cells["CustomerId"].Value.ToString();
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtStreet.Text = row.Cells["Street"].Value.ToString();
                txtCity.Text = row.Cells["City"].Value.ToString();
                txtPostalCode.Text = row.Cells["PostalCode"].Value.ToString();
                txtPhone.Text = row.Cells["PhoneNumber"].Value.ToString();
                txtFax.Text = row.Cells["FaxNumber"].Value.ToString();
                txtCreditLimit.Text = row.Cells["CreditLimit"].Value.ToString();
            }
        }

        

        /* private void ClearTextBox()
         {
             txtCustomerId.Text = string.Empty;
             txtStreet.Text = string.Empty;
             txtCity.Text = string.Empty;
             txtPostalCode.Text = string.Empty;
             txtPhone.Text = string.Empty;
             txtFax.Text = string.Empty;
             txtCreditLimit.Text = string.Empty;
         }

         private void btnAdd_Click(object sender, EventArgs e)
         {
             if (txtStreet.Text == "" || txtCity.Text == "" || txtPostalCode.Text == "" || txtPhone.Text == "" || txtFax.Text == "" || txtCreditLimit.Text == "")
             {
                 MessageBox.Show("Can not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             else
             {
                 Customer cust = new Customer();

                 //cust.CustomerId = Convert.ToInt32(txtCustomerId.Text);
                 cust.Street = txtStreet.Text;
                 cust.City = txtCity.Text;
                 cust.PostalCode = txtPostalCode.Text;
                 cust.PhoneNumber = txtPhone.Text;
                 cust.FaxNumber = txtFax.Text;
                 cust.CreditLimit = Convert.ToInt32(txtCreditLimit.Text);

                 if (cust.SaveCustomer(cust))
                     MessageBox.Show("Saved Correctly", "Confirmation");
                 else
                     MessageBox.Show("Customer can not be saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             ClearTextBox();
         }

         private void populateListView(DataTable data)
         {
             foreach (DataRow row in data.Rows)
             {
                 ListViewItem item = new ListViewItem(row[0].ToString());
                 for (int i = 1; i < data.Columns.Count; i++)
                 {
                     item.SubItems.Add(row[i].ToString());
                 }
                 listView1.Items.Add(item);
             }
         }

         private void btnUpdate_Click(object sender, EventArgs e)
         {
             if (txtStreet.Text == "" || txtCity.Text == "" || txtPostalCode.Text == "" || txtPhone.Text == "" || txtFax.Text == "" || txtCreditLimit.Text == "")
             {
                 MessageBox.Show("Customer can not be edited. You should Enter data!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             else
             {
                 Customer cust = new Customer();

                 cust.CustomerId = Convert.ToInt32(txtCustomerId.Text);
                 cust.Street = txtStreet.Text;
                 cust.City = txtCity.Text;
                 cust.PostalCode = txtPostalCode.Text;
                 cust.PhoneNumber = txtPhone.Text;
                 cust.FaxNumber = txtFax.Text;
                 cust.CreditLimit = Convert.ToInt32(txtCreditLimit.Text);

                 if (cust.UpdateCustomer(cust))
                     MessageBox.Show("Customer information has been updated successfully", "Confirmation");
                 else
                     MessageBox.Show("Customer can not be updated!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

             }
             ClearTextBox();
         }

         private void btnDelete_Click(object sender, EventArgs e)
         {
             if (txtStreet.Text == "" || txtCity.Text == "" || txtPostalCode.Text == "" || txtPhone.Text == "" || txtFax.Text == "" || txtCreditLimit.Text == "")
             {
                 MessageBox.Show("Customer can not be empty. You should Enter data!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             else
             {
                 Customer cust = new Customer();

                 cust.CustomerId = Convert.ToInt32(txtCustomerId.Text);
                 cust.Street = txtStreet.Text;
                 cust.City = txtCity.Text;
                 cust.PostalCode = txtPostalCode.Text;
                 cust.PhoneNumber = txtPhone.Text;
                 cust.FaxNumber = txtFax.Text;
                 cust.CreditLimit = Convert.ToInt32(txtCreditLimit.Text);

                 if (cust.DeleteCustomer(cust.CustomerId))
                 {
                     MessageBox.Show("Customer is deleted");
                 }
                 else
                 {
                     MessageBox.Show("Unable to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
                 ClearTextBox();
             }
         }

         private void btnShowCustomer_Click(object sender, EventArgs e)
         {
             Customer cust = new Customer();
             var data = cust.ListCustomers();
             if (listView1.Items.Count > 0)
             {
                 listView1.Items.Clear();
                 populateListView(data);
             }
             else
             {
                 populateListView(data);
             }
         }


         private void listView1_MouseClick(object sender, MouseEventArgs e)
         {
             if (listView1.SelectedItems.Count > 0)
             {
                 ListViewItem item = listView1.SelectedItems[0];
                 txtCustomerId.Text = item.SubItems[0].Text;
                 txtStreet.Text = item.SubItems[1].Text;
                 txtCity.Text = item.SubItems[2].Text;
                 txtPostalCode.Text = item.SubItems[3].Text;
                 txtPhone.Text = item.SubItems[4].Text;
                 txtFax.Text = item.SubItems[5].Text;
                 txtCreditLimit.Text = item.SubItems[6].Text;
             }
         }

         private void SalesManager_Load(object sender, EventArgs e)
         {
             listView1.FullRowSelect = Enabled;
         }*/
    }
}
