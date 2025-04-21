using System;
using System.Windows.Forms;
using System.Data;  // For DataTable and related types
using System.Data.SqlClient;  // For SqlConnection, SqlCommand, SqlDataAdapter

namespace BookHaven
{
    public partial class Clerk_Order : Form
    {
        SqlConnection Con = DatabaseHelper.GetConnection();

        // Ensure the columns are set when the form is initialized
        private void InitializeGridViews()
        {
            // dgvSearchResults Columns
            dgvSearchResults.Columns.Add("BookID", "Book ID");
            dgvSearchResults.Columns.Add("Title", "Title");
            dgvSearchResults.Columns.Add("Author", "Author");
            dgvSearchResults.Columns.Add("Price", "Price");
            dgvSearchResults.Columns.Add("Stock", "Stock");

            // dgvOrderDetails Columns
            dgvOrderDetails.Columns.Add("BookID", "Book ID");
            dgvOrderDetails.Columns.Add("Title", "Title");
            dgvOrderDetails.Columns.Add("Quantity", "Quantity");
            dgvOrderDetails.Columns.Add("Price", "Price");
            dgvOrderDetails.Columns.Add("Total", "Total");
            dgvOrderDetails.Columns.Add("DeliveryMethod", "Delivery Method");
        }

        private void LoadDeliveryMode()
        {
            cmbDeliveryMode.Items.Add("Pickup");
            cmbDeliveryMode.Items.Add("Delivery");
            cmbDeliveryMode.SelectedIndex = 0;  // Default to 'Pickup' or 'Delivery'
        }

        public Clerk_Order()
        {
            InitializeComponent();

            InitializeGridViews();
            LoadCustomers();
            LoadOrderStatus();
            LoadDeliveryMode();  // Add this method call to load delivery modes
        }

        private void LoadOrderStatus()
        {
            string query = @"SELECT 
                        o.OrderID,
                        c.Name AS CustomerName, 
                        b.Title AS BookName, 
                        od.Quantity, 
                        od.Price, 
                        o.DeliveryMethod, 
                        o.Status
                     FROM Orders o
                     INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
                     INNER JOIN Books b ON od.BookID = b.BookID
                     INNER JOIN Customers c ON o.CustomerID = c.CustomerID
                     WHERE o.Status = 'Pending'";

            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvOrderStatus.DataSource = dt;
            }
        }

