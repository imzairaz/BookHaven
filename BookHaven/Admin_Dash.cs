using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BookHaven
{
    public partial class Admin_Dash : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=Zai\SQLEXPRESS;Initial Catalog=BookHeaven;Integrated Security=True");
        public Admin_Dash()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Admin_Dash_Load);
        }

        private void TotalCustomer()
        {
            Con.Open();
            // Use COUNT(*) to get the total number of customers
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Customers", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            // Set the label's text to the count value
            lblCustomers.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void TotalBooks()
        {
            Con.Open();
            // Use COUNT(*) to get the total number of customers
            SqlDataAdapter sda = new SqlDataAdapter("SELECT SUM(Stock) FROM Books", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            // Set the label's text to the count value
            lblBooks.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void TotalSales()
        {
            Con.Open();
            // Use COUNT(*) to get the total number of customers
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Sales", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            // Set the label's text to the count value
            lblSales.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void TotalOrders()
        {
            Con.Open();
            // Use COUNT(*) to get the total number of customers
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Orders", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            // Set the label's text to the count value
            lblOrders.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void Admin_Dash_Load(Object sender, EventArgs e)
        {
            TotalCustomer();
            TotalBooks();
            TotalSales();
            TotalOrders();
        }

        private void btnDash_Click(object sender, EventArgs e)
        {
            Admin_Dash Obj = new Admin_Dash();
            Obj.Show();
            this.Hide();
        }

        private void btnClerk_Click(object sender, EventArgs e)
        {
            Admin_Clerk Obj = new Admin_Clerk();
            Obj.Show();
            this.Hide();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            Admin_Suppliers Obj = new Admin_Suppliers();
            Obj.Show();
            this.Hide();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            Admin_Books Obj = new Admin_Books();
            Obj.Show();
            this.Hide();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Admin_Reports Obj = new Admin_Reports();
            Obj.Show();
            this.Hide();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Admin_Settings Obj = new Admin_Settings();
            Obj.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBookOrder_Click(object sender, EventArgs e)
        {
            Admin_Restock Obj = new Admin_Restock();
            Obj.Show();
            this.Hide();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            Admin_Cus Obj = new Admin_Cus();
            Obj.Show();
            this.Hide();
        }
    }
}
