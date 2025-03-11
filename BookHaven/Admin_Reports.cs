using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BookHaven
{
    public partial class Admin_Reports : Form
    {
        public Admin_Reports()
        {
            InitializeComponent();
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
    }
}
