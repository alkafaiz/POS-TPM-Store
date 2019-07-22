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
    public partial class FormAddItem : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=HPPAV14\HPPAV14;Initial Catalog=IOOP_Assignment_try2;Integrated Security=True");
        public FormAddItem()
        {
            InitializeComponent();
        }

        
        private string generate_code
        {
            get
            {
                Random rnd = new Random();
                int myRandomNo = rnd.Next(10000000, 99999999);
                return myRandomNo.ToString();
            }
        }
        private void btnGenerateCode_Click(object sender, EventArgs e)
        {
            txtProductCode.Text = generate_code;
            //Random rnd = new Random();
            //int myRandomNo = rnd.Next(10000000, 99999999);
            //txtProductCode.Text = myRandomNo.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void rbtnStandardRated_CheckedChanged(object sender, EventArgs e)
        {
            txtTax.Text = "0.06";
        }

        private void rbtnZeroRated_CheckedChanged(object sender, EventArgs e)
        {
            txtTax.Text = "0.00";
        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {            
            string taxCode="";
            if (rbtnStandardRated.Checked == true)
                taxCode = "S";
            else if (rbtnZeroRated.Checked == true)
                taxCode = "Z";
            int prcd = Convert.ToInt32(txtProductCode.Text);
            decimal uprc = numericUpDownUnitPrice.Value;
            decimal taxx = Convert.ToDecimal(txtTax.Text);
            decimal discc = numericUpDownDiscount.Value;
            int stck = Convert.ToInt32(numericUpDownStock.Value);
            //create class for item(product)
            Product newProd = new Product();
            newProd.AddDetail(prcd, txtDesc.Text, uprc, taxCode, taxx, discc, stck, comboBox1.Text, dateTimePicker1.Text, comboBoxSupplier.Text);
            //store in the database
            Supervisor sp = new Supervisor();
            sp.AddItem(newProd);
            //Supervisor sp = new Supervisor();
            //sp.AddItem(newProd.SetorGetProduct_Code, newProd.SetorGetDesc, newProd.SetorGetUnit_Price, newProd.SetorGetTax_Code, newProd.SetorGetTax, newProd.SetorGetDiscount, newProd.SetorGetStock, newProd.SetorGetCategory, newProd.SetorGetExpiry_Date, newProd.SetorGetSupplier);            
            

            MessageBox.Show("Item has been added!");
            reset_form();           
        }

      
        private void FormAddItem_Load(object sender, EventArgs e)
        {
            numericUpDownUnitPrice.DecimalPlaces = 2;
            numericUpDownUnitPrice.Increment = 0.01M;
            numericUpDownDiscount.DecimalPlaces = 2;
            numericUpDownDiscount.Increment = 0.01M;
            txtProductCode.Text = generate_code;

            //check category
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select Category from Product Group by Category", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            

            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            conn.Close();

            //int n = 0;
            //while (dt.Rows[n][0].ToString() != "")
            //{
            //    comboBox1.Items.Add(dt.Rows[n][0].ToString());
            //    richTextBox1.Text = dt.Rows[n][0].ToString();
            //    n += 1;
            //}

            //check supplier
            conn.Open();
            SqlCommand cmd2 = new SqlCommand("Select Supplier from Product Group by Supplier", conn);
            SqlDataReader dr2 = cmd2.ExecuteReader();


            while (dr2.Read())
            {
                comboBoxSupplier.Items.Add(dr2[0]);
            }
            conn.Close();



        }

        private void btnNewCategory_Click(object sender, EventArgs e)
        {
            
            using (AddNewCategory form = new AddNewCategory())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    comboBox1.Items.Add(form.newCategory);
                    comboBox1.Text = form.newCategory;
                }
            }
            
            
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            using (AddNewSupplier form = new AddNewSupplier())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    comboBoxSupplier.Items.Add(form.newSupplier);
                    comboBoxSupplier.Text = form.newSupplier;
                }
            }
        }

        public void reset_form()
        {
            txtProductCode.Text = generate_code;
            txtDesc.Clear();
            numericUpDownUnitPrice.Value = 0.00M ;
            rbtnZeroRated.Checked = true;
            txtTax.Text = "0.00";
            numericUpDownDiscount.Value = 0.00M;
            numericUpDownStock.Value = 0;
            comboBox1.SelectedIndex = -1;
            dateTimePicker1.ResetText();
            comboBoxSupplier.SelectedIndex = -1;
        }

        
    }
}
