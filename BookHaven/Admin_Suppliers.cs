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
    public partial class Admin_Suppliers : Form
    {
        private string connectionString = @"Data Source=Zai\SQLEXPRESS;Initial Catalog=BookHeaven;Integrated Security=True";

        public Admin_Suppliers()
        {
            InitializeComponent();
            // In your Admin_Supplier.Designer.cs file, ensure this line is present:
            this.Load += new System.EventHandler(this.Admin_Suppliers_Load);
            this.dgvSupplier.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSupplier_CellContentClick);
        }

        private void Admin_Suppliers_Load(object sender, EventArgs e)
        {
            LoadData();  // Populate the DataGridView with data
        }

        // Method to load data into the DataGridView
        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT SupplierID, Name, Email, Phone FROM Suppliers"; // Adjust the SELECT query to match the columns
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();

                    conn.Open();
                    adapter.Fill(dataTable);

                    // Bind data to DataGridView
                    dgvSupplier.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        // Method to clear textboxes (for adding a new Supplier)
        private void ClearFields()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
        }

        // Button to save a new Supplier
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Suppliers (Name, Email, Phone) VALUES (@Name, @Email, @Phone)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Phone", phone);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Supplier added successfully.");
                    LoadData();  // Refresh DataGridView
                    ClearFields(); // Clear textboxes after saving
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // Button to update an existing Supplier
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvSupplier.SelectedRows.Count > 0)
            {
                int supplierID = Convert.ToInt32(dgvSupplier.SelectedRows[0].Cells[0].Value);
                string name = txtName.Text;
                string email = txtEmail.Text;
                string phone = txtPhone.Text;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Suppliers SET Name = @Name, Email = @Email, Phone = @Phone WHERE SupplierID = @SupplierID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@SupplierID", supplierID);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Supplier updated successfully.");
                        LoadData();  // Refresh DataGridView
                        ClearFields(); // Clear textboxes after updating
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a Supplier to update.");
            }
        }

        // Button to delete a Supplier
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSupplier.SelectedRows.Count > 0)
            {
                int supplierID = Convert.ToInt32(dgvSupplier.SelectedRows[0].Cells[0].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Suppliers WHERE SupplierID = @SupplierID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SupplierID", supplierID);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Supplier deleted successfully.");
                        LoadData();  // Refresh DataGridView
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a Supplier to delete.");
            }
        }

        // Button to refresh DataGridView
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();  // Reload data
        }

        private void dgvSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSupplier.Rows[e.RowIndex];
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
            }
        }

        private void btnDash_Click(object sender, EventArgs e)
        {
            Admin_Books Obj = new Admin_Books();
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
