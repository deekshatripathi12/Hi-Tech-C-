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
    public partial class OrderClerk : Form
    {
        public OrderClerk()
        {
            InitializeComponent();
        }

        private void ClearTextBox()
        {
            txtCustomerId.Text = string.Empty;
            txtIsbn.Text = string.Empty;
            txtQty.Text = string.Empty;
            //txtOrderId = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            HiTechDBEntities4 hitech = new HiTechDBEntities4();

            Order order = new Order();

            int customerId = Convert.ToInt32(txtCustomerId.Text);
            Order order1 = hitech.Orders.Find(customerId);

            if (order1 != null)
            {
                MessageBox.Show("Duplicated Employee Id", "Error");
                ClearTextBox();
                return;
            }

            order.CustomerId = customerId;
            order.Isbn = Convert.ToInt32(txtIsbn.Text);
            Book book = hitech.Books.Find(order.Isbn);
            order.Quantity = Convert.ToInt32(txtQty.Text);
            order.Total = book.UnitPrice * order.Quantity;
            order.OrderedBy = Convert.ToString(comboOrderedBy.SelectedItem);

            hitech.Orders.Add(order);
            hitech.SaveChanges();
            MessageBox.Show("Order saved");

            string bookName = book.Title;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            HiTechDBEntities4 hitech = new HiTechDBEntities4();
            Order order = new Order();
            int orderId = Convert.ToInt32(txtOrderId.Text);
            order = hitech.Orders.Find(orderId);
            if (order == null)
            {
                MessageBox.Show("Order does not exists", "Error");
                return;
            }

            order.CustomerId = Convert.ToInt32(txtCustomerId.Text);
            order.Isbn = Convert.ToInt32(txtIsbn.Text);
            order.OrderedBy = Convert.ToString(comboOrderedBy.SelectedItem);
            order.Quantity = Convert.ToInt32(txtQty.Text);
            Book book = hitech.Books.Find(order.Isbn);
            order.Total = book.UnitPrice * order.Quantity;
            hitech.SaveChanges();
            MessageBox.Show("Order updated sucessfully");
            ClearTextBox();
        }

        private void btnShowBooks_Click(object sender, EventArgs e)
        {
            HiTechDBEntities4 hitech = new HiTechDBEntities4();

            var orderList = from order in hitech.Orders
                            select order;

            listView1.Items.Clear();
            foreach (var order in orderList)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(order.CustomerId));
                item.SubItems.Add(Convert.ToString(order.OrderId));
                item.SubItems.Add(Convert.ToString(order.Isbn));
                item.SubItems.Add(Convert.ToString(order.Quantity));
                item.SubItems.Add(order.OrderedBy);
                item.SubItems.Add(Convert.ToString(order.Total));
                listView1.Items.Add(item);
            }
        }

        private void OrderClerk_Load(object sender, EventArgs e)
        {
            listView1.FullRowSelect = true;
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                txtCustomerId.Text = item.SubItems[0].Text.Trim();
                txtOrderId.Text = item.SubItems[1].Text.Trim();
                txtIsbn.Text = item.SubItems[2].Text.Trim();
                txtQty.Text = item.SubItems[3].Text.Trim();
                comboOrderedBy.Text = item.SubItems[4].Text.Trim();
                
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            HiTechDBEntities4 hitech = new HiTechDBEntities4();
            Order order = new Order();
            int orderId = Convert.ToInt32(txtOrderId.Text);
            order = hitech.Orders.Find(orderId);
            if (order == null)
            {
                MessageBox.Show("Order does not exists", "Error");
                return;
            }
            hitech.Orders.Remove(order);
            hitech.SaveChanges();
            MessageBox.Show("Order removed successfully");
            ClearTextBox();
        }

        private void btnSearchByCID_Click(object sender, EventArgs e)
        {
            HiTechDBEntities4 hitech = new HiTechDBEntities4();
            int customerId = Convert.ToInt32(txtSearchByCustID.Text);
            var orderList = hitech.Orders.Where(x => x.CustomerId == customerId).ToList<Order>();
            if (orderList.Count != 0)
            {
                listView1.Items.Clear();
                foreach (var order in orderList)
                {
                    ListViewItem item = new ListViewItem(Convert.ToString(order.CustomerId));
                    item.SubItems.Add(Convert.ToString(order.OrderId));
                    item.SubItems.Add(Convert.ToString(order.Isbn));
                    item.SubItems.Add(Convert.ToString(order.Quantity));
                    item.SubItems.Add(order.OrderedBy);
                    item.SubItems.Add(Convert.ToString(order.Total));
                    listView1.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Custmer does not have orders", "Error");
            }
        }

        private void btnSearchOrder_Click(object sender, EventArgs e)
        {
            HiTechDBEntities4 hitech = new HiTechDBEntities4();

            int orderId = Convert.ToInt32(txtSearchByOrderID.Text);

            var orderList = from order in hitech.Orders
                            where order.OrderId == orderId
                            select order
                            ;

            listView1.Items.Clear();
            if (orderList != null)
            {
                foreach (var order in orderList)
                {
                    ListViewItem item = new ListViewItem(Convert.ToString(order.CustomerId));
                    item.SubItems.Add(Convert.ToString(order.OrderId));
                    item.SubItems.Add(Convert.ToString(order.Isbn));
                    item.SubItems.Add(Convert.ToString(order.Quantity));
                    item.SubItems.Add(order.OrderedBy);
                    item.SubItems.Add(Convert.ToString(order.Total));
                    listView1.Items.Add(item);
                }
            }
            if (orderList == null)
            {
                MessageBox.Show("Order does not exist", "Error");
            }
        }
    }
}
