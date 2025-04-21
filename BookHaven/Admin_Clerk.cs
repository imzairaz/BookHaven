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
    public partial class Admin_Clerk : Form
    {
        private string connectionString = @"Data Source=Zai\SQLEXPRESS;Initial Catalog=BookHeaven;Integrated Security=True";

        public Admin_Clerk()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Admin_Clerk_Load);
            this.dgvClerk.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClerk_CellContentClick);
        }

        private void Admin_Clerk_Load(object sender, EventArgs e)
        {
            LoadStaffData();
        }

        private void LoadStaffData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    conn.Open();

                    // SQL query to fetch data for only 'Staff' role
                    string query = "SELECT UserID, Username, Email, Phone, Password, Role FROM Users WHERE Role = 'Staff'";

                    // Create the SqlDataAdapter
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);

                    // Create a DataTable to hold the fetched data
                    DataTable dataTable = new DataTable();

                    // Fill the DataTable with data from the database
                    dataAdapter.Fill(dataTable);

                    // Set the DataGridView's DataSource to the DataTable
                    dgvClerk.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading the data: " + ex.Message);
                }
            }
        }

        private void dgvClerk_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow row = dgvClerk.Rows[e.RowIndex];

                // Fill the textboxes and ComboBox with the selected row data
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString(); // Ideally, do not show passwords in plain text
                cmbRole.SelectedItem = row.Cells["Role"].Value.ToString();
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "INSERT INTO Users (Username, Email, Phone, Password, Role) " +
                                   "VALUES (@Username, @Email, @Phone, @Password, @Role)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text); // Remember to hash passwords in production
                    cmd.Parameters.AddWithValue("@Role", cmbRole.SelectedItem.ToString());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User added successfully!");

                    // Reload staff data after adding a new user
                    LoadStaffData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while adding the user: " + ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvClerk.SelectedRows.Count > 0)
            {
                int userID = Convert.ToInt32(dgvClerk.SelectedRows[0].Cells["UserID"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        string query = "UPDATE Users SET Username = @Username, Email = @Email, Phone = @Phone, Password = @Password, Role = @Role " +
                                       "WHERE UserID = @UserID";

                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text); // Remember to hash passwords in production
                        cmd.Parameters.AddWithValue("@Role", cmbRole.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@UserID", userID);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("User updated successfully!");

                        // Reload staff data after updating a user
                        LoadStaffData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while updating the user: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a user to update.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvClerk.SelectedRows.Count > 0)
            {
                int userID = Convert.ToInt32(dgvClerk.SelectedRows[0].Cells["UserID"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        string query = "DELETE FROM Users WHERE UserID = @UserID";

                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@UserID", userID);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("User deleted successfully!");

                        // Reload staff data after deleting a user
                        LoadStaffData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while deleting the user: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStaffData();
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
