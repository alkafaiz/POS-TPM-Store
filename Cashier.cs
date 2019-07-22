using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace POS_TPM__store
{
    class Cashier : Employee
    {
        Connection conn = new Connection();
        public void SearchProduct(ListBox listboxname, string keyword, DataGridView gridName, List<int> listname)
        {
            conn.getConnected.Open();
            SqlCommand cmd = new SqlCommand("Select Product_Code, Description, Unit_Price, Discount, Tax_Code from Product Where (Product_Code like '%" + keyword + "%') or (Description like '%" + keyword + "%') or(Category like '%" + keyword + "%') or(Supplier like '%" + keyword + "%') ", conn.getConnected);
            SqlDataReader dr = cmd.ExecuteReader();
            listboxname.Items.Clear();
            while (dr.Read())
            {
                //converting to string
                string desc, tcode;
                int pID;
                decimal uprc, disc;
                pID = Convert.ToInt32(dr[0].ToString());
                desc = dr[1].ToString();
                uprc = Convert.ToDecimal(dr[2].ToString());
                tcode = dr[4].ToString();                
                disc = Convert.ToDecimal(dr[3].ToString());

                Product pr = new Product(pID, desc, uprc, tcode, disc);
                
                bool exist;
                if(listname.Contains(pr.SetorGetProduct_Code) == false)
                {
                    listboxname.Items.Add(desc);
                }
                //using (FormMain form = new FormMain())
                //{
                //    exist = form.cartItem.Contains(pr.SetorGetProduct_Code);
                //}
                //if (exist == false)
                //{
                //    listboxname.Items.Add(desc);
                //    using (FormMain frm = new FormMain())
                //    {
                //        frm.test = true;
                //    }
                //}

                //listboxname.Items.Add(desc);
            }
            conn.getConnected.Close();
        }

        public decimal SubTotal(decimal Qty, decimal UnitPrice, decimal Discount)
        {
            decimal Subtotal = (UnitPrice - Discount) * Qty;
            //int n = gridName.Rows.Add();
            //gridName.Rows[n].Cells[6].Value = Subtotal;
            return Subtotal;
        }

        public string grandTotal(DataGridView dgv)
        {
            decimal totalAmount = 0;
            int n = dgv.RowCount;
            for (int i = 0; i < n; i++)
            {
                totalAmount += Convert.ToDecimal(dgv.Rows[i].Cells[6].Value.ToString());
            }
            return totalAmount.ToString() ;
        }

        public void AddCart(string descProd, DataGridView gridname, double qty, TextBox tb)
        {
            conn.getConnected.Open();
            SqlCommand cmd = new SqlCommand("Select Product_Code, Description, Unit_Price, Tax_Code, Discount from Product Where (Description = '" + descProd + "')", conn.getConnected);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                Product pr = new Product(Convert.ToInt32(dr[0].ToString()), dr[1].ToString(), Convert.ToDecimal(dr[2].ToString()), dr[3].ToString(), Convert.ToDecimal(dr[4].ToString()))  ;
                int n = gridname.Rows.Add();
                gridname.Rows[n].Cells[0].Value = pr.SetorGetProduct_Code;
                gridname.Rows[n].Cells[1].Value = pr.SetorGetDesc;
                gridname.Rows[n].Cells[2].Value = pr.SetorGetUnit_Price;
                gridname.Rows[n].Cells[5].Value = pr.SetorGetTax_Code;
                gridname.Rows[n].Cells[4].Value = qty;
                gridname.Rows[n].Cells[3].Value = pr.SetorGetDiscount;
                gridname.Rows[n].Cells[6].Value = (Convert.ToDouble(pr.SetorGetUnit_Price)- Convert.ToDouble(pr.SetorGetDiscount))* qty;
                tb.Text = "RM "+Convert.ToString((Convert.ToDouble(pr.SetorGetUnit_Price) - Convert.ToDouble(pr.SetorGetDiscount)) * qty);

            }
            conn.getConnected.Close();
        }

        public void PrintReceipt(SalesTransaction st)
        {
            conn.getConnected.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO Sales_Transaction (Invoice_ID, Cashier, Customer, Date, Time, Total_Amount, Total_Qty, GST, Payment_Method) 
VALUES('" + st.SetorGetInvoice_Code + "', '" + st.SetorGetCashier + "' , '" + st.SetorGetCustomer + "' , '" + st.SetorGetDate + "' , '" + st.SetorGetTime + "' , '" + st.SetorGetTotalAmount + "' , '" + st.SetorGetTotalQty + "' , '" + st.SetorGetGST + "', '"+st.SetorGetPayment+"' ) ", conn.getConnected);
            cmd.ExecuteNonQuery();
            conn.getConnected.Close();
        }

        public decimal TotalGST(DataGridView dgv)
        {
            decimal totalGST = 0;
            int n = dgv.RowCount;
            for (int i = 0; i < n; i++)
            {
                if(dgv.Rows[i].Cells[5].Value.ToString() == "S")
                {
                    double itemGST = Convert.ToDouble(dgv.Rows[i].Cells[6].Value.ToString()) * 0.06;
                    totalGST += Convert.ToDecimal(itemGST);
                }                
            }
            return totalGST;
        }

        public decimal TotalItempriceGST(DataGridView dgv)
        {
            decimal ItemGST = 0;
            int n = dgv.RowCount;
            for (int i = 0; i < n; i++)
            {
                if (dgv.Rows[i].Cells[5].Value.ToString() == "S")
                {
                    double iGST = Convert.ToDouble(dgv.Rows[i].Cells[6].Value.ToString());
                    ItemGST += Convert.ToDecimal(iGST);
                }
            }
            return ItemGST;
        }

        public void deductstock(DataGridView dgv)
        {
            conn.getConnected.Open();
            int n = dgv.RowCount;
            int x = 0;            
            for (int i = 0; i < n; i++)
            {
                int dstock = Convert.ToInt32(dgv.Rows[i].Cells[4].Value.ToString());
                int currentstock = 0;
                int ustock = 0;
                SqlCommand cmd1 = new SqlCommand("Select Stock from Product Where ( Product_Code ='" + dgv.Rows[i].Cells[0].Value.ToString() + "')", conn.getConnected);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                while (dr1.Read())
                {
                    currentstock = Convert.ToInt32(dr1[0].ToString());
                    ustock = currentstock - dstock;
                    
                }
                dr1.Close();
                SqlCommand cmd = new SqlCommand("Update Product SET Stock='" + ustock + "' Where (Product_Code='" + dgv.Rows[i].Cells[0].Value.ToString() + "') ", conn.getConnected);
                cmd.ExecuteNonQuery();
            }
            conn.getConnected.Close();
        }

    }
}
