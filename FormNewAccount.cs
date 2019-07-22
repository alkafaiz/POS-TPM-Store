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
    public partial class FormNewAccount : Form
    {
        public FormNewAccount()
        {
            InitializeComponent();
        }

        private void FormNewAccount_Load(object sender, EventArgs e)
        {
            
        }

        private string NewEmployeeID()
        {
            using (FormNewCustomer form = new FormNewCustomer())
            {
                return form.Generate_ID();
            }
            
        }
        private void btnGenerateID_Click(object sender, EventArgs e)
        {
            txtEmployeeID.Text = NewEmployeeID();
        }

        private void FormNewAccount_Load_1(object sender, EventArgs e)
        {
            txtEmployeeID.Text = NewEmployeeID();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Employee newEmp = new Employee();
            newEmp.SetorGetName = txtName.Text;
            newEmp.SetorGetIC = txtIC.Text;
            newEmp.SetorGetDateCreation = dateCreation.Text;
            newEmp.SetorGetAddress = txtAddress.Text;
            newEmp.SetorGetCity = txtCity.Text;
            newEmp.SetorGetState = txtState.Text;
            if (txtPostCode.Text != "") { newEmp.SetorGetPostCode = Convert.ToInt32(txtPostCode.Text); }

            newEmp.SetorGetPhone = Convert.ToInt32(txtPhone.Text);
            newEmp.SetorGetEmail = txtEmail.Text;
            newEmp.SetorGetEmployeeID = txtEmployeeID.Text;
            string gender = "";
            if (rbtnMale.Checked == true) { gender = "Male"; }
            else if (rbtnFemale.Checked == true) { gender = "Female"; }
            newEmp.SetorGetGender = gender;
            newEmp.SetorGetPosition = comboBoxPosition.Text;
            newEmp.SetorGetUsername = txtUsername.Text;
            newEmp.SetorGetPassword = txtPassword.Text;
            newEmp.SetorGetPermission = comboBoxPermission.Text;

            Supervisor sp = new Supervisor();
            sp.CreateEmployee(newEmp);

            MessageBox.Show("New Employee\n\nName : " + newEmp.SetorGetName + "\nEmployee ID : " + newEmp.SetorGetEmployeeID + "\n\nHas been created!", "New Employee");
        }

        private void txtConfirmPass_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtConfirmPass.Text)
            {
                lblPassdm.Visible = false;
            }
            else lblPassdm.Visible = true;
        }

        private void comboBoxPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPosition.SelectedIndex == 1)
            {
                comboBoxPermission.Items.Clear();
                comboBoxPermission.Items.Add("Checkout Only");
            }
            else if (comboBoxPosition.SelectedIndex == 0)
            {
                comboBoxPermission.Items.Clear();
                comboBoxPermission.Items.Add("Checkout Only");
                comboBoxPermission.Items.Add("ReadData Only");
                comboBoxPermission.Items.Add("Full Access");
            }
        }
    }
}
