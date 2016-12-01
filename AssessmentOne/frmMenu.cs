using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssessmentOne
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
            this.Opacity = 0.90;
            foreach (Control obj in this.Controls) 
            {
                obj.BackColor = Color.FromArgb(100, Color.RoyalBlue);
            }

        }

        private void btnTree_Click(object sender, EventArgs e)
        {
            frmBinary myForm = new frmBinary();
            myForm.Show();
            this.Hide();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            frmSort mySort = new frmSort();
            mySort.Show();
            this.Hide();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FrmSearch mySearch = new FrmSearch();
            mySearch.Show();
            this.Hide();
        }

        private void btnCredits_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://drive.google.com/open?id=1Fkq_7VEedtiFcOZMXCpn6t_FExMcE3zcVw-G4sdAayA");
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            frmLinked myLinked = new frmLinked();
            myLinked.Show();
            this.Hide();
        }

        private void btnHash_Click(object sender, EventArgs e)
        {
            frmHashing myhash = new frmHashing();
            myhash.Show();
            this.Hide();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            //frmTest myTest = new frmTest();
            //myTest.Show();
            //this.Hide();
        }
    }
}
