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
    public partial class FormMain : Form
    {
        Connection conn = new Connection();
        Employee emp = new Employee();
        Supervisor sp = new Supervisor();
        Cashier cs = new Cashier();
        public bool test = false;
        private string currentUsername = "";
        private string currentPosition = "";
        private string currentPermission = "";
        public List<int> cartItem = new List<int>();
        List<Receipt> purchasedItems = new List<Receipt>();
        int totalQty = 0;

        public string getCurrentPermission()
        {
            return currentPermission;
        }

        public FormMain(string account, string username)
        {
            InitializeComponent();
            currentPosition = account;
            lblAccount.Text = account;
            currentUsername = username;
            timer1.Start();

           
        }

        public FormMain()
        {
            InitializeComponent();
            
        }

       

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormSingleLogin form = new FormSingleLogin();
            form.Show();
        }

        private void manageInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEditItem form = new FormEditItem(currentPermission);
            form.ShowDialog();
        }

        private void updateInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUpdateStock form = new FormUpdateStock();
            form.ShowDialog();
        }

        private void creditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This application is under development", "Credit",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void contactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("contact me @ alkafaiz99@gmail.com", "contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void addNewItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddItem form = new FormAddItem();
            form.ShowDialog();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
            //if (lblAccount.Text != "Supervisor")
            //    ManageToolStripMenuItem.Visible = false;
            comboBoxCustomer.SelectedIndex = 0;
            if (ConnectionState.Closed == conn.getConnected.State) conn.getConnected.Open();
            emp.RetrieveName(currentUsername, txtcashierName);
            currentPermission = emp.RetrievePermission(currentUsername);
            label8.Text = currentPermission;
            //identify user and granted access
            if (currentPosition == "Cashier" && currentPermission == "Checkout Only")
            {
                ManageToolStripMenuItem.Visible = false;
                AccountToolStripMenuItemAccount.Visible = false;
                reportToolStripMenuItem.Visible = false;
            }
            if(currentPosition == "Supervisor" && currentPermission == "ReadData Only")
            {
                editItemToolStripMenuItem.Text = "View Item";
                updateInventoryToolStripMenuItem.Visible = false;
                addNewItemToolStripMenuItem.Visible = false;
                editCustomerToolStripMenuItem.Text = "View Customer";
                newCustomerToolStripMenuItem.Visible = false;
                AccountToolStripMenuItemAccount.Visible = false;
                      
            }

            DateTime dt = DateTime.Now;
            lblDate.Text = dt.ToString("MM/dd/yyyy");

            txtInvoiceID.Text = Generate_InvoiceID();
            txtSearch.Focus();

            comboBoxPayment.SelectedIndex = 0;

            //check for threshold
            sp.checkThreshold();


        }

        public string Generate_InvoiceID()
        {
            Random random = new Random();
            string input = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < 4; i++)
            {
                ch = input[random.Next(0, input.Length)];
                builder.Append(ch);
            }

            int myRandomNo = random.Next(100000, 999999);

            return builder.ToString() + myRandomNo.ToString();
        }

        private void newCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNewCustomer newCust = new FormNewCustomer();
            newCust.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.lblTime.Text = dateTime.ToString();
        }

        private void editCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEditCustomer form = new FormEditCustomer(currentPermission);
            form.ShowDialog();
        }

        private void comboBoxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCustomer.SelectedIndex == 1)
            {
                using (FormCustomerCheckin form = new FormCustomerCheckin())
                {
                    form.ShowDialog();
                    if (form.Granted == true) {
                        comboBoxCustomer.Visible = false;
                        txtCustomerCheckedin.Visible = true;
                        txtCustomerCheckedin.Text = form.CustName;
                        txtAddress.Text = form.Address;
                    }
                    else if (form.DialogResult == DialogResult.Cancel)
                    {
                        comboBoxCustomer.SelectedIndex = 0;
                    }
                    
                                            
                    
                }
            }
        }

        private void newAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNewAccount form = new FormNewAccount();
            form.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            listBoxSearch.Visible = true;
            cs.SearchProduct(listBoxSearch, txtSearch.Text, dataGridViewPurcases, cartItem);
        }

        private void FormMain_MouseClick(object sender, MouseEventArgs e)
        {
            listBoxSearch.Visible = false;
        }

        private void listBoxSearch_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string tmp = "";
            listBoxSearch.Visible = false;
            txtDesc.ResetText();
            txtItemcode.ResetText();
            txtDesc.Text = listBoxSearch.SelectedItem.ToString();
            SqlCommand cmd = new SqlCommand("select Product_Code from Product where(Description='" + listBoxSearch.SelectedItem.ToString() + "')", conn.getConnected);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) { tmp = dr[0].ToString();  }
            //tmp = dr[0].ToString();
            dr.Close();
            txtItemcode.Text = tmp;


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtcheckedoutdesc.Visible = true;
            txtcheckedoutItemcode.Visible = true;
            txtcheckedoutprice.Visible = true;
            txtcheckedoutqty.Visible = true;
            //condition if item is already exist in cart
            if (cartItem.Contains(Convert.ToInt32(txtItemcode.Text)) == true) MessageBox.Show(txtDesc.Text + " has already been in cart", "Information");
            else
            {
                double qty = Convert.ToDouble(numericUpDownQty.Value);
                cs.AddCart(txtDesc.Text, dataGridViewPurcases, qty, txtcheckedoutprice);
                cartItem.Add(Convert.ToInt32(txtItemcode.Text));
                //btnNewCust.Text = cartItem[0].ToString();

                //display
                txtcheckedoutItemcode.Text = txtItemcode.Text;
                txtcheckedoutdesc.Text = txtDesc.Text;
                txtcheckedoutqty.Text = "QTY: " + numericUpDownQty.Value.ToString();
                txtGrandTotal.Text = cs.grandTotal(dataGridViewPurcases);
                txtTOTAL.Text = txtGrandTotal.Text;

                //reset condition
                txtItemcode.ResetText();
                txtDesc.ResetText();
                numericUpDownQty.Value = 1;
            }
            

        }

        private void dataGridViewPurcases_MouseClick(object sender, MouseEventArgs e)
        {
            txtItemcode.Text = dataGridViewPurcases.SelectedRows[0].Cells[0].Value.ToString();
            txtDesc.Text = dataGridViewPurcases.SelectedRows[0].Cells[1].Value.ToString();
            numericUpDownQty.Value = Convert.ToDecimal(dataGridViewPurcases.SelectedRows[0].Cells[4].Value.ToString());
        }

        private void comboBoxPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPayment.SelectedIndex == 1)
            {
                MessageBox.Show("Debit card payment option has not been ready yet", "Sorry", MessageBoxButtons.OK);
                comboBoxPayment.SelectedIndex = 0;
            }
            if (comboBoxPayment.SelectedIndex == 2)
            {
                MessageBox.Show("Credit card payment option has not been ready yet", "Sorry", MessageBoxButtons.OK);
                comboBoxPayment.SelectedIndex = 0;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridViewPurcases.SelectedRows)
            {
                dataGridViewPurcases.Rows.RemoveAt(item.Index);
                cartItem.Remove(Convert.ToInt32(item.Cells[0].Value.ToString()));
                //dataGridViewPurcases.SelectedRows[0].Cells[0].Value.ToString()
            }
        }

        private void dataGridViewPurcases_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            using(FormEditQty form = new FormEditQty(dataGridViewPurcases.SelectedRows[0].Cells[1].Value.ToString(), Convert.ToDecimal(dataGridViewPurcases.SelectedRows[0].Cells[4].Value.ToString())))
            {
                form.ShowDialog();
                if(form.DialogResult == DialogResult.OK)
                {
                    dataGridViewPurcases.SelectedRows[0].Cells[4].Value = form.newQty();
                    dataGridViewPurcases.SelectedRows[0].Cells[6].Value = form.newSubtotal(Convert.ToDecimal(dataGridViewPurcases.SelectedRows[0].Cells[2].Value), Convert.ToDecimal(dataGridViewPurcases.SelectedRows[0].Cells[3].Value));
                    txtGrandTotal.Text = cs.grandTotal(dataGridViewPurcases);
                    txtTOTAL.Text = txtGrandTotal.Text;
                }
            }
        }

        private void btnNewCust_Click(object sender, EventArgs e)
        {
            txtInvoiceID.Text = Generate_InvoiceID();
            comboBoxCustomer.SelectedIndex = 0;
            txtAddress.ResetText();
            dataGridViewPurcases.Rows.Clear();
            txtcheckedoutdesc.Visible = false;
            txtcheckedoutItemcode.Visible = false;
            txtcheckedoutprice.Visible = false;
            txtcheckedoutqty.Visible = false;
            txtGrandTotal.Text = "00.00";
            txtTOTAL.Text = "00.00";
            txtChange.Text = "00.00";
            txtCASH.Text = "00.00";
            txtItemcode.ResetText();
            txtDesc.ResetText();
            cartItem.Clear();
            comboBoxCustomer.Visible = true;
            comboBoxCustomer.SelectedIndex = 0;
            txtCustomerCheckedin.Text = "General Customer";
            txtCustomerCheckedin.Visible = false;
            totalQty = 0;
            purchasedItems.Clear();

        }

        private void buttontest_Click(object sender, EventArgs e)
        {
            if (test == true)
            {
                txtInvoiceID.Text = "succeed";
            }
        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            if(txtCASH.Text == "00.00") { MessageBox.Show("insert cash amount", "Alert!"); }
            else
            {
                //update stock
                cs.deductstock(dataGridViewPurcases);

                //calculate change
                double x = Convert.ToDouble(txtCASH.Text) - Convert.ToDouble(txtTOTAL.Text);
                double change = Math.Round(x, 2);
                txtChange.Text = change.ToString();
                //calculate total qty
                
                int n = dataGridViewPurcases.RowCount;
                for (int i = 0; i < n; i++)
                {
                    totalQty += Convert.ToInt32(dataGridViewPurcases.Rows[i].Cells[4].Value.ToString());
                    //create list for reciept
                    Receipt item = new Receipt()
                    {
                        ID = dataGridViewPurcases.Rows[i].Cells[0].Value.ToString(),
                        Desc = dataGridViewPurcases.Rows[i].Cells[1].Value.ToString(),
                        uPrice = Convert.ToDecimal(dataGridViewPurcases.Rows[i].Cells[2].Value.ToString()),
                        disc = Convert.ToDecimal(dataGridViewPurcases.Rows[i].Cells[3].Value.ToString()),
                        qty = Convert.ToInt32(dataGridViewPurcases.Rows[i].Cells[4].Value.ToString()),
                        taxcd = dataGridViewPurcases.Rows[i].Cells[5].Value.ToString(),
                        subtotal = Convert.ToDecimal(dataGridViewPurcases.Rows[i].Cells[6].Value.ToString())
                    };
                    purchasedItems.Add(item);
                }

                //calculate GST
                decimal OnlyGST = cs.TotalGST(dataGridViewPurcases);
                decimal GST = cs.TotalItempriceGST(dataGridViewPurcases);
                decimal nonGST = Convert.ToDecimal(txtTOTAL.Text) - GST;


                //create class
                SalesTransaction st = new SalesTransaction(txtInvoiceID.Text, txtcashierName.Text, txtCustomerCheckedin.Text, lblDate.Text, lblTime.Text, Convert.ToDecimal(txtTOTAL.Text), totalQty, GST, comboBoxPayment.Text);

                //enter to database
                cs.PrintReceipt(st);

                //open reciept
                FormReceipt displayReceipt = new FormReceipt(purchasedItems, txtInvoiceID.Text, totalQty, lblTime.Text, txtTOTAL.Text, txtCASH.Text, change.ToString(), txtcashierName.Text, OnlyGST.ToString(), nonGST.ToString(), GST.ToString());
                displayReceipt.ShowDialog();
            }
            
        }

        private void gSTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<SalesTransaction> lisst = sp.getTransaction();
            int numoftransa = lisst.Count;
            FormGSTReport gstreport = new FormGSTReport(lisst, lblDate.Text, txtcashierName.Text, numoftransa.ToString(), sp.totalAmount(), sp.totalGST());
            gstreport.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sp.checkThreshold();
        }
    }
}
