using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BookHaven
{
    public partial class Admin_RestockOLD : Form
    {
        public Admin_RestockOLD()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.RestockOrderForm_Load);
            this.btnCanceled.Click += new System.EventHandler(this.btnCanceled_Click);
            this.btnReceived.Click += new System.EventHandler(this.btnReceived_Click);
        }

        private string connectionString = @"Data Source=Zai\SQLEXPRESS;Initial Catalog=BookHeaven;Integrated Security=True";

        // Load books and suppliers when the form loads
        private void RestockOrderForm_Load(object sender, EventArgs e)
        {
            LoadBooks();  // Load books that are low in stock
            LoadSuppliers();  // Load suppliers
            LoadRestockOrders();  // Load restock orders
            InitializeDataGridView();  // Initialize DataGridView for displaying restock orders
        }

        // Load books that are low in stock
        private void LoadBooks()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT BookID, Title FROM Books WHERE Stock < 10"; // or any threshold you choose
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    conn.Open();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No books found with stock less than 10.");
                    }

                    cmbBook.DataSource = dataTable;
                    cmbBook.DisplayMember = "Title";  // Show the Title in ComboBox
                    cmbBook.ValueMember = "BookID";  // Store the BookID for future use
                    cmbBook.SelectedIndex = -1;  // Ensure no selection by default
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading books: " + ex.Message);
            }
        }

        // Initialize DataGridView to display restock orders
        private void InitializeDataGridView()
        {
            dgvRestockOrders.Columns["RestockID"].Visible = false;  // Hide RestockID
            dgvRestockOrders.Columns["BookID"].Visible = false;     // Hide BookID

            dgvRestockOrders.Columns["Title"].HeaderText = "Book Title";
            dgvRestockOrders.Columns["Supplier"].HeaderText = "Supplier Name";
            dgvRestockOrders.Columns["Quantity"].HeaderText = "Quantity Ordered";
            dgvRestockOrders.Columns["Status"].HeaderText = "Order Status";
            dgvRestockOrders.Columns["RestockDate"].HeaderText = "Restock Date";
        }

        // Load suppliers into ComboBox
        private void LoadSuppliers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT SupplierID, Name FROM Suppliers";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    conn.Open();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No suppliers found.");
                    }

                    cmbSupplier.DataSource = null; // Reset DataSource before binding
                    cmbSupplier.DataSource = dataTable;
                    cmbSupplier.DisplayMember = "Name";  // Show the SupplierName in ComboBox
                    cmbSupplier.ValueMember = "SupplierID"; // Store the SupplierID for future use
                    cmbSupplier.SelectedIndex = -1; // Ensure no selection by default
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading suppliers: " + ex.Message);
            }
        }

        // Load restock orders from the database
        private void LoadRestockOrders()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT b.Title, s.Name AS Supplier, ir.Quantity, ir.Status, ir.RestockDate, ir.RestockID, ir.BookID " +
                                   "FROM InventoryRestock ir " +
                                   "JOIN Books b ON ir.BookID = b.BookID " +
                                   "JOIN Suppliers s ON ir.SupplierID = s.SupplierID";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    conn.Open();
                    adapter.Fill(dataTable);

                    // Bind data to DataGridView
                    dgvRestockOrders.DataSource = dataTable;

                    // Ensure DataGridView is properly updated (if needed)
                    dgvRestockOrders.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading restock orders: " + ex.Message);
            }
        }


        // Handle Restock button click
        private void btnRestock_Click(object sender, EventArgs e)
        {
            // Validate input
            if (cmbBook.SelectedIndex < 0 || cmbSupplier.SelectedIndex < 0 || string.IsNullOrEmpty(txtQuantity.Text))
            {
                MessageBox.Show("Please select a book, supplier, and enter a valid quantity.");
                return;
            }

            int bookId = (int)cmbBook.SelectedValue;
            int supplierId = (int)cmbSupplier.SelectedValue;
            int quantity;

            // Validate quantity input
            if (!int.TryParse(txtQuantity.Text, out quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity greater than zero.");
                return;
            }

            // Insert the restock order into the InventoryRestock table
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Insert restock order
                    string query = "INSERT INTO InventoryRestock (SupplierID, BookID, Quantity, Status) " +
                                   "VALUES (@SupplierID, @BookID, @Quantity, 'Pending')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SupplierID", supplierId);
                    cmd.Parameters.AddWithValue("@BookID", bookId);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Restock order created successfully.");
                        LoadRestockOrders();  // Refresh the restock orders list
                    }
                    else
                    {
                        MessageBox.Show("Failed to create restock order.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating restock order: " + ex.Message);
            }
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
            Admin_RestockOLD Obj = new Admin_RestockOLD();
            Obj.Show();
            this.Hide();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            // Button click logic if needed
        }

        private void btnReceived_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected
            if (dgvRestockOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a restock order.");
                return;
            }

            // Get the selected order's RestockID and current status
            int restockID = Convert.ToInt32(dgvRestockOrders.SelectedRows[0].Cells["RestockID"].Value);
            string currentStatus = dgvRestockOrders.SelectedRows[0].Cells["Status"].Value.ToString();

            // Prevent changing status if it's already "Received"
            if (currentStatus == "Received")
            {
                MessageBox.Show("This order has already been marked as received.");
                return;
            }

            // Prevent changing status if it's already "Canceled"
            if (currentStatus == "Canceled")
            {
                MessageBox.Show("This order has already been canceled and cannot be received.");
                return;
            }

            // Get the new status, which should be "Received"
            string newStatus = "Received";

            // Get BookID and Quantity from the selected order
            int bookID = Convert.ToInt32(dgvRestockOrders.SelectedRows[0].Cells["BookID"].Value);
            int quantity = Convert.ToInt32(dgvRestockOrders.SelectedRows[0].Cells["Quantity"].Value);

            // Update the stock in Books table
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Update book stock query
                    string query = "UPDATE Books SET Stock = Stock + @Quantity WHERE BookID = @BookID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@BookID", bookID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Book stock updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update book stock.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating book stock: " + ex.Message);
            }

            // Update the status in the InventoryRestock table
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "UPDATE InventoryRestock SET Status = @Status WHERE RestockID = @RestockID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Status", newStatus);
                    cmd.Parameters.AddWithValue("@RestockID", restockID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Order marked as received successfully.");
                        LoadRestockOrders();  // Reload the restock orders to reflect changes
                    }
                    else
                    {
                        MessageBox.Show("Failed to update order status.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating status to received: " + ex.Message);
            }
        }




        private void btnCanceled_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected
            if (dgvRestockOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a restock order.");
                return;
            }

            // Get the selected order's RestockID
            int restockID = Convert.ToInt32(dgvRestockOrders.SelectedRows[0].Cells["RestockID"].Value);
            string currentStatus = dgvRestockOrders.SelectedRows[0].Cells["Status"].Value.ToString();

            // Prevent canceling if it's already "Canceled"
            if (currentStatus == "Canceled")
            {
                MessageBox.Show("This order has already been marked as canceled.");
                return;
            }

            // Prevent canceling if it's already "Received"
            if (currentStatus == "Received")
            {
                MessageBox.Show("This order has already been marked as received.");
                return;
            }

            // Update the status to "Canceled" in the InventoryRestock table
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "UPDATE InventoryRestock SET Status = @Status WHERE RestockID = @RestockID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Status", "Canceled");
                    cmd.Parameters.AddWithValue("@RestockID", restockID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Restock order marked as canceled successfully.");
                        LoadRestockOrders();  // Reload the restock orders to reflect changes
                    }
                    else
                    {
                        MessageBox.Show("Failed to mark the restock order as canceled.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating status to canceled: " + ex.Message);
            }
        }


    }
}
