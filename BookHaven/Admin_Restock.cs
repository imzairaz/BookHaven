using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BookHaven
{
    public partial class Admin_Restock : Form
    {
        private string connectionString = @"Data Source=Zai\SQLEXPRESS;Initial Catalog=BookHeaven;Integrated Security=True";

        public Admin_Restock()
        {
            InitializeComponent();
            // Hook up the Form Load event
            this.Load += new EventHandler(this.Form1_Load);
            this.Load += new System.EventHandler(this.RestockOrderForm_Load);

        }

        private void RestockOrderForm_Load(object sender, EventArgs e)
        {
            RefreshOrders();
        }

        private void btnReceived_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to mark as received.");
                return;
            }

            // Get the selected row and ensure that the RestockID value is not null
            var selectedRow = dgvOrders.SelectedRows[0];
            if (selectedRow.Cells["RestockID"].Value == DBNull.Value || selectedRow.Cells["RestockID"].Value == null)
            {
                MessageBox.Show("Selected row does not have a valid RestockID.");
                return;
            }

            // Safely access the RestockID
            int restockID = Convert.ToInt32(selectedRow.Cells["RestockID"].Value);

            string query = "BEGIN TRANSACTION; " +
                           "UPDATE InventoryRestock SET Status = 'Received' WHERE RestockID = @RestockID; " +
                           "UPDATE Books SET Stock = Stock + (SELECT Quantity FROM InventoryRestock WHERE RestockID = @RestockID) " +
                           "WHERE BookID = (SELECT BookID FROM InventoryRestock WHERE RestockID = @RestockID); " +
                           "COMMIT TRANSACTION;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RestockID", restockID);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Order marked as received.");
                    RefreshOrders(); // Refresh the orders in DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }




        // btnCanceled Click Event - Mark Order as Canceled
        private void btnCanceled_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to cancel.");
                return;
            }

            int restockID = (int)dgvOrders.SelectedRows[0].Cells["RestockID"].Value;

            string query = "UPDATE InventoryRestock SET Status = 'Canceled' WHERE RestockID = @RestockID;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RestockID", restockID);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Order marked as canceled.");
                    RefreshOrders(); // Refresh the orders in DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void RefreshOrders()
        {
            string query = "SELECT ir.RestockID, s.Name AS SupplierName, b.Title AS BookTitle, ir.Quantity, ir.RestockDate, ir.Status " +
                           "FROM InventoryRestock ir " +
                           "JOIN Suppliers s ON ir.SupplierID = s.SupplierID " +
                           "JOIN Books b ON ir.BookID = b.BookID " +
                           "WHERE ir.Status IN ('Pending', 'Received', 'Canceled');";  // Changed to include 'Received'

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();

                try
                {
                    conn.Open();
                    da.Fill(dt);
                    dgvOrders.DataSource = dt;

                    // Check if the RestockID column exists and if it's visible
                    if (!dgvOrders.Columns.Contains("RestockID"))
                    {
                        MessageBox.Show("RestockID column is missing.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            // Load Books with stock < 20 into cmbBook
            string queryBooks = "SELECT BookID, Title FROM Books WHERE Stock < 5";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(queryBooks, conn);
                DataTable dt = new DataTable();
                try
                {
                    conn.Open();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No books with stock less than 5.");
                    }
                    cmbBook.DisplayMember = "Title";
                    cmbBook.ValueMember = "BookID";
                    cmbBook.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            // Load Suppliers into cmbSupplier
            string querySuppliers = "SELECT SupplierID, Name FROM Suppliers";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(querySuppliers, conn);
                DataTable dt = new DataTable();
                try
                {
                    conn.Open();
                    da.Fill(dt);
                    cmbSupplier.DisplayMember = "Name";
                    cmbSupplier.ValueMember = "SupplierID";
                    cmbSupplier.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            // Load initial pending orders
            RefreshOrders();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            // Get the selected BookID, SupplierID, and Quantity
            int bookID = (int)cmbBook.SelectedValue;
            int supplierID = (int)cmbSupplier.SelectedValue;
            int quantity = int.Parse(txtQuantity.Text);

            // Check if the quantity is valid
            if (quantity <= 0)
            {
                MessageBox.Show("Please add valid Qunatity");
                return;
            }

            // Check if a book and supplier are selected
            if (cmbBook.SelectedValue == null || cmbSupplier.SelectedValue == null)
            {
                MessageBox.Show("Please select both a book and a supplier.");
                return;
            }

            // Prepare the SQL query
            string query = "INSERT INTO InventoryRestock (SupplierID, BookID, Quantity, Status) " +
                           "VALUES (@SupplierID, @BookID, @Quantity, 'Pending')";

            // Create SQL connection and execute the query
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SupplierID", supplierID);
                cmd.Parameters.AddWithValue("@BookID", bookID);
                cmd.Parameters.AddWithValue("@Quantity", quantity);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Restock order created successfully.");
                    RefreshOrders(); // Refresh the orders in DataGridView
                }
                catch (Exception ex)
                {
                    // Display detailed error message
                    MessageBox.Show("Error creating restock order: " + ex.Message);
                }
            }
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

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            Admin_Cus Obj = new Admin_Cus();
            Obj.Show();
            this.Hide();
        }
    }
}
