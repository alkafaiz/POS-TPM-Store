using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_TPM__store
{
    public partial class FormNewCustomer : Form
    {
        public FormNewCustomer()
        {
            InitializeComponent();
        }
        

        public string Generate_ID()
        {
            Random random = new Random();
            string input = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < 3; i++)
            {
                ch = input[random.Next(0, input.Length)];
                builder.Append(ch);
            }
           
            int myRandomNo = random.Next(100000, 999999);
            
            return builder.ToString()+myRandomNo.ToString();
        }
        private void btnGenerateID_Click(object sender, EventArgs e)
        {
            txtCustomerID.Text = Generate_ID(); //generate_ID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormNewCustomer_Load(object sender, EventArgs e)
        {
            txtCustomerID.Text = Generate_ID();
            DateTime dt = DateTime.Now;
            lbldatenow.Text = dt.ToString("MM/dd/yyyy");
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Customer newCust = new Customer();
            newCust.SetorGetName = txtName.Text;
            newCust.SetorGetIC = txtIC.Text;
            newCust.SetorGetRegistrationDate = lbldatenow.Text;
            newCust.SetorGetAddress = txtAddress.Text;
            newCust.SetorGetCity = txtCity.Text;
            newCust.SetorGetState = txtState.Text;
            if(txtPostCode.Text != "") { newCust.SetorGetPostCode = Convert.ToInt32(txtPostCode.Text); }
            
            newCust.SetorGetPhone = Convert.ToInt32(txtPhone.Text);
            newCust.SetorGetEmail = txtEmail.Text;
            newCust.SetorGetCustomerID = txtCustomerID.Text;
            string gender = "";
            if (rbtnMale.Checked == true) { gender = "Male"; }
            else if (rbtnFemale.Checked == true) { gender = "Female"; }                
            newCust.SetorGetGender = gender;
         
            Supervisor sp = new Supervisor();
            sp.CreateCustomer(newCust.SetorGetCustomerID, newCust.SetorGetName, newCust.SetorGetIC, newCust.SetorGetGender, newCust.SetorGetAddress, newCust.SetorGetCity, newCust.SetorGetState, newCust.SetorGetPostCode, newCust.SetorGetPhone, newCust.SetorGetEmail, newCust.SetorGetRegistrationDate, 0);

            MessageBox.Show("New Customer\n\nName : " + newCust.SetorGetName + "\nCustomer ID : " + newCust.SetorGetCustomerID + "\n\nHas been created!", "New Customer");
            reset_form();
        }

        private void reset_form()
        {
            txtName.ResetText();
            txtIC.ResetText();
            txtPhone.ResetText();
            txtPostCode.ResetText();
            txtState.ResetText();
            txtEmail.ResetText();
            txtCity.ResetText();
            txtAddress.ResetText();
            txtCustomerID.Text = Generate_ID();
        }
    }
}
