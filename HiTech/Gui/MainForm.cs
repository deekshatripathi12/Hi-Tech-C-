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
//using HiTech.DataAccess;
using System.Data.SqlClient;


namespace HiTech.Gui
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ClearTextBox()
        {
            txtUserId.Text = string.Empty;
            txtFn.Text = string.Empty;
            txtLn.Text = string.Empty;
            txtJobId.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtSearch.Text = string.Empty;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtFn.Text == "" || txtLn.Text == "" || txtUserName.Text == "" || txtPassword.Text == "" || txtJobId.Text == "")
            {
                MessageBox.Show("Can not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                User user = new User();
                user.FirstName = txtFn.Text;
                user.LastName = txtLn.Text;
                user.Username = txtUserName.Text;
                user.Password = txtPassword.Text;
                user.JobId = Convert.ToInt32(txtJobId.Text);

                if (user.SaveUser(user))
                    MessageBox.Show("Saved Correctly", "Confirmation");
                else
                    MessageBox.Show("Employee can not be saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ClearTextBox();
            //if (txtFn.Text == "" || txtLn.Text == "" || txtJobId.Text == "" || txtUserName.Text == "" || txtPassword.Text == "")
            //{
            //    MessageBox.Show("Can not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
            //    User user = new User();
            //    user.FirstName = txtFn.Text;
            //    user.LastName = txtLn.Text;
            //    //user.EmployeeId = Convert.ToInt16(txtUserId.Text);
            //    user.JobId = Convert.ToInt16(txtJobId.Text);
            //    user.Username = txtUserName.Text;
            //    user.Password = txtPassword.Text;

            //    if (user.SaveUser(user))
            //    {
            //        MessageBox.Show("Saved Correctly", "Confirmation");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Employee/User can not be saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    ClearTextBox();
            //}
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtFn.Text == "" || txtLn.Text == "" || txtUserName.Text == "" || txtPassword.Text == "" || txtJobId.Text == "")
            {
                MessageBox.Show("Employee/User can not be edited. You should Enter data!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
            else
            {
                User user = new User();
      
                user.FirstName = txtFn.Text;
                user.LastName = txtLn.Text;
                user.JobId = Convert.ToInt16(txtJobId.Text);
                user.Username = txtUserName.Text;
                user.Password = txtPassword.Text;

                if (user.UpdateUser(user))
                //{
                    //User user1 = new User();
                    //var data = user1.ListUsers();
                    //if (listView1.Items.Count > 0)
                    //{
                    //    listView1.Items.Clear();
                    //    populateListView(data);
                    //}
                    //else
                    //{
                    //    populateListView(data);
                    //}

                    MessageBox.Show("Employee/User information has been updated successfully", "Confirmation");
                //}
                else
                    MessageBox.Show("Employee/User can not be updated!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      
            }
            ClearTextBox();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtFn.Text == "" || txtLn.Text == "" || txtJobId.Text == "" || txtUserName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Employee/User can not be empty. You should Enter data!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                User user = new User();
                user.EmployeeId = Convert.ToInt16(txtUserId.Text);
                user.FirstName = txtFn.Text;
                user.LastName = txtLn.Text;
                user.JobId = Convert.ToInt16(txtJobId.Text);
                user.Username = txtUserName.Text;
                user.Password = txtPassword.Text;

                if (user.DeleteUser(user.EmployeeId))
                {
                    MessageBox.Show("User is deleted");
                }
                else
                {
                    MessageBox.Show("Unable to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ClearTextBox();
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            User user = new User();
            var data = user.ListUsers();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                MessageBox.Show("Can not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                User user = new User();
                user.FirstName = txtSearch.Text;
                int userId = user.SearchUser(user.FirstName);

                if (userId > 0)
                {
                    MessageBox.Show("Employee / user ID is: " + userId);
                }
                else
                {
                    MessageBox.Show("Can not be found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            ClearTextBox();

        }
    

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                txtUserId.Text = item.SubItems[0].Text;
                txtFn.Text = item.SubItems[1].Text;
                txtLn.Text = item.SubItems[2].Text;
                txtJobId.Text = item.SubItems[3].Text;
                txtUserName.Text = item.SubItems[4].Text;
                txtPassword.Text = item.SubItems[5].Text;
            }

        }

        

        private void MainForm_Load(object sender, EventArgs e)
        {
            listView1.FullRowSelect = Enabled;
        }
    }
}
