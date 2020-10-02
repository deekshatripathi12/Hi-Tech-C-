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
    public partial class Accountant : Form
    {
        public Accountant()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            HiTechDBEntities4 hitech = new HiTechDBEntities4();
            int customerId = Convert.ToInt32(txtCustomerId.Text);

            var totals = from order in hitech.Orders
                         where order.CustomerId == customerId
                         group order by order.CustomerId into g
                         select g.Sum(p => p.Total);


            Customer customer = new Customer();
            customer.CustomerId = customerId;
            string customerName = customer.SearchCustomer(customer);

            listView1.Items.Clear();
            foreach (var total in totals)
            {

                ListViewItem item = new ListViewItem(Convert.ToString(customerName));
                item.SubItems.Add(Convert.ToString("CAD " + total));
                

                listView1.Items.Add(item);
            }
        }
    }
}
