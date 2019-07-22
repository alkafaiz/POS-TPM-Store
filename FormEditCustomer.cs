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


namespace POS_TPM__store
{
    public partial class FormEditCustomer : Form
    {
        Connection conn = new Connection();
        Supervisor sp = new Supervisor();
        private string currentPermission = "";
        public FormEditCustomer()
        {
            InitializeComponent();
        }
        public FormEditCustomer( string cPermission)
        {
            InitializeComponent();
            currentPermission = cPermission;
        }
        private void display()
        {
//            conn.getConnected.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Customer", conn.getConnected);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridViewCustInfo.Rows.Clear();

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridViewCustInfo.Rows.Add();
                dataGridViewCustInfo.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridViewCustInfo.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridViewCustInfo.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridViewCustInfo.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridViewCustInfo.Rows[n].Cells[4].Value = item[4].ToString();
                dataGridViewCustInfo.Rows[n].Cells[5].Value = item[5].ToString();
                dataGridViewCustInfo.Rows[n].Cells[6].Value = item[6].ToString();
                dataGridViewCustInfo.Rows[n].Cells[7].Value = item[7].ToString();
                dataGridViewCustInfo.Rows[n].Cells[8].Value = item[8].ToString();
                dataGridViewCustInfo.Rows[n].Cells[9].Value = item[9].ToString();
                dataGridViewCustInfo.Rows[n].Cells[10].Value = item[10].ToString();
                dataGridViewCustInfo.Rows[n].Cells[11].Value = item[11].ToString();
                
            }

        } //not used anymore, shifting to class function
        private void FormEditCustomer_Load(object sender, EventArgs e)
        {
            //check status

            //label13.Text = currentPermission;
            if(currentPermission == "ReadData Only")
            {
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
                btnSave.Enabled = false;
            }
            
            //display data            
            sp.displayCustomer(dataGridViewCustInfo);
            //try
            //{
            //    Supervisor sp = new Supervisor();
            //    sp.displayCustomer(dataGridViewCustInfo);
            //}
            //catch
            //{
            //   // MessageBox.Show("failure");
            //    display();
            //}


            if (ConnectionState.Closed == conn.getConnected.State) conn.getConnected.Open();
        }

        private void dataGridViewCustInfo_MouseClick(object sender, MouseEventArgs e)
        {
            txtCustomerID.Text = dataGridViewCustInfo.SelectedRows[0].Cells[0].Value.ToString();
            txtName.Text = dataGridViewCustInfo.SelectedRows[0].Cells[1].Value.ToString();
            txtIC.Text = dataGridViewCustInfo.SelectedRows[0].Cells[2].Value.ToString();
            if (dataGridViewCustInfo.SelectedRows[0].Cells[3].Value.ToString() == "Male")
                rbtnMale.Checked = true;
            else rbtnFemale.Checked = true;
            txtAddress.Text = dataGridViewCustInfo.SelectedRows[0].Cells[4].Value.ToString();
            txtCity.Text = dataGridViewCustInfo.SelectedRows[0].Cells[5].Value.ToString();
            txtState.Text = dataGridViewCustInfo.SelectedRows[0].Cells[6].Value.ToString();
            txtPostCode.Text = dataGridViewCustInfo.SelectedRows[0].Cells[7].Value.ToString();
            txtPhone.Text = dataGridViewCustInfo.SelectedRows[0].Cells[8].Value.ToString();
            txtEmail.Text = dataGridViewCustInfo.SelectedRows[0].Cells[9].Value.ToString();
            dateRegis.Text = dataGridViewCustInfo.SelectedRows[0].Cells[10].Value.ToString();
            
        } //onclick gridview event

        private void btnUpdate_Click(object sender, EventArgs e)
        {                      
            string updtGender = "";
            if (rbtnMale.Checked == true) { updtGender = "Male"; }
            else updtGender = "Female";
            //create class for updated customer
            Customer ct = new Customer();
            ct.updateDetail(txtName.Text, txtIC.Text, txtAddress.Text, txtCity.Text, txtState.Text, Convert.ToInt32(txtPostCode.Text), Convert.ToInt32(txtPhone.Text), txtEmail.Text, updtGender, txtCustomerID.Text);
            //call function of supervisor to execute updation 
            sp.UpdateCustomer(ct);
            //sp.UpdateCustomer(txtCustomerID.Text, txtName.Text, txtIC.Text, updtGender, txtAddress.Text, txtCity.Text, txtState.Text, Convert.ToInt32(txtPostCode.Text), txtPhone.Text, txtEmail.Text);
            MessageBox.Show("Customer has been updated!", "Update Successful");
            sp.displayCustomer(dataGridViewCustInfo); //update gridview
            reset();
        }

        private void reset()
        {
            txtCustomerID.ResetText();
            txtName.ResetText();
            txtIC.ResetText();
            rbtnMale.Checked = true;            
            txtAddress.ResetText();
            txtCity.ResetText();
            txtState.ResetText();
            txtPostCode.ResetText();
            txtPhone.ResetText();
            txtEmail.ResetText();
            dateRegis.ResetText();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
            Customer ct = new Customer(txtCustomerID.Text);
            sp.DeleteCustomer(ct);
            MessageBox.Show("Customer has been deleted!", "Deletion Successfull");
            sp.displayCustomer(dataGridViewCustInfo); //update gridview
            reset();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) 
        {            
            sp.SearchCustomer(dataGridViewCustInfo, txtSearch.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
