namespace HiTech.Gui
{
    partial class OrderClerk
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnShowBooks = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtIsbn = new System.Windows.Forms.TextBox();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Street = new System.Windows.Forms.Label();
            this.comboOrderedBy = new System.Windows.Forms.ComboBox();
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearchOrder = new System.Windows.Forms.Button();
            this.txtSearchByOrderID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSearchByCID = new System.Windows.Forms.Button();
            this.txtSearchByCustID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader6});
            this.listView1.Location = new System.Drawing.Point(12, 281);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(723, 175);
            this.listView1.TabIndex = 103;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "CustomerId";
            this.columnHeader4.Width = 105;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "OrderID";
            this.columnHeader5.Width = 89;
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 3;
            this.columnHeader1.Text = "ISBN";
            this.columnHeader1.Width = 88;
            // 
            // columnHeader6
            // 
            this.columnHeader6.DisplayIndex = 2;
            this.columnHeader6.Text = "Qty";
            this.columnHeader6.Width = 85;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 100;
            this.label4.Text = "Ordered By";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 33);
            this.label3.TabIndex = 99;
            this.label3.Text = "Order Clerk";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(119, 189);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(296, 22);
            this.txtQty.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 98;
            this.label2.Text = "Quantity";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(454, 85);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 92;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnShowBooks
            // 
            this.btnShowBooks.Location = new System.Drawing.Point(454, 196);
            this.btnShowBooks.Name = "btnShowBooks";
            this.btnShowBooks.Size = new System.Drawing.Size(75, 23);
            this.btnShowBooks.TabIndex = 95;
            this.btnShowBooks.Text = "List";
            this.btnShowBooks.UseVisualStyleBackColor = true;
            this.btnShowBooks.Click += new System.EventHandler(this.btnShowBooks_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(454, 158);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 94;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(454, 121);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 93;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtIsbn
            // 
            this.txtIsbn.Location = new System.Drawing.Point(119, 152);
            this.txtIsbn.Name = "txtIsbn";
            this.txtIsbn.Size = new System.Drawing.Size(296, 22);
            this.txtIsbn.TabIndex = 3;
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(119, 111);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(137, 22);
            this.txtCustomerId.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 96;
            this.label1.Text = "Customer Id";
            // 
            // Street
            // 
            this.Street.AutoSize = true;
            this.Street.Location = new System.Drawing.Point(12, 154);
            this.Street.Name = "Street";
            this.Street.Size = new System.Drawing.Size(74, 16);
            this.Street.TabIndex = 97;
            this.Street.Text = "Book ISBN";
            // 
            // comboOrderedBy
            // 
            this.comboOrderedBy.FormattingEnabled = true;
            this.comboOrderedBy.Items.AddRange(new object[] {
            "Phone",
            "Fax",
            "Email"});
            this.comboOrderedBy.Location = new System.Drawing.Point(119, 229);
            this.comboOrderedBy.Name = "comboOrderedBy";
            this.comboOrderedBy.Size = new System.Drawing.Size(121, 24);
            this.comboOrderedBy.TabIndex = 5;
            // 
            // txtOrderId
            // 
            this.txtOrderId.Location = new System.Drawing.Point(119, 70);
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.Size = new System.Drawing.Size(137, 22);
            this.txtOrderId.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 106;
            this.label5.Text = "Order Id";
            // 
            // btnSearchOrder
            // 
            this.btnSearchOrder.Location = new System.Drawing.Point(575, 230);
            this.btnSearchOrder.Name = "btnSearchOrder";
            this.btnSearchOrder.Size = new System.Drawing.Size(75, 23);
            this.btnSearchOrder.TabIndex = 112;
            this.btnSearchOrder.Text = "Search";
            this.btnSearchOrder.UseVisualStyleBackColor = true;
            this.btnSearchOrder.Click += new System.EventHandler(this.btnSearchOrder_Click);
            // 
            // txtSearchByOrderID
            // 
            this.txtSearchByOrderID.Location = new System.Drawing.Point(575, 193);
            this.txtSearchByOrderID.Name = "txtSearchByOrderID";
            this.txtSearchByOrderID.Size = new System.Drawing.Size(143, 22);
            this.txtSearchByOrderID.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(572, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 16);
            this.label7.TabIndex = 110;
            this.label7.Text = "Search By Order ID";
            // 
            // btnSearchByCID
            // 
            this.btnSearchByCID.Location = new System.Drawing.Point(575, 111);
            this.btnSearchByCID.Name = "btnSearchByCID";
            this.btnSearchByCID.Size = new System.Drawing.Size(75, 23);
            this.btnSearchByCID.TabIndex = 109;
            this.btnSearchByCID.Text = "Search";
            this.btnSearchByCID.UseVisualStyleBackColor = true;
            this.btnSearchByCID.Click += new System.EventHandler(this.btnSearchByCID_Click);
            // 
            // txtSearchByCustID
            // 
            this.txtSearchByCustID.Location = new System.Drawing.Point(575, 74);
            this.txtSearchByCustID.Name = "txtSearchByCustID";
            this.txtSearchByCustID.Size = new System.Drawing.Size(143, 22);
            this.txtSearchByCustID.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(572, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 16);
            this.label6.TabIndex = 107;
            this.label6.Text = "Search By Customer ID";
            // 
            // OrderClerk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 459);
            this.Controls.Add(this.btnSearchOrder);
            this.Controls.Add(this.txtSearchByOrderID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSearchByCID);
            this.Controls.Add(this.txtSearchByCustID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtOrderId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboOrderedBy);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnShowBooks);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtIsbn);
            this.Controls.Add(this.Street);
            this.Controls.Add(this.txtCustomerId);
            this.Controls.Add(this.label1);
            this.Name = "OrderClerk";
            this.Text = "OrderClerk";
            this.Load += new System.EventHandler(this.OrderClerk_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnShowBooks;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtIsbn;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Street;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ComboBox comboOrderedBy;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearchOrder;
        private System.Windows.Forms.TextBox txtSearchByOrderID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSearchByCID;
        private System.Windows.Forms.TextBox txtSearchByCustID;
        private System.Windows.Forms.Label label6;
    }
}