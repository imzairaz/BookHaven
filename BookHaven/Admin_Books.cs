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
    public partial class Admin_Books : Form
    {
        public Admin_Books()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Admin_Book_Load);
            this.dgvBook.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBook_CellContentClick);
        }

        // SQL Server Connection
        private string connectionString = @"Data Source=Zai\SQLEXPRESS;Initial Catalog=BookHeaven;Integrated Security=True";

        private void Admin_Book_Load(object sender, EventArgs e)
        {
            LoadData();  // Load data into the DataGridView when the form loads
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
        private void dgvBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBook.Rows[e.RowIndex];
                txtBookTitle.Text = row.Cells["Title"].Value.ToString();
                txtAuthor.Text = row.Cells["Author"].Value.ToString();
                cmbGenre.SelectedItem = row.Cells["Genre"].Value.ToString();
                txtISBN.Text = row.Cells["ISBN"].Value.ToString();
                txtPrice.Text = row.Cells["Price"].Value.ToString();
                txtStock.Text = row.Cells["Stock"].Value.ToString();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string title = txtBookTitle.Text;
            string author = txtAuthor.Text;
            string genre = cmbGenre.SelectedItem.ToString();
            string isbn = txtISBN.Text;
            decimal price = decimal.Parse(txtPrice.Text);
            int stock = int.Parse(txtStock.Text);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (@Title, @Author, @Genre, @ISBN, @Price, @Stock)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Author", author);
                cmd.Parameters.AddWithValue("@Genre", genre);
                cmd.Parameters.AddWithValue("@ISBN", isbn);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Stock", stock);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book added successfully.");
                    LoadData();  // Refresh DataGridView after adding
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvBook.SelectedRows.Count > 0)
            {
                int bookID = Convert.ToInt32(dgvBook.SelectedRows[0].Cells[0].Value); // Get BookID from selected row
                string title = txtBookTitle.Text;
                string author = txtAuthor.Text;
                string genre = cmbGenre.SelectedItem.ToString();
                string isbn = txtISBN.Text;
                decimal price = decimal.Parse(txtPrice.Text);
                int stock = int.Parse(txtStock.Text);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Books SET Title = @Title, Author = @Author, Genre = @Genre, ISBN = @ISBN, Price = @Price, Stock = @Stock WHERE BookID = @BookID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Author", author);
                    cmd.Parameters.AddWithValue("@Genre", genre);
                    cmd.Parameters.AddWithValue("@ISBN", isbn);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Stock", stock);
                    cmd.Parameters.AddWithValue("@BookID", bookID);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Book updated successfully.");
                        LoadData();  // Refresh DataGridView after updating
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a book to update.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBook.SelectedRows.Count > 0)
            {
                int bookID = Convert.ToInt32(dgvBook.SelectedRows[0].Cells[0].Value); // Get BookID from selected row

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Books WHERE BookID = @BookID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BookID", bookID);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Book deleted successfully.");
                        LoadData();  // Refresh DataGridView after deleting
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a book to delete.");
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBookTitle.Clear();
            txtAuthor.Clear();
            cmbGenre.SelectedIndex = -1;  // Clears the selected item in ComboBox
            txtISBN.Clear();
            txtPrice.Clear();
            txtStock.Clear();
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

        private void btnBookOrder_Click(object sender, EventArgs e)
        {
            Admin_Restock Obj = new Admin_Restock();
            Obj.Show();
            this.Hide();
        }
    }
}
