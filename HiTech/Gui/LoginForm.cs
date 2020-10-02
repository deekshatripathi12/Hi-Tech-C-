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

namespace HiTech.Gui
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "" || txtUser.Text == "")
            {
                MessageBox.Show("Can not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                User user = new User();
                user.Username = txtUser.Text;
                user.Password = txtPassword.Text;
                int count = user.Login(user);

                if (count == 10)
                {
                    MainForm mainform = new MainForm();
                    this.Hide();
                    mainform.Show();
                }

                else if (count == 11)
                {
                    SalesManager mainform = new SalesManager();
                    this.Hide();
                    mainform.Show();
                }

                else if (count == 12)
                {
                    OrderClerk mainform = new OrderClerk();
                    this.Hide();
                    mainform.Show();
                }

                else if (count == 13)
                {
                    Accountant mainform = new Accountant();
                    this.Hide();
                    mainform.Show();
                }

                else if (count == 14)
                {
                    Inventory_Controller mainform = new Inventory_Controller();
                    this.Hide();
                    mainform.Show();
                }

                else
                {
                    MessageBox.Show("Can not Login, please contact the administrator", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
                
            }
        }

        
    }
}
