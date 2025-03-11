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
    public partial class Clerk_Sale : Form
    {
        private string connectionString = @"Data Source=Zai\SQLEXPRESS;Initial Catalog=BookHeaven;Integrated Security=True";
        private decimal totalAmount = 0;

        public Clerk_Sale()
        {
            this.Load += new System.EventHandler(this.Clerk_Sale_Load);
            InitializeComponent();
            cmbCustomerName.SelectedIndexChanged += new EventHandler(cmbCustomerName_SelectedIndexChanged);
        }

        private void Clerk_Sale_Load(object sender, EventArgs e)
        {
            LoadData();  // Load data into the DataGridView when the form loads
            LoadCustomers();  // Load customer data into ComboBox
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Books"; // SQL Query to get all books
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();

                    conn.Open();
                    adapter.Fill(dataTable);

                    dgvBook.DataSource = dataTable;  // Set the DataGridView's data source to the DataTable
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void LoadCustomers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT CustomerID, Name FROM Customers"; // SQL query to get all customers
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();

                    conn.Open();
                    adapter.Fill(dataTable);

                    // Add a default "Please select a customer" row
                    DataRow row = dataTable.NewRow();
                    row["CustomerID"] = DBNull.Value;
                    row["Name"] = "Select a Customer";
                    dataTable.Rows.InsertAt(row, 0);

                    // Bind customers to ComboBox
                    cmbCustomerName.DataSource = dataTable;
                    cmbCustomerName.DisplayMember = "Name";
                    cmbCustomerName.ValueMember = "CustomerID";

                    // Set the ComboBox to the first item ("Please select a customer")
                    cmbCustomerName.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message);
            }
        }

        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if the selection is not the default one ("Please select a customer")
            if (cmbCustomerName.SelectedIndex > 0) // This ensures that the default value is ignored
            {
                // Check if there's a valid customer ID selected
                if (cmbCustomerName.SelectedValue != null && cmbCustomerName.SelectedValue is int customerId)
                {
                    // Now we have a valid customerId (of type int), load customer details
                    LoadCustomerDetails(customerId);
                }
            }
            else
            {
                // If there's no valid customer selection or it's the default item
                txtCusPhone.Clear();
                txtCusEmail.Clear();
                txtCusAddress.Clear();
            }
        }


        private void LoadCustomerDetails(int customerId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Phone, Email, Address FROM Customers WHERE CustomerID = @CustomerID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtCusPhone.Text = reader["Phone"].ToString();
                        txtCusEmail.Text = reader["Email"].ToString();
                        txtCusAddress.Text = reader["Address"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customer details: " + ex.Message);
            }
        }

        private void dgvBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBook.Rows[e.RowIndex];
                txtBookName.Text = row.Cells["Title"].Value.ToString();
                txtPrice.Text = row.Cells["Price"].Value.ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Books WHERE Title LIKE @SearchQuery OR Author LIKE @SearchQuery";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@SearchQuery", "%" + searchQuery + "%");
                    DataTable dataTable = new DataTable();

                    conn.Open();
                    adapter.Fill(dataTable);

                    dgvBook.DataSource = dataTable;  // Display search results in DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching data: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAddToBill_Click(object sender, EventArgs e)
        {
            // Get the values from the form fields
            string bookTitle = txtBookName.Text;
            decimal bookPrice = Convert.ToDecimal(txtPrice.Text);
            int quantity = Convert.ToInt32(txtQuantity.Text);
            decimal discountPercent = Convert.ToDecimal(txtDiscount.Text);

            // Calculate the discount amount (as a percentage of the total price)
            decimal discountAmount = (bookPrice * quantity) * (discountPercent / 100);

            // Calculate the total price after discount
            decimal totalPrice = (bookPrice * quantity) - discountAmount;

            // Ensure you are also adding the BookID to the bill (assuming it exists in dgvBook)
            int bookId = Convert.ToInt32(dgvBook.SelectedRows[0].Cells["BookID"].Value);  // Access the BookID column

            // Add the row to the dgvBill DataGridView
            dgvBill.Rows.Add(bookId, bookTitle, bookPrice, quantity, discountPercent.ToString("F2") + "%", totalPrice); // Add discountPercent as string with '%' symbol

            // Update the total amount
            totalAmount += totalPrice;
            txtTotal.Text = totalAmount.ToString("F2");
        }

        private bool SaveSale()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    if (!decimal.TryParse(txtDiscount.Text, out decimal discount))
                    {
                        MessageBox.Show("Invalid discount format.");
                        return false;
                    }

                    if (!decimal.TryParse(txtTotal.Text, out decimal totalAmount))
                    {
                        MessageBox.Show("Invalid total amount format.");
                        return false;
                    }

                    // Insert sale record
                    SqlCommand cmd = new SqlCommand("INSERT INTO Sales (CustomerID, Discount, Total) VALUES (@CustomerID, @Discount, @Total); SELECT SCOPE_IDENTITY()", conn, transaction);
                    cmd.Parameters.AddWithValue("@CustomerID", cmbCustomerName.SelectedValue ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Discount", discount);
                    cmd.Parameters.AddWithValue("@Total", totalAmount);
                    int saleId = Convert.ToInt32(cmd.ExecuteScalar()); // Capture SaleID

                    // Insert sale items and update inventory
                    foreach (DataGridViewRow row in dgvBill.Rows)
                    {
                        if (row.IsNewRow) continue;

                        // Ensure BookID is valid
                        if (row.Cells["BookID"].Value == null || !int.TryParse(row.Cells["BookID"].Value.ToString(), out int bookId))
                        {
                            MessageBox.Show("Invalid Book ID.");
                            return false;
                        }

                        // Validate Quantity and Price
                        if (!int.TryParse(row.Cells["Quantity"].Value.ToString(), out int quantity))
                        {
                            MessageBox.Show("Invalid Quantity format.");
                            return false;
                        }

                        if (!decimal.TryParse(row.Cells["Price"].Value.ToString(), out decimal price))
                        {
                            MessageBox.Show("Invalid Price format.");
                            return false;
                        }

                        decimal total = price * quantity; // Calculate the row's total

                        // Insert each sale item
                        SqlCommand itemCmd = new SqlCommand("INSERT INTO SaleDetails (SaleID, BookID, Quantity, Price, Total) VALUES (@SaleID, @BookID, @Quantity, @Price, @Total)", conn, transaction);
                        itemCmd.Parameters.AddWithValue("@SaleID", saleId);
                        itemCmd.Parameters.AddWithValue("@BookID", bookId);
                        itemCmd.Parameters.AddWithValue("@Quantity", quantity);
                        itemCmd.Parameters.AddWithValue("@Price", price);
                        itemCmd.Parameters.AddWithValue("@Total", total);
                        itemCmd.ExecuteNonQuery();

                        // Check available stock before updating inventory
                        SqlCommand checkStockCmd = new SqlCommand("SELECT Stock FROM Books WHERE BookID = @BookID", conn, transaction);
                        checkStockCmd.Parameters.AddWithValue("@BookID", bookId);
                        int availableStock = (int)checkStockCmd.ExecuteScalar();

                        if (availableStock < quantity)
                        {
                            MessageBox.Show($"Not enough stock for '{row.Cells["BookTitle"].Value}'. Available stock: {availableStock}");
                            return false;
                        }

                        // Update the inventory by reducing the stock of the book
                        SqlCommand updateCmd = new SqlCommand("UPDATE Books SET Stock = Stock - @Quantity WHERE BookID = @BookID", conn, transaction);
                        updateCmd.Parameters.AddWithValue("@Quantity", quantity);
                        updateCmd.Parameters.AddWithValue("@BookID", bookId);
                        updateCmd.ExecuteNonQuery();
                    }

                    // Commit transaction
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    // Rollback in case of an error
                    transaction.Rollback();
                    MessageBox.Show("Error saving sale: " + ex.Message);
                    return false;
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // First, save the sale before printing the receipt
            bool saleSaved = SaveSale();  // Automatically saves the sale when print button is clicked

            if (!saleSaved)
            {
                MessageBox.Show("There was an error saving the sale. Please try again.");
                return;
            }

            // Now, generate and display the receipt
            StringBuilder receipt = new StringBuilder();

            // Store details
            receipt.AppendLine("Book Heaven Store - Receipt");
            receipt.AppendLine("----------------------------------------");

            // Access customer name from the ComboBox's selected item
            DataRowView selectedCustomer = cmbCustomerName.SelectedItem as DataRowView;
            if (selectedCustomer != null)
            {
                string customerName = selectedCustomer["Name"].ToString();
                receipt.AppendLine($"Customer: {customerName}");
            }

            // Customer details
            receipt.AppendLine($"Phone: {txtCusPhone.Text}");
            receipt.AppendLine($"Email: {txtCusEmail.Text}");
            receipt.AppendLine($"Address: {txtCusAddress.Text}");
            receipt.AppendLine("----------------------------------------");

            // Bill items
            foreach (DataGridViewRow row in dgvBill.Rows)
            {
                if (row.IsNewRow) continue;

                // Access the columns by name to avoid index issues
                string bookTitle = row.Cells["BookTitle"].Value?.ToString(); // Replace "BookTitle" with your column name
                decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                decimal total = Convert.ToDecimal(row.Cells["Total"].Value);

                receipt.AppendLine($"{bookTitle} - {quantity} x {price:C} = {total:C}");
            }

            receipt.AppendLine("----------------------------------------");
            receipt.AppendLine($"Total: {txtTotal.Text}");

            // Display the receipt in a message box
            MessageBox.Show(receipt.ToString(), "Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
}
