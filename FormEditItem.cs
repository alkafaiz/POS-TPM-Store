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
    public partial class FormEditItem : Form
    {
        Connection conn = new Connection();
        Supervisor sp = new Supervisor();
        string currentPermission = "";
        public FormEditItem()
        {
            InitializeComponent();
        }
        public FormEditItem(string cPermission)
        {
            InitializeComponent();
            currentPermission = cPermission;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void FormEditItem_Load(object sender, EventArgs e)
        {
            //check status
            if (currentPermission == "ReadData Only")
            {
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
                btnSave.Enabled = false;
            }

            numericUpDownUnitPrice.DecimalPlaces = 2;
            numericUpDownUnitPrice.Increment = 0.01M;
            numericUpDownDiscount.DecimalPlaces = 2;
            numericUpDownDiscount.Increment = 0.01M;
            //display();
            //replacing display function
            sp.displayItem(dataGridView1);
            //check category
            conn.getConnected.Open();
            SqlCommand cmd = new SqlCommand("Select Category from Product Group by Category", conn.getConnected);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            conn.getConnected.Close();
            //check supplier
            conn.getConnected.Open();
            SqlCommand cmd2 = new SqlCommand("Select Supplier from Product Group by Supplier", conn.getConnected);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                comboBoxSupplier.Items.Add(dr2[0]);
            }
            conn.getConnected.Close();



        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Product pr = new Product(Convert.ToInt32(txtProductCode.Text));
            sp.DeleteItem(pr);
            MessageBox.Show("Deleted!");
            sp.displayItem(dataGridView1);
        }
        private void display()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Product", conn.getConnected);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item[5].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item[6].ToString();
                dataGridView1.Rows[n].Cells[7].Value = item[7].ToString();
                dataGridView1.Rows[n].Cells[8].Value = item[8].ToString();
                dataGridView1.Rows[n].Cells[9].Value = item[9].ToString();
            }
           
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            txtProductCode.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtDesc.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            numericUpDownUnitPrice.Value = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            //condition for tacCode
            string taxCode = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            if (taxCode == "S")
            {
                rbtnStandardRated.Checked = true;
                txtTax.Text = "0.06";
            }

            else
            {
                rbtnZeroRated.Checked = true;
                txtTax.Text = "0.00";
            }                                        
            numericUpDownDiscount.Value = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[5].Value.ToString());
            numericUpDownStock.Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[6].Value.ToString());
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            comboBoxSupplier.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            string updatedTaxCode = "";
            if (rbtnStandardRated.Checked == true)
                updatedTaxCode = "S";
            if (rbtnZeroRated.Checked == true)
                updatedTaxCode = "Z";
            //creating class for product
            string desc, tcode, catgr, exdt, supplr;
            int pID, stck;
            decimal uprc, tax, disc;
            pID = Convert.ToInt32(txtProductCode.Text);
            desc = txtDesc.Text;
            uprc = Convert.ToDecimal(numericUpDownUnitPrice.Value.ToString());
            tcode = updatedTaxCode;
            tax = Convert.ToDecimal(txtTax.Text);
            disc = Convert.ToDecimal(numericUpDownDiscount.Value.ToString());
            stck = Convert.ToInt32(numericUpDownStock.Value.ToString());
            catgr = comboBox1.Text;
            exdt = dateTimePicker1.Text;
            supplr = comboBoxSupplier.Text;

            Product pr = new Product();
            pr.AddDetail(pID, desc, uprc, tcode, tax, disc, stck, catgr, exdt, supplr);
            sp.UpdateItem(pr); //supplier execution, middlepoint to database
            MessageBox.Show("item has been updated!");
            sp.displayItem(dataGridView1);
            
        }

        private void rbtnStandardRated_CheckedChanged(object sender, EventArgs e)
        {
            txtTax.Text = "0.06";
        }

        private void rbtnZeroRated_CheckedChanged(object sender, EventArgs e)
        {
            txtTax.Text = "0.00";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            sp.SearchItem(dataGridView1, txtSearch.Text);
        }
    }
}
