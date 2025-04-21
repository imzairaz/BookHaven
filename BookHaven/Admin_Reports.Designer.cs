
namespace BookHaven
{
    partial class Admin_Reports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_Reports));
            this.panelSide = new Guna.UI2.WinForms.Guna2Panel();
            this.btnBookOrder = new Guna.UI2.WinForms.Guna2Button();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.btnReport = new Guna.UI2.WinForms.Guna2Button();
            this.btnInventory = new Guna.UI2.WinForms.Guna2Button();
            this.btnSupplier = new Guna.UI2.WinForms.Guna2Button();
            this.btnClerk = new Guna.UI2.WinForms.Guna2Button();
            this.btnDash = new Guna.UI2.WinForms.Guna2Button();
            this.picbxMain = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblSideTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panelTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTopTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnClose = new Guna.UI2.WinForms.Guna2CircleButton();
            this.panelCenter = new Guna.UI2.WinForms.Guna2Panel();
            this.lblReport = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dgvReport = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnGenerate = new Guna.UI2.WinForms.Guna2GradientButton();
            this.cmbReportType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCustomer = new Guna.UI2.WinForms.Guna2Button();
            this.panelSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbxMain)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSide
            // 
            this.panelSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelSide.Controls.Add(this.btnCustomer);
            this.panelSide.Controls.Add(this.btnBookOrder);
            this.panelSide.Controls.Add(this.btnLogout);
            this.panelSide.Controls.Add(this.btnReport);
            this.panelSide.Controls.Add(this.btnInventory);
            this.panelSide.Controls.Add(this.btnSupplier);
            this.panelSide.Controls.Add(this.btnClerk);
            this.panelSide.Controls.Add(this.btnDash);
            this.panelSide.Controls.Add(this.picbxMain);
            this.panelSide.Controls.Add(this.lblSideTitle);
            this.panelSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSide.Location = new System.Drawing.Point(0, 0);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(191, 600);
            this.panelSide.TabIndex = 1;
            // 
            // btnBookOrder
            // 
            this.btnBookOrder.Animated = true;
            this.btnBookOrder.BackColor = System.Drawing.Color.Transparent;
            this.btnBookOrder.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBookOrder.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBookOrder.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBookOrder.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBookOrder.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBookOrder.Font = new System.Drawing.Font("Helvetica", 11F, System.Drawing.FontStyle.Bold);
            this.btnBookOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBookOrder.HoverState.FillColor = System.Drawing.Color.Teal;
            this.btnBookOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnBookOrder.Image")));
            this.btnBookOrder.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBookOrder.Location = new System.Drawing.Point(0, 374);
            this.btnBookOrder.Name = "btnBookOrder";
            this.btnBookOrder.Size = new System.Drawing.Size(191, 45);
            this.btnBookOrder.TabIndex = 10;
            this.btnBookOrder.Text = "Re-Stock";
            this.btnBookOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBookOrder.TextOffset = new System.Drawing.Point(15, 0);
            this.btnBookOrder.UseTransparentBackground = true;
            this.btnBookOrder.Click += new System.EventHandler(this.btnBookOrder_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Animated = true;
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLogout.Font = new System.Drawing.Font("Helvetica", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLogout.Location = new System.Drawing.Point(0, 554);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(191, 45);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLogout.TextOffset = new System.Drawing.Point(15, 0);
            this.btnLogout.UseTransparentBackground = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnReport
            // 
            this.btnReport.Animated = true;
            this.btnReport.BackColor = System.Drawing.Color.Transparent;
            this.btnReport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnReport.Font = new System.Drawing.Font("Helvetica", 11F, System.Drawing.FontStyle.Bold);
            this.btnReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnReport.HoverState.FillColor = System.Drawing.Color.Teal;
            this.btnReport.Image = ((System.Drawing.Image)(resources.GetObject("btnReport.Image")));
            this.btnReport.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnReport.Location = new System.Drawing.Point(0, 422);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(191, 45);
            this.btnReport.TabIndex = 6;
            this.btnReport.Text = "Report";
            this.btnReport.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnReport.TextOffset = new System.Drawing.Point(15, 0);
            this.btnReport.UseTransparentBackground = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.Animated = true;
            this.btnInventory.BackColor = System.Drawing.Color.Transparent;
            this.btnInventory.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnInventory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnInventory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnInventory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnInventory.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnInventory.Font = new System.Drawing.Font("Helvetica", 11F, System.Drawing.FontStyle.Bold);
            this.btnInventory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnInventory.HoverState.FillColor = System.Drawing.Color.Teal;
            this.btnInventory.Image = ((System.Drawing.Image)(resources.GetObject("btnInventory.Image")));
            this.btnInventory.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnInventory.Location = new System.Drawing.Point(0, 326);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(191, 45);
            this.btnInventory.TabIndex = 5;
            this.btnInventory.Text = "Books";
            this.btnInventory.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnInventory.TextOffset = new System.Drawing.Point(15, 0);
            this.btnInventory.UseTransparentBackground = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.Animated = true;
            this.btnSupplier.BackColor = System.Drawing.Color.Transparent;
            this.btnSupplier.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSupplier.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSupplier.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSupplier.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSupplier.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSupplier.Font = new System.Drawing.Font("Helvetica", 11F, System.Drawing.FontStyle.Bold);
            this.btnSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSupplier.HoverState.FillColor = System.Drawing.Color.Teal;
            this.btnSupplier.Image = ((System.Drawing.Image)(resources.GetObject("btnSupplier.Image")));
            this.btnSupplier.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSupplier.Location = new System.Drawing.Point(0, 278);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(191, 45);
            this.btnSupplier.TabIndex = 4;
            this.btnSupplier.Text = "Suppliers";
            this.btnSupplier.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSupplier.TextOffset = new System.Drawing.Point(15, 0);
            this.btnSupplier.UseTransparentBackground = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnClerk
            // 
            this.btnClerk.Animated = true;
            this.btnClerk.BackColor = System.Drawing.Color.Transparent;
            this.btnClerk.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClerk.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClerk.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClerk.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClerk.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClerk.Font = new System.Drawing.Font("Helvetica", 11F, System.Drawing.FontStyle.Bold);
            this.btnClerk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClerk.HoverState.FillColor = System.Drawing.Color.Teal;
            this.btnClerk.Image = ((System.Drawing.Image)(resources.GetObject("btnClerk.Image")));
            this.btnClerk.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnClerk.Location = new System.Drawing.Point(0, 182);
            this.btnClerk.Name = "btnClerk";
            this.btnClerk.Size = new System.Drawing.Size(191, 45);
            this.btnClerk.TabIndex = 3;
            this.btnClerk.Text = "Clerks";
            this.btnClerk.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnClerk.TextOffset = new System.Drawing.Point(15, 0);
            this.btnClerk.UseTransparentBackground = true;
            this.btnClerk.Click += new System.EventHandler(this.btnClerk_Click);
            // 
            // btnDash
            // 
            this.btnDash.Animated = true;
            this.btnDash.BackColor = System.Drawing.Color.Transparent;
            this.btnDash.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDash.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDash.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDash.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDash.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDash.Font = new System.Drawing.Font("Helvetica", 11F, System.Drawing.FontStyle.Bold);
            this.btnDash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDash.HoverState.FillColor = System.Drawing.Color.Teal;
            this.btnDash.Image = ((System.Drawing.Image)(resources.GetObject("btnDash.Image")));
            this.btnDash.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDash.Location = new System.Drawing.Point(0, 134);
            this.btnDash.Name = "btnDash";
            this.btnDash.Size = new System.Drawing.Size(191, 45);
            this.btnDash.TabIndex = 2;
            this.btnDash.Text = "Dashboard";
            this.btnDash.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDash.TextOffset = new System.Drawing.Point(15, 0);
            this.btnDash.UseTransparentBackground = true;
            this.btnDash.Click += new System.EventHandler(this.btnDash_Click);
            // 
            // picbxMain
            // 
            this.picbxMain.BackColor = System.Drawing.Color.Transparent;
            this.picbxMain.Image = ((System.Drawing.Image)(resources.GetObject("picbxMain.Image")));
            this.picbxMain.ImageRotate = 0F;
            this.picbxMain.Location = new System.Drawing.Point(59, 12);
            this.picbxMain.Name = "picbxMain";
            this.picbxMain.Size = new System.Drawing.Size(72, 64);
            this.picbxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbxMain.TabIndex = 1;
            this.picbxMain.TabStop = false;
            this.picbxMain.UseTransparentBackground = true;
            // 
            // lblSideTitle
            // 
            this.lblSideTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSideTitle.Font = new System.Drawing.Font("Helvetica", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSideTitle.ForeColor = System.Drawing.Color.White;
            this.lblSideTitle.Location = new System.Drawing.Point(12, 86);
            this.lblSideTitle.Name = "lblSideTitle";
            this.lblSideTitle.Size = new System.Drawing.Size(168, 24);
            this.lblSideTitle.TabIndex = 0;
            this.lblSideTitle.Text = "Admin Dashboard";
            // 
            // panelTop
            // 
            this.panelTop.BorderColor = System.Drawing.Color.Black;
            this.panelTop.BorderThickness = 1;
            this.panelTop.Controls.Add(this.lblTopTitle);
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(191, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(809, 93);
            this.panelTop.TabIndex = 11;
            // 
            // lblTopTitle
            // 
            this.lblTopTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTopTitle.Font = new System.Drawing.Font("Helvetica", 18.25F, System.Drawing.FontStyle.Bold);
            this.lblTopTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTopTitle.Location = new System.Drawing.Point(364, 31);
            this.lblTopTitle.Name = "lblTopTitle";
            this.lblTopTitle.Size = new System.Drawing.Size(81, 31);
            this.lblTopTitle.TabIndex = 9;
            this.lblTopTitle.Text = "Report";
            // 
            // btnClose
            // 
            this.btnClose.Animated = true;
            this.btnClose.AnimatedGIF = true;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageSize = new System.Drawing.Size(25, 25);
            this.btnClose.Location = new System.Drawing.Point(770, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnClose.Size = new System.Drawing.Size(27, 27);
            this.btnClose.TabIndex = 9;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.lblReport);
            this.panelCenter.Controls.Add(this.dgvReport);
            this.panelCenter.Controls.Add(this.btnGenerate);
            this.panelCenter.Controls.Add(this.cmbReportType);
            this.panelCenter.Controls.Add(this.lblTitle);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(191, 93);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(809, 507);
            this.panelCenter.TabIndex = 12;
            // 
            // lblReport
            // 
            this.lblReport.BackColor = System.Drawing.Color.Transparent;
            this.lblReport.Font = new System.Drawing.Font("Helvetica", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblReport.Location = new System.Drawing.Point(370, 128);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(68, 24);
            this.lblReport.TabIndex = 10;
            this.lblReport.Text = "Report";
            // 
            // dgvReport
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvReport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReport.ColumnHeadersHeight = 30;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReport.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvReport.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvReport.Location = new System.Drawing.Point(0, 158);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.RowHeadersVisible = false;
            this.dgvReport.Size = new System.Drawing.Size(809, 349);
            this.dgvReport.TabIndex = 37;
            this.dgvReport.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvReport.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvReport.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvReport.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvReport.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvReport.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvReport.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvReport.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvReport.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvReport.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvReport.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReport.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvReport.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvReport.ThemeStyle.ReadOnly = false;
            this.dgvReport.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvReport.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvReport.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvReport.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvReport.ThemeStyle.RowsStyle.Height = 22;
            this.dgvReport.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvReport.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // btnGenerate
            // 
            this.btnGenerate.Animated = true;
            this.btnGenerate.AnimatedGIF = true;
            this.btnGenerate.AutoRoundedCorners = true;
            this.btnGenerate.BorderColor = System.Drawing.Color.Transparent;
            this.btnGenerate.BorderRadius = 17;
            this.btnGenerate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGenerate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGenerate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGenerate.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGenerate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGenerate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGenerate.FillColor2 = System.Drawing.Color.Teal;
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerate.Image")));
            this.btnGenerate.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnGenerate.ImageOffset = new System.Drawing.Point(5, 0);
            this.btnGenerate.ImageSize = new System.Drawing.Size(15, 15);
            this.btnGenerate.Location = new System.Drawing.Point(253, 50);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(114, 36);
            this.btnGenerate.TabIndex = 29;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.TextOffset = new System.Drawing.Point(7, -1);
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // cmbReportType
            // 
            this.cmbReportType.BackColor = System.Drawing.Color.Transparent;
            this.cmbReportType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbReportType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbReportType.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbReportType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbReportType.ItemHeight = 30;
            this.cmbReportType.Items.AddRange(new object[] {
            "Daily Sales",
            "Weekly Sales",
            "Monthly Sales",
            "Best Sellers",
            "Inventory Status"});
            this.cmbReportType.Location = new System.Drawing.Point(20, 50);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(200, 36);
            this.cmbReportType.TabIndex = 21;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Helvetica", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(17, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(96, 17);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Report Type";
            // 
            // btnCustomer
            // 
            this.btnCustomer.Animated = true;
            this.btnCustomer.BackColor = System.Drawing.Color.Transparent;
            this.btnCustomer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCustomer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCustomer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCustomer.Font = new System.Drawing.Font("Helvetica", 11F, System.Drawing.FontStyle.Bold);
            this.btnCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCustomer.HoverState.FillColor = System.Drawing.Color.Teal;
            this.btnCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomer.Image")));
            this.btnCustomer.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCustomer.Location = new System.Drawing.Point(0, 230);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(191, 45);
            this.btnCustomer.TabIndex = 12;
            this.btnCustomer.Text = "Customers";
            this.btnCustomer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCustomer.TextOffset = new System.Drawing.Point(15, 0);
            this.btnCustomer.UseTransparentBackground = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // Admin_Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelSide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Admin_Reports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin_Reports";
            this.panelSide.ResumeLayout(false);
            this.panelSide.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbxMain)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelCenter.ResumeLayout(false);
            this.panelCenter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelSide;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2Button btnReport;
        private Guna.UI2.WinForms.Guna2Button btnInventory;
        private Guna.UI2.WinForms.Guna2Button btnSupplier;
        private Guna.UI2.WinForms.Guna2Button btnClerk;
        private Guna.UI2.WinForms.Guna2Button btnDash;
        private Guna.UI2.WinForms.Guna2PictureBox picbxMain;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSideTitle;
        private Guna.UI2.WinForms.Guna2Panel panelTop;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTopTitle;
        private Guna.UI2.WinForms.Guna2CircleButton btnClose;
        private Guna.UI2.WinForms.Guna2Panel panelCenter;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblReport;
        private Guna.UI2.WinForms.Guna2DataGridView dgvReport;
        private Guna.UI2.WinForms.Guna2GradientButton btnGenerate;
        private Guna.UI2.WinForms.Guna2ComboBox cmbReportType;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnBookOrder;
        private Guna.UI2.WinForms.Guna2Button btnCustomer;
    }
}