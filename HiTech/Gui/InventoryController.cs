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
    public partial class Inventory_Controller : Form
    {
        public Inventory_Controller()
        {
            InitializeComponent();
        }

        private void ClearTextBox()
        {
            txtIsbn.Text = string.Empty;
            txtTitle.Text = string.Empty;
            txtAuthorId.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtYear.Text = string.Empty;
            txtQOH.Text = string.Empty;
            txtCategoryId.Text = string.Empty;
            txtSearch.Text = string.Empty;
            txtPublisherId.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            HiTechDBEntities4 hitech = new HiTechDBEntities4();
            Book book1 = new Book();
            int bookIsbn = Convert.ToInt32(txtIsbn.Text);
            Book book2 = hitech.Books.Find(bookIsbn);
            if (book2 != null)
            {
                MessageBox.Show("Duplicated Id", "Error");
                ClearTextBox();
                return;
            }

            book1.Isbn = Convert.ToInt32(txtIsbn.Text.Trim());
            book1.Title = txtTitle.Text;
            book1.UnitPrice = Convert.ToDouble(txtPrice.Text);
            book1.Year = Convert.ToInt32(txtYear.Text);
            book1.QOH = Convert.ToInt32(txtQOH.Text);
            book1.CategoryId = Convert.ToInt32(txtCategoryId.Text);
            book1.AuthorId = Convert.ToInt32(txtAuthorId.Text);
            book1.PublisherId = Convert.ToInt32(txtPublisherId.Text);
            hitech.Books.Add(book1);
            hitech.SaveChanges();
            MessageBox.Show("Book saved sucessfully");
            ClearTextBox();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            HiTechDBEntities4 hitech = new HiTechDBEntities4();


            var booksList = from book in hitech.Books
                            select book;

            if (booksList != null)
            {
                listView1.Items.Clear();

                foreach (var book in booksList)
                {

                    ListViewItem item = new ListViewItem(Convert.ToString(book.Isbn));
                    item.SubItems.Add(book.Title);
                    item.SubItems.Add(Convert.ToString(book.UnitPrice));
                    item.SubItems.Add(Convert.ToString(book.Year));
                    item.SubItems.Add(Convert.ToString(book.QOH));
                    item.SubItems.Add(Convert.ToString(book.CategoryId));
                    item.SubItems.Add(Convert.ToString(book.AuthorId));
                    item.SubItems.Add(Convert.ToString(book.PublisherId));
                    listView1.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("No books listed!");
            }
        }

        private void Inventory_Controller_Load(object sender, EventArgs e)
        {
            listView1.FullRowSelect = true;
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                txtIsbn.Text = item.SubItems[0].Text;
                txtTitle.Text = item.SubItems[1].Text;
                txtPrice.Text = item.SubItems[2].Text;
                txtYear.Text = item.SubItems[3].Text;
                txtQOH.Text = item.SubItems[4].Text;
                txtCategoryId.Text = item.SubItems[5].Text;
                txtAuthorId.Text = item.SubItems[6].Text;
                txtPublisherId.Text = item.SubItems[7].Text;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            HiTechDBEntities4 hitech = new HiTechDBEntities4();

            int ISBN = Convert.ToInt32(txtIsbn.Text);
            var book = hitech.Books.Find(ISBN);
            if (book == null)
            {
                MessageBox.Show("Book does not exist", "Error");
                return;
            }
            hitech.Books.Remove(book);
            hitech.SaveChanges();

            MessageBox.Show("Book removed sucessfully");
            ClearTextBox();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            HiTechDBEntities4 hitech = new HiTechDBEntities4();

            Book book = new Book();

            int ISBN = Convert.ToInt32(txtIsbn.Text);
            book = hitech.Books.Find(ISBN);

            if (book == null)
            {
                MessageBox.Show("Book does not exist", "Error");
                return;
            }

            book.Isbn = Convert.ToInt32(txtIsbn.Text);
            book.Title = txtTitle.Text;
            book.UnitPrice = Convert.ToDouble(txtPrice.Text);
            book.Year = Convert.ToInt32(txtYear.Text);
            book.QOH = Convert.ToInt32(txtQOH.Text);
            book.CategoryId = Convert.ToInt32(txtCategoryId.Text);
            book.AuthorId = Convert.ToInt32(txtAuthorId.Text);
            book.PublisherId = Convert.ToInt32(txtPublisherId.Text);


            hitech.SaveChanges();

            MessageBox.Show("Book saved sucessfully");
            ClearTextBox();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            HiTechDBEntities4 hitech = new HiTechDBEntities4();

            int ISBN = Convert.ToInt32(txtSearch.Text);
            var book = hitech.Books.Find(ISBN);

            if (book == null)
            {
                MessageBox.Show("Book does not exist", "Error");
                return;
            }

            var myBookList = from book1 in hitech.Books
                             where book1.Isbn == ISBN
                             select book1;
            listView1.Items.Clear();

            foreach (var book1 in myBookList)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(book1.Isbn));
                item.SubItems.Add(book1.Title);
                item.SubItems.Add(Convert.ToString(book1.UnitPrice));
                item.SubItems.Add(Convert.ToString(book1.Year));
                item.SubItems.Add(Convert.ToString(book1.QOH));
                item.SubItems.Add(Convert.ToString(book1.CategoryId));
                item.SubItems.Add(Convert.ToString(book1.AuthorId));
                item.SubItems.Add(Convert.ToString(book1.PublisherId));
                listView1.Items.Add(item);
            }
        }
    }
}
        /*
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text == "" || txtAuthorId.Text == "" || txtPrice.Text == "" || txtYear.Text == "" || txtQOH.Text == "" || txtCategoryId.Text == "")
            {
                MessageBox.Show("Can not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Book book = new Book();
                //book.Isbn = Convert.ToInt32(txtIsbn.Text);
                book.Title = txtTitle.Text;
                book.AuthorId = Convert.ToInt32(txtAuthorId.Text);
                book.UnitPrice = Convert.ToSingle(txtPrice.Text);
                book.Year = Convert.ToInt32(txtYear.Text);
                book.Qoh = Convert.ToInt32(txtQOH.Text);
                book.CategoryId = Convert.ToInt32(txtCategoryId.Text);
           
                if (book.SaveBook(book))
                    MessageBox.Show("Saved Correctly", "Confirmation");
                else
                    MessageBox.Show("Book can not be saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ClearTextBox();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text == "" || txtAuthorId.Text == "" || txtPrice.Text == "" || txtYear.Text == "" || txtQOH.Text == "" || txtCategoryId.Text == "")
            {
                    MessageBox.Show("Book can not be edited. You should Enter data!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Book book = new Book();
                    book.Title = txtTitle.Text;
                    book.AuthorId = Convert.ToInt32(txtAuthorId.Text);
                    book.UnitPrice = Convert.ToSingle(txtPrice.Text);
                    book.Year = Convert.ToInt32(txtYear.Text);
                    book.Qoh = Convert.ToInt32(txtQOH.Text);
                    book.CategoryId = Convert.ToInt32(txtCategoryId.Text);

                if (book.UpdateBook(book))
                       

                        MessageBox.Show("Book information has been updated successfully", "Confirmation");
                    
                    else
                        MessageBox.Show("Book can not be updated!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                ClearTextBox();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text == "" || txtAuthorId.Text == "" || txtPrice.Text == "" || txtYear.Text == "" || txtQOH.Text == "" || txtCategoryId.Text == "")
            {
                MessageBox.Show("Book can not be empty. You should Enter data!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Book book = new Book();
                book.Isbn = Convert.ToInt32(txtIsbn.Text);
                book.Title = txtTitle.Text;
                book.AuthorId = Convert.ToInt32(txtAuthorId.Text);
                book.UnitPrice = Convert.ToSingle(txtPrice.Text);
                book.Year = Convert.ToInt32(txtYear.Text);
                book.Qoh = Convert.ToInt32(txtQOH.Text);
                book.CategoryId = Convert.ToInt32(txtCategoryId.Text);

                if (book.DeleteBook(book.Isbn))
                {
                    MessageBox.Show("Book is deleted");
                }
                else
                {
                    MessageBox.Show("Unable to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ClearTextBox();
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
                Book book = new Book();
                book.Title = txtSearch.Text;
                int bookId = book.SearchBook(book.Title);

                if (bookId > 0)
                {
                    MessageBox.Show("ISBN is: " + bookId);
                }
                else
                {
                    MessageBox.Show("Can not be found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            ClearTextBox();
        }

        private void Inventory_Controller_Load(object sender, EventArgs e)
        {
            listView1.FullRowSelect = Enabled;
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

        private void btnShow_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            var data = book.ListBook();
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
                txtIsbn.Text = item.SubItems[0].Text;
                txtTitle.Text = item.SubItems[1].Text;
                txtAuthorId.Text = item.SubItems[2].Text;
                txtPrice.Text = item.SubItems[3].Text;
                txtYear.Text = item.SubItems[4].Text;
                txtQOH.Text = item.SubItems[5].Text;
                txtCategoryId.Text = item.SubItems[6].Text;
            }
        }*/

