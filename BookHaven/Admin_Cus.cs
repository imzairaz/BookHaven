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
    public partial class Admin_Cus : Form
    {
        private string connectionString = @"Data Source=Zai\SQLEXPRESS;Initial Catalog=BookHeaven;Integrated Security=True";
        public Admin_Cus()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Admin_Customer_Load);
        }

        private void Admin_Customer_Load(object sender, EventArgs e)
        {
            LoadData();  // Load data into the DataGridView when the form loads
        }

        // Method to load customer data into the DataGridView
        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Customers"; // SQL Query to get all customers
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();

                    conn.Open();
                    adapter.Fill(dataTable);

                    dgvCustomer.DataSource = dataTable;  // Set the DataGridView's data source to the DataTable
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        // Method to add a new customer to the database
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Customers (Name, Email, Phone, Address) VALUES (@Name, @Email, @Phone, @Address)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Address", address);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer added successfully.");
                    LoadData();  // Refresh the DataGridView after adding a new customer
                    ClearFields();  // Clear the input fields
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // Method to update an existing customer
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.SelectedRows.Count > 0)
            {
                int customerId = Convert.ToInt32(dgvCustomer.SelectedRows[0].Cells[0].Value); // Get CustomerID from selected row
                string name = txtName.Text;
                string email = txtEmail.Text;
                string phone = txtPhone.Text;
                string address = txtAddress.Text;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Customers SET Name = @Name, Email = @Email, Phone = @Phone, Address = @Address WHERE CustomerID = @CustomerID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Customer updated successfully.");
                        LoadData();  // Refresh the DataGridView after updating
                        ClearFields();  // Clear the input fields
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to update.");
            }
        }

        // Method to delete an existing customer
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.SelectedRows.Count > 0)
            {
                int customerId = Convert.ToInt32(dgvCustomer.SelectedRows[0].Cells[0].Value); // Get CustomerID from selected row

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Customers WHERE CustomerID = @CustomerID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Customer deleted successfully.");
                        LoadData();  // Refresh the DataGridView after deleting
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.");
            }
        }

        // Method to search for customers based on name or email
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Customers WHERE Name LIKE @SearchQuery OR Email LIKE @SearchQuery";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@SearchQuery", "%" + searchQuery + "%");
                    DataTable dataTable = new DataTable();

                    conn.Open();
                    adapter.Fill(dataTable);

                    dgvCustomer.DataSource = dataTable;  // Display search results in DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching data: " + ex.Message);
            }
        }

        // Method to clear all the input fields
        private void ClearFields()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
        }

        // Event when a row is clicked in DataGridView to populate the input fields for editing
        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomer.Rows[e.RowIndex];
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
            }
        }

        // Event to load data when the form is loaded
        private void Admin_Customers_Load(object sender, EventArgs e)
        {
            LoadData();  // Populate DataGridView when form loads
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
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

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            Admin_Cus Obj = new Admin_Cus();
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

        private void btnBookOrder_Click(object sender, EventArgs e)
        {
            Admin_Restock Obj = new Admin_Restock();
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
    }
}
