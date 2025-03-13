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
        }

        public Clerk_Order()
        {
            InitializeComponent();

            InitializeGridViews();
            LoadCustomers();
            LoadOrderStatus();
        }

        private void LoadCustomers()
        {
            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string query = "SELECT CustomerID, Name FROM Customers";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                cmbCustomers.Items.Clear();

                while (reader.Read())
                {
                    cmbCustomers.Items.Add(new { Text = reader["Name"].ToString(), Value = reader["CustomerID"].ToString() });
                }

                con.Close();
            }
        }

        private void LoadOrderStatus()
        {
            cmbOrderStatus.Items.Add("Pending");
            cmbOrderStatus.Items.Add("Completed");
            cmbOrderStatus.Items.Add("Cancelled");
            cmbOrderStatus.SelectedIndex = 0;  // Default to 'Pending'
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

                // Ensure valid quantity is entered
                if (int.TryParse(txtQuantity.Text, out int quantity) && quantity > 0)
                {
                    // Add the selected book to the order details DataGridView
                    decimal totalPrice = quantity * bookPrice;
                    dgvOrderDetails.Rows.Add(bookID, bookTitle, quantity, bookPrice, totalPrice);
                }
                else
                {
                    MessageBox.Show("Please enter a valid quantity greater than 0.");
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

            var selectedCustomer = (dynamic)cmbCustomers.SelectedItem;
            int customerID = Convert.ToInt32(selectedCustomer.Value);
            string orderStatus = cmbOrderStatus.SelectedItem.ToString();

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

                    // Insert order query
                    string orderQuery = "INSERT INTO Orders (CustomerID, OrderDate, Status) OUTPUT INSERTED.OrderID VALUES (@CustomerID, @OrderDate, @Status)";
                    SqlCommand cmd = new SqlCommand(orderQuery, con, transaction);
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                    cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Status", orderStatus);

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

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
