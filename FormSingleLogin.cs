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
    public partial class FormSingleLogin : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=HPPAV14\HPPAV14;Initial Catalog=IOOP_Assignment_try2;Integrated Security=True");
        public FormSingleLogin()
        {
            InitializeComponent();
        }

        private void login()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select Position, Username from Login Where Username ='" + txtUsername.Text + "' and Password='" + txtPassword.Text + "' ", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                this.Hide();
                FormMain form = new FormMain(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString());
                form.Show();
            }
            else
                MessageBox.Show("Wrong username or password!");
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            login();
            //SqlDataAdapter sda = new SqlDataAdapter("Select Position, Username from Login Where Username ='" + txtUsername.Text + "' and Password='" + txtPassword.Text+"' ", conn);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);

            //if (dt.Rows.Count == 1)
            //{
            //    this.Hide();
            //    FormMain form = new FormMain(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString());
            //    form.Show();
            //}
            //else
            //    MessageBox.Show("Wrong username or password!");
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

      
    }
}
