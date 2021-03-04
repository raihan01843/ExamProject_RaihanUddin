using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace ExamProject_Raihan
{
    public partial class Borrower : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;
        DataRow dr;
        

        InsertBorrower objBorrower = new InsertBorrower();

        DeleteBorrower objDelete = new DeleteBorrower();

        UpdateBorrower objUpdate = new UpdateBorrower();


        public void GetBookID()
        {
            using (con = new SqlConnection(cs))
            {
                con.Open();
                cmd = new SqlCommand("Select * From Books", con);
                adapter = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adapter.Fill(dt);

                dr = dt.NewRow();
                dr.ItemArray = new object[] { 0, "--Select BookID--" };
                dt.Rows.InsertAt(dr, 0);

                cmBoxBookID.ValueMember = "BookID";
                cmBoxBookID.DisplayMember = "BookID";

                cmBoxBookID.DataSource = dt;
                con.Close();

            }
        }
        //string imageLocation = "";
        InsertedMethod objinsert = new InsertedMethod();
        public Borrower()
        {
            InitializeComponent();
            GetBookID();
            RefreshBorrowerInfo();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            File.Copy(txtImageLink.Text, Path.Combine(@"C:\Users\RAIHAN  UDDIN\Desktop\1258319\ExamProject_Raihan\ExamProject_Raihan\images", Path.GetFileName(txtImageLink.Text)), true);


            objBorrower.InsertData("Insert Into Borrower Values('" + txtName.Text + "','" + txtAddress.Text + "','" + txtPhoneNo.Text + "','" + txtGender.Text + "','" + txtImageLink.Text + "','" + cmBoxBookID.SelectedValue + "')");
            MessageBox.Show("Data Inserted Successfully");
            RefreshBorrowerInfo();
            ClearBookInfo();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrows_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*jpg; *jpeg; *gif; *bmp;)|*jpg; *jpeg; *gif; *bmp;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtImageLink.Text = open.FileName;
                picBoxBorrower.Image = new Bitmap(open.FileName);

            }
        }
        public void RefreshBorrowerInfo()
        {
            using (con = new SqlConnection(cs))
            {
                adapter = new SqlDataAdapter("SELECT * FROM Borrower", con);
                dt = new DataTable();
                adapter.Fill(dt);
                dgBorrower.DataSource = dt;
            }
        }

        public void ClearBookInfo()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtPhoneNo.Text = "";
            txtImageLink.Text = "";
            cmBoxBookID.SelectedValue = false;
            picBoxBorrower.Image = null;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.ShowDialog();
        }

        private void dgBorrower_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lblIDB.Text = this.dgBorrower.CurrentRow.Cells["BorrowerID"].Value.ToString();
            txtName.Text = this.dgBorrower.CurrentRow.Cells["BorrowerName"].Value.ToString();
            txtAddress.Text = this.dgBorrower.CurrentRow.Cells["BorrowerAddress"].Value.ToString();
            txtPhoneNo.Text = this.dgBorrower.CurrentRow.Cells["BorrowerPhoneNO"].Value.ToString();
            txtGender.Text = this.dgBorrower.CurrentRow.Cells["Gender"].Value.ToString();
            txtImageLink.Text = this.dgBorrower.CurrentRow.Cells["Image"].Value.ToString();
            cmBoxBookID.Text = this.dgBorrower.CurrentRow.Cells["BookID"].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            objUpdate.UpdateBorr("Update Borrower Set BorrowerName= '" + txtName.Text + "', BorrowerAddress= '" + txtAddress.Text + "', BorrowerPhoneNO= '" + txtPhoneNo.Text + "', Gender= '" + txtGender.Text + "',Image= '" + txtImageLink.Text + "',BookID= '" + cmBoxBookID.SelectedValue + "' Where BorrowerID='" + lblIDB.Text + "'");

            MessageBox.Show("Data Updated SuccessFully");
            ClearBookInfo();

            RefreshBorrowerInfo();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            objDelete.DeleteData("Delete Borrower Where BorrowerID='" + lblIDB.Text + "'");
            MessageBox.Show("Data Deleted SuccessFully");

            ClearBookInfo();
            RefreshBorrowerInfo();
        }
    }
}
