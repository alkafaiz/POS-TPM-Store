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
    public partial class FormCustomerCheckin : Form
    {
        Connection conn = new Connection();
        

        public string CustomerCheckedin
        {            
            get
            {
                return txtCustomerID.Text;
            }
        }

        public FormCustomerCheckin()
        {
            InitializeComponent();
        }

        public bool Granted = false;

        private void btnEnter_Click(object sender, EventArgs e)
        {
            checkCustomer();

            if (Granted == true)
            {
                MessageBox.Show("Customer match");
                this.Hide();
            }
            else if (Granted == false) MessageBox.Show("doesnt exist");


        }

        public string CustName, Address;

        private void checkCustomer()
        {
            if (ConnectionState.Closed == conn.getConnected.State) conn.getConnected.Open();

            string InsertedCustomer_ID = txtCustomerID.Text;
            SqlCommand cmd = new SqlCommand("Select Customer_ID, Name, Address from Customer", conn.getConnected);            
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //int n = dataGridView1.Rows.Add();
                //dataGridView1.Rows[n].Cells[0].Value = dr[0];
                //dataGridView1.Rows[n].Cells[1].Value = dr[1];
                //dataGridView1.Rows[n].Cells[2].Value = dr[2];

                if (InsertedCustomer_ID == dr[0].ToString())
                {
                    CustName = dr[1].ToString();
                    Address = dr[2].ToString();
                    Granted = true;
                }

            }
            conn.getConnected.Close();

        }

        private void FormCustomerCheckin_Load(object sender, EventArgs e)
        {
            
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }
    }
}
