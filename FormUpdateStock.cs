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
    
    public partial class FormUpdateStock : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=HPPAV14\HPPAV14;Initial Catalog=IOOP_Assignment_try2;Integrated Security=True");
        public FormUpdateStock()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void display()
        {
            
            SqlDataAdapter sda = new SqlDataAdapter("Select Product_Code, Description, Stock from Product", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridViewFullItem.Rows.Clear();

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridViewFullItem.Rows.Add();
                dataGridViewFullItem.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridViewFullItem.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridViewFullItem.Rows[n].Cells[2].Value = item[2].ToString();

            }

        }

        private void FormUpdateStock_Load(object sender, EventArgs e)
        {
            display();

        }

        private void txtSearchCode_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select Product_Code, Description, Stock from Product Where (Product_Code like '%"+txtSearchCode.Text+ "%') or (Description like '%" + txtSearchCode.Text + "%') or (Supplier like '%" + txtSearchCode.Text + "%') ", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridViewFullItem.Rows.Clear();

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridViewFullItem.Rows.Add();
                dataGridViewFullItem.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridViewFullItem.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridViewFullItem.Rows[n].Cells[2].Value = item[2].ToString();
            }
        }

      

        private void btnSelect_Click(object sender, EventArgs e)
        {
            
            SqlDataAdapter sda = new SqlDataAdapter("Select Product_Code, Description, Category, Supplier, Stock from Product Where Product_Code = '" + dataGridViewFullItem.SelectedRows[0].Cells[0].Value.ToString() + "' ", conn);            
            DataTable dt = new DataTable();

            sda.Fill(dt);
            txtProductCode.Text = dt.Rows[0][0].ToString();
            txtDesc.Text = dt.Rows[0][1].ToString();
            txtSupplier.Text= dt.Rows[0][3].ToString();
            txtCategory.Text = dt.Rows[0][2].ToString();  
            txtCrtStock.Text = dt.Rows[0][4].ToString();                                 
        }

        private void added_Stock(decimal amount_added)
        {
            decimal current_stock = numericUpDownADDSTOCK.Value;
            decimal newStock = current_stock + amount_added;
            numericUpDownADDSTOCK.Value = newStock;
            
        }

        private void btnAdd5_Click(object sender, EventArgs e)
        {
            added_Stock(5);
        }

        private void btnAdd10_Click(object sender, EventArgs e)
        {
            added_Stock(10);
        }

        private void btnAdd30_Click(object sender, EventArgs e)
        {
            added_Stock(30);
        }

        private void btnAdd50_Click(object sender, EventArgs e)
        {
            added_Stock(50);
        }

        private void btnAdd100_Click(object sender, EventArgs e)
        {
            added_Stock(100);
        }

        private void btnAdd500_Click(object sender, EventArgs e)
        {
            added_Stock(500);
        }

        private void btnADDStock_Click(object sender, EventArgs e)
        {
            int n = dataGridViewUPDATESTOCK.Rows.Add();
            dataGridViewUPDATESTOCK.Rows[n].Cells[0].Value = txtProductCode.Text;
            dataGridViewUPDATESTOCK.Rows[n].Cells[1].Value = txtDesc.Text;
            dataGridViewUPDATESTOCK.Rows[n].Cells[2].Value = txtCrtStock.Text;
            dataGridViewUPDATESTOCK.Rows[n].Cells[3].Value = numericUpDownADDSTOCK.Value.ToString();
            dataGridViewUPDATESTOCK.Rows[n].Cells[4].Value = (Convert.ToDecimal(txtCrtStock.Text)+numericUpDownADDSTOCK.Value).ToString();
            numericUpDownADDSTOCK.Value = 0;
        }

        private void dataGridViewUPDATESTOCK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnConfirmUpdate_Click(object sender, EventArgs e)
        {
            //Console.Write(dataGridViewUPDATESTOCK.Rows[0].Cells[0].Value.ToString());
            int numOfRows = dataGridViewUPDATESTOCK.RowCount;
            for (int i = 0; i < numOfRows; i++)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update Product SET Stock ='" + dataGridViewUPDATESTOCK.Rows[i].Cells[4].Value.ToString() + "' Where (Product_Code='" + dataGridViewUPDATESTOCK.Rows[i].Cells[0].Value.ToString() + "') ", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                
            }
            MessageBox.Show("stock has been updated!");
            dataGridViewUPDATESTOCK.Rows.Clear();
            display();

        }
    }
}
