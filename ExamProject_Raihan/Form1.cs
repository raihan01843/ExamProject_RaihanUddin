using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamProject_Raihan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrrower_Click(object sender, EventArgs e)
        {
            Borrower rf = new Borrower();
            this.Hide();
            rf.ShowDialog();
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            Books books = new Books();
            this.Hide();
            books.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            CrystalReport1 crystalReport1 = new CrystalReport1();
            this.Hide();
            //Form2.ShowDialog();
        }
    }
}
