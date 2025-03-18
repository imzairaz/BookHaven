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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection Con = DatabaseHelper.GetConnection();

        private void Login_Load(object sender, EventArgs e)
        {
            // Populate the ComboBox with roles
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Staff");

            // Set a default selected item
            cmbRole.SelectedIndex = 0;  // Default to "Admin"
        }

        private bool ValidateLogin(string username, string password, string role)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password AND Role = @Role";

            using (SqlConnection conn = DatabaseHelper.GetConnection()) // Use centralized connection
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);  // TO DO: Replace with hashed password storage
                cmd.Parameters.AddWithValue("@Role", role);

                try
                {
                    conn.Open();
                    int userCount = (int)cmd.ExecuteScalar();
                    return userCount > 0;  // If a match is found, return true
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            } // Connection automatically closes here
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string role = cmbRole.SelectedItem.ToString();

            // Validation check
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // validate the login (using database)
            bool isValid = ValidateLogin(username, password, role);

            if (isValid)
            {
                // If login is successful, redirect based on role
                if (role == "Admin")
                {
                    Admin_Dash adminHome = new Admin_Dash();  // Open the Admin Home form
                    adminHome.Show();
                }
                else if (role == "Staff")
                {
                    Clerk_Sale clerkPOS = new Clerk_Sale();  // Open the Sales Clerk Home form
                    clerkPOS.Show();
                }

                // Hide the login form after successful login
                this.Hide();
            }
            else
            {
                // If login fails, show an error message
                MessageBox.Show("Invalid username, password, or role.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
