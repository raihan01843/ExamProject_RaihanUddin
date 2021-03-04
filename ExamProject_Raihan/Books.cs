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
using System.Configuration;

namespace ExamProject_Raihan
{
    public partial class Books : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["DBcon"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;

        InsertedMethod objinsert = new InsertedMethod();
        UpdateBooks objupdate = new UpdateBooks();
        DeleteBooks objdelete = new DeleteBooks();
        public Books()
        {
            InitializeComponent();
        }
        public void DataRefresh()
        {
            using (con = new SqlConnection(cs))
            {
                adapter = new SqlDataAdapter("SELECT * FROM Books", con);
                dt = new DataTable();
                adapter.Fill(dt);
                dgViewBooks.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            objinsert.insertedData("Insert Into Books(BookName,BookAuthar,BookEdition,BookPublisher,BookISBN) Values('" + txtBookName.Text + "','" + txtAuthar.Text + "','" + txtEdition.Text + "','" + txtPublisher.Text + "','" + txtISBN.Text + "') ");
            MessageBox.Show("Data Inserted Succsessfully!!!");
            DataRefresh();
            ClearAllData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ClearAllData()
        {
            txtBookName.Text = "";
            txtAuthar.Text = "";
            txtEdition.Text = "";
            txtPublisher.Text = "";
            txtISBN.Text = "";
        }

        private void Books_Load(object sender, EventArgs e)
        {
            DataRefresh();
        }

        private void dgViewBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBookName.Text = this.dgViewBooks.CurrentRow.Cells["BookName"].Value.ToString();
            txtAuthar.Text = this.dgViewBooks.CurrentRow.Cells["BookAuthar"].Value.ToString();
            txtEdition.Text = this.dgViewBooks.CurrentRow.Cells["BookEdition"].Value.ToString();
            txtPublisher.Text = this.dgViewBooks.CurrentRow.Cells["BookPublisher"].Value.ToString();
            txtISBN.Text = this.dgViewBooks.CurrentRow.Cells["BookISBN"].Value.ToString();
            lblID.Text = this.dgViewBooks.CurrentRow.Cells["BookID"].Value.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            objupdate.UpdateBookInfo("Update Books Set BookName= '" + txtBookName.Text + "', BookAuthar= '" + txtAuthar.Text + "', BookEdition= '" + txtEdition.Text + "', BookPublisher= '" + txtPublisher.Text + "',BookISBN= '" + txtISBN.Text +"' Where BookID='" + lblID.Text + "'");

            MessageBox.Show("Data Updated Successfully");
            ClearAllData();

            DataRefresh();
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            objdelete.DeleteBookInfo("Delete Books Where BookID='" + lblID.Text + "'");
            MessageBox.Show("Data Deleted Successfully");
            ClearAllData();

            DataRefresh();
            
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.ShowDialog();
        }
    }
}
