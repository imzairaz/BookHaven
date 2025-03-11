using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookHaven
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        int StartPoint = 0;
        private void Timer_Tick(object sender, EventArgs e)
        {
            StartPoint += 10;
            ProgressBar.Value = StartPoint;
            lblPercent.Text = StartPoint + "%";
            if (ProgressBar.Value == 100)
            {
                ProgressBar.Value = 0;
                Timer.Stop();
                Login Obj = new Login();
                Obj.Show();
                this.Hide();
            }
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            Timer.Start();
        }
    }
}
