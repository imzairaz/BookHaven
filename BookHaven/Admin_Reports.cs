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
    public partial class Admin_Reports : Form
    {
        public Admin_Reports()
        {
            InitializeComponent();
        }
        SqlConnection Con = DatabaseHelper.GetConnection();

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



        private void FillDataGrid(string query)
        {
            try
            {
                // Open connection
                Con.Open();

                // Create a SqlDataAdapter to fetch the data
                SqlDataAdapter adapter = new SqlDataAdapter(query, Con);

                // Create a DataTable to hold the results
                DataTable dataTable = new DataTable();

                // Fill the DataTable with the query results
                adapter.Fill(dataTable);

                // Bind the DataTable to the DataGridView
                dgvReport.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report: " + ex.Message);
            }
            finally
            {
                // Close the connection
                Con.Close();
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Get the selected report type from ComboBox
            string selectedReport = cmbReportType.SelectedItem.ToString();

            // SQL Query string variable
            string query = string.Empty;

            // Determine which report to generate based on selected ComboBox item
            switch (selectedReport)
            {
                case "Daily Sales":
                    query = "SELECT SUM(SD.Total) AS TotalSales, COUNT(DISTINCT S.SaleID) AS NumberOfSales " +
                            "FROM Sales S JOIN SaleDetails SD ON S.SaleID = SD.SaleID " +
                            "WHERE CAST(S.SaleDate AS DATE) = CAST(GETDATE() AS DATE)";
                    break;

                case "Weekly Sales":
                    query = "SELECT SUM(SD.Total) AS TotalSales, COUNT(DISTINCT S.SaleID) AS NumberOfSales " +
                            "FROM Sales S JOIN SaleDetails SD ON S.SaleID = SD.SaleID " +
                            "WHERE S.SaleDate >= DATEADD(DAY, -7, GETDATE())";
                    break;

                case "Monthly Sales":
                    query = "SELECT SUM(SD.Total) AS TotalSales, COUNT(DISTINCT S.SaleID) AS NumberOfSales " +
                            "FROM Sales S JOIN SaleDetails SD ON S.SaleID = SD.SaleID " +
                            "WHERE YEAR(S.SaleDate) = YEAR(GETDATE()) AND MONTH(S.SaleDate) = MONTH(GETDATE())";
                    break;

                case "Best Sellers":
                    query = "SELECT B.Title, B.Author, SUM(SD.Quantity) AS TotalSold " +
                            "FROM SaleDetails SD JOIN Books B ON SD.BookID = B.BookID " +
                            "GROUP BY B.Title, B.Author " +
                            "ORDER BY TotalSold DESC";
                    break;

                case "Inventory Levels":
                    query = "SELECT B.Title, B.Author, B.Stock " +
                            "FROM Books B ORDER BY B.Stock DESC";
                    break;
            }

            // Now execute the query and fill the DataGridView with the results
            FillDataGrid(query);
        }
    }
}