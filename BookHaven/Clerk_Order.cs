using System;
using System.Windows.Forms;


namespace BookHaven
{
    public partial class Clerk_Order : Form
    {
        public Clerk_Order()
        {
            InitializeComponent();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            Clerk_Sale Obj = new Clerk_Sale();
            Obj.Show();
            this.Hide();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Clerk_Order Obj = new Clerk_Order();
            Obj.Show();
            this.Hide();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            Clerk_Home Obj = new Clerk_Home();
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
    }
}