        private void LoadCustomers()
        {
            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string query = "SELECT CustomerID, Name FROM Customers";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                // Create a DataTable to hold the customer data
                DataTable dtCustomers = new DataTable();
                dtCustomers.Load(reader);

                // Bind the DataTable to the ComboBox
                cmbCustomers.DataSource = dtCustomers;
                cmbCustomers.DisplayMember = "Name";   // Display the customer's name
                cmbCustomers.ValueMember = "CustomerID"; // Use the CustomerID as the value

                con.Close();
            }
        }


        private void btnSearchBooks_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearchBooks.Text;

            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string query = "SELECT BookID, Title, Author, Price, Stock FROM Books WHERE Title LIKE @searchTerm OR Author LIKE @searchTerm";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                dgvSearchResults.Rows.Clear();

                while (reader.Read())
                {
                    dgvSearchResults.Rows.Add(reader["BookID"], reader["Title"], reader["Author"], reader["Price"], reader["Stock"]);
                }

                con.Close();
            }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            if (dgvSearchResults.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvSearchResults.SelectedRows[0];
                int bookID = (int)selectedRow.Cells["BookID"].Value;
                string bookTitle = selectedRow.Cells["Title"].Value.ToString();
                decimal bookPrice = (decimal)selectedRow.Cells["Price"].Value;
                int quantity = Convert.ToInt32(txtQuantity.Text);
                string DeliveryMethod = cmbDeliveryMode.SelectedItem.ToString();

                if (quantity > 0)
                {
                    // Add the selected book to the order details DataGridView
                    dgvOrderDetails.Rows.Add(bookID, bookTitle, quantity, bookPrice, quantity * bookPrice, DeliveryMethod);
                }
                else
                {
                    MessageBox.Show("Please enter a valid quantity.");
                }
            }
            else
            {
                MessageBox.Show("Please select a book.");
            }
        }

        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            if (cmbCustomers.SelectedItem == null || dgvOrderDetails.Rows.Count == 0)
            {
                MessageBox.Show("Please select a customer and add books to the order.");
                return;
            }
            DataRowView selectedRow = (DataRowView)cmbCustomers.SelectedItem;

            var selectedCustomer = (dynamic)cmbCustomers.SelectedItem;
            int customerID = Convert.ToInt32(selectedRow["CustomerID"]);
            string orderStatus = "Pending";  // Default status
            string DeliveryMethod = cmbDeliveryMode.SelectedItem.ToString();  // Get selected delivery mode

            decimal totalAmount = 0;
            foreach (DataGridViewRow row in dgvOrderDetails.Rows)
            {
                totalAmount += Convert.ToDecimal(row.Cells["Total"].Value);
            }

            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                SqlTransaction transaction = null;  // Declare the transaction outside the try block

                try
                {
                    con.Open();  // Open the connection explicitly before starting the transaction
                    transaction = con.BeginTransaction();  // Start the transaction after opening the connection

                    // Insert order query with DeliveryMode
                    string orderQuery = "INSERT INTO Orders (CustomerID, OrderDate, Status, DeliveryMethod) OUTPUT INSERTED.OrderID VALUES (@CustomerID, @OrderDate, @Status, @DeliveryMethod)";
                    SqlCommand cmd = new SqlCommand(orderQuery, con, transaction);
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                    cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Status", orderStatus);
                    cmd.Parameters.AddWithValue("@DeliveryMethod", DeliveryMethod);  // Add DeliveryMode to the query

                    int orderID = (int)cmd.ExecuteScalar();

                    // Insert order details
                    foreach (DataGridViewRow row in dgvOrderDetails.Rows)
                    {
                        if (row.Cells["BookID"].Value != null)
                        {
                            int bookID = (int)row.Cells["BookID"].Value;
                            int quantity = (int)row.Cells["Quantity"].Value;
                            decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                            decimal total = Convert.ToDecimal(row.Cells["Total"].Value);

                            string orderDetailQuery = "INSERT INTO OrderDetails (OrderID, BookID, Quantity, Price) VALUES (@OrderID, @BookID, @Quantity, @Price)";
                            SqlCommand cmdDetail = new SqlCommand(orderDetailQuery, con, transaction);
                            cmdDetail.Parameters.AddWithValue("@OrderID", orderID);
                            cmdDetail.Parameters.AddWithValue("@BookID", bookID);
                            cmdDetail.Parameters.AddWithValue("@Quantity", quantity);
                            cmdDetail.Parameters.AddWithValue("@Price", price);

                            cmdDetail.ExecuteNonQuery();
                        }
                    }

                    // Commit the transaction
                    transaction.Commit();
                    MessageBox.Show("Order saved successfully!");

                    // Refresh the order list in dgvOrderStatus
                    LoadOrderStatus();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    // Rollback the transaction in case of an error
                    transaction?.Rollback();
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void ClearForm()
        {
            cmbCustomers.SelectedIndex = -1;
            dgvOrderDetails.Rows.Clear();
            txtQuantity.Text = "1";  // Reset quantity to 1
            txtSearchBooks.Clear();
        }

        private void cmbOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            // You can add custom behavior for order status changes if needed
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnSaveStatus_Click(object sender, EventArgs e)
        {
            if (dgvOrderStatus.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvOrderStatus.SelectedRows[0];

                if (selectedRow.Cells["OrderID"].Value == null)
                {
                    MessageBox.Show("Selected order does not have a valid Order ID.");
                    return;
                }

                int orderID = (int)selectedRow.Cells["OrderID"].Value;

                if (cmbOrderStatus.SelectedItem == null)
                {
                    MessageBox.Show("Please select a status to update.");
                    return;
                }

                string newStatus = cmbOrderStatus.SelectedItem.ToString();

                string updateQuery = "UPDATE Orders SET Status = @Status WHERE OrderID = @OrderID";
                using (SqlConnection con = DatabaseHelper.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(updateQuery, con);
                    cmd.Parameters.AddWithValue("@Status", newStatus);
                    cmd.Parameters.AddWithValue("@OrderID", orderID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                // Reload the order status after updating
                LoadOrderStatus();

                // ✅ Show special message if status is 'Completed'
                if (newStatus == "Completed")
                {
                    MessageBox.Show("Order is Completed ✅");
                }
                else
                {
                    MessageBox.Show("Order status updated successfully.");
                }
            }
            else
            {
                MessageBox.Show("Please select an order to update its status.");
            }
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
            Clerk_Customer Obj = new Clerk_Customer();
            Obj.Show();
            this.Hide();
        }
    }
}
