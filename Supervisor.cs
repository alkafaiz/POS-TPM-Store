using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace POS_TPM__store
{

    class Supervisor : Employee

    {
               
        Connection conn = new Connection();

        public void CreateCustomer(string Cust_ID, string Cust_Name, string Cust_IC, string Cust_Gender, string Cust_Address, string Cust_City, string Cust_State, int Cust_Post_Code, int Cust_Phone, string Cust_Email, string Cust_Regis_Date, int Cust_Point)
        {
            conn.getConnected.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO Customer (Customer_ID, Name, IC, Gender, Address, City, State, Post_Code, Phone, Email, Registration_Date, Point) 
VALUES('" + Cust_ID + "', '" + Cust_Name + "' , '" + Cust_IC + "' , '" + Cust_Gender + "' , '" + Cust_Address + "' , '" + Cust_City + "' , '" + Cust_State + "' , '" + Cust_Post_Code + "' , '" + Cust_Phone + "' , '" + Cust_Email + "' , '" + Cust_Regis_Date + "' , '" + Cust_Point + "' ) ", conn.getConnected);
            cmd.ExecuteNonQuery();
            conn.getConnected.Close();
        }

        public void UpdateCustomer(string UpdtCust_ID, string UpdtCust_Name, string UpdtCust_IC, string UpdtCust_Gender, string UpdtCust_Address, string UpdtCust_City, string UpdtCust_State, int UpdtCust_Post_Code, string UpdtCust_Phone, string UpdtCust_Email)
        {
            conn.getConnected.Open();
            SqlCommand cmd = new SqlCommand(@"UPDATE Customer SET Customer_ID='" + UpdtCust_ID + "', Name='" + UpdtCust_Name + "', IC='" + UpdtCust_IC + "', Gender='" + UpdtCust_Gender + "', Address='" + UpdtCust_Address + "', City='" + UpdtCust_City + "', State='" + UpdtCust_State + "', Post_Code='" + UpdtCust_Post_Code + "', Phone='" + UpdtCust_Phone + "', Email='" + UpdtCust_Email + "' WHERE (Customer_ID='" + UpdtCust_ID + "') ", conn.getConnected);
            cmd.ExecuteNonQuery();
            conn.getConnected.Close();
        }

        public void UpdateCustomer(Customer cs)
        {
            conn.getConnected.Open();
            SqlCommand cmd = new SqlCommand(@"UPDATE Customer SET Customer_ID='" + cs.SetorGetCustomerID + "', Name='" + cs.SetorGetName + "', IC='" + cs.SetorGetIC + "', Gender='" + cs.SetorGetGender + "', Address='" + cs.SetorGetAddress + "', City='" + cs.SetorGetCity + "', State='" + cs.SetorGetState + "', Post_Code='" + cs.SetorGetPostCode + "', Phone='" + cs.SetorGetPhone + "', Email='" + cs.SetorGetEmail + "' WHERE (Customer_ID='" + cs.SetorGetCustomerID + "') ", conn.getConnected);
            cmd.ExecuteNonQuery();
            conn.getConnected.Close();
        }

        public void DeleteCustomer(string DeleteCust_ID)
        {
            conn.getConnected.Open();
            SqlCommand cmd = new SqlCommand(@"DELETE FROM Customer WHERE (Customer_ID = '" + DeleteCust_ID + "')", conn.getConnected);
            cmd.ExecuteNonQuery();
            conn.getConnected.Close();
        }

        public void DeleteCustomer(Customer ct)
        {
            conn.getConnected.Open();
            SqlCommand cmd = new SqlCommand(@"DELETE FROM Customer WHERE (Customer_ID = '" + ct.SetorGetCustomerID + "')", conn.getConnected);
            cmd.ExecuteNonQuery();
            conn.getConnected.Close();
        }

        public void SearchCustomer(DataGridView GridName, string textbox)
        {
            conn.getConnected.Open();
            SqlCommand cmd = new SqlCommand("Select * from Customer Where (Customer_ID like '%" + textbox + "%') or (Name like '%" + textbox + "%') or(IC like '%" + textbox + "%') or(City like '%" + textbox + "%') or (Phone like '%" + textbox + "%') or (Email like '%" + textbox + "%')", conn.getConnected);
            SqlDataReader dr = cmd.ExecuteReader();
            GridName.Rows.Clear();
            while (dr.Read())
            {
                //converting to string
                string CID, Name, IC, Gender, City, Address, State, Email, Regisdt;
                CID = dr[0].ToString();
                Name = dr[1].ToString();
                IC = dr[2].ToString();
                City = dr[5].ToString();
                Address = dr[4].ToString();
                State = dr[6].ToString();                
                Email = dr[9].ToString();
                Gender = dr[3].ToString();
                Regisdt = dr[10].ToString();
                int phone, pscd, poin;
                phone = Convert.ToInt32(dr[8].ToString());
                pscd = Convert.ToInt32(dr[7].ToString());
                poin = Convert.ToInt32(dr[11].ToString());
                Customer cs = new Customer(CID, Name, IC, City, Address, State, pscd, phone, Email, Gender, Regisdt, poin);

                int n = GridName.Rows.Add();
                GridName.Rows[n].Cells[0].Value = cs.SetorGetCustomerID;
                GridName.Rows[n].Cells[1].Value = cs.SetorGetName;
                GridName.Rows[n].Cells[2].Value = cs.SetorGetIC;
                GridName.Rows[n].Cells[3].Value = cs.SetorGetGender;
                GridName.Rows[n].Cells[4].Value = cs.SetorGetAddress;
                GridName.Rows[n].Cells[5].Value = cs.SetorGetCity;
                GridName.Rows[n].Cells[6].Value = cs.SetorGetState;
                GridName.Rows[n].Cells[7].Value = cs.SetorGetPostCode.ToString();
                GridName.Rows[n].Cells[8].Value = cs.SetorGetPhone;
                GridName.Rows[n].Cells[9].Value = cs.SetorGetEmail;
                GridName.Rows[n].Cells[10].Value = cs.SetorGetRegistrationDate;
                GridName.Rows[n].Cells[11].Value = cs.SetorGetPoint.ToString();

            }
            conn.getConnected.Close();
            //foreach (DataRow item in dt.Rows)
            //{
            //    int n = GridName.Rows.Add();
            //    GridName.Rows[n].Cells[0].Value = item[0].ToString();
            //    GridName.Rows[n].Cells[1].Value = item[1].ToString();
            //    GridName.Rows[n].Cells[2].Value = item[2].ToString();
            //    GridName.Rows[n].Cells[3].Value = item[3].ToString();
            //    GridName.Rows[n].Cells[4].Value = item[4].ToString();
            //    GridName.Rows[n].Cells[5].Value = item[5].ToString();
            //    GridName.Rows[n].Cells[6].Value = item[6].ToString();
            //    GridName.Rows[n].Cells[7].Value = item[7].ToString();
            //    GridName.Rows[n].Cells[8].Value = item[8].ToString();
            //    GridName.Rows[n].Cells[9].Value = item[9].ToString();
            //    GridName.Rows[n].Cells[10].Value = item[10].ToString();
            //    GridName.Rows[n].Cells[11].Value = item[11].ToString();
            //}
        }

        public void CreateEmployee(string Emp_ID, string Emp_Name, string Emp_IC, string Emp_Gender, string Emp_Address, string Emp_City, string Emp_State, int Emp_Post_Code, string Emp_Phone, string Emp_Email, string Emp_Date_Creation, string Emp_Permission, string emp_Position, string emp_Username, string emp_Password)
        {
            conn.getConnected.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO Employee (Employee_ID, Name, IC, Gender, Address, City, State, Post_Code, Phone, Email, Date_Creation, Permission, Position, Username) 
VALUES('" + Emp_ID + "', '" + Emp_Name + "' , '" + Emp_IC + "' , '" + Emp_Gender + "' , '" + Emp_Address + "' , '" + Emp_City + "' , '" + Emp_State + "' , '" + Emp_Post_Code + "' , '" + Emp_Phone + "' , '" + Emp_Email + "' , '" + Emp_Date_Creation + "' , '" + Emp_Permission + "' , '" + emp_Position + "', '" + emp_Username + "') ", conn.getConnected);
            cmd.ExecuteNonQuery();

            SqlCommand loginAdd = new SqlCommand("INSERT INTO Login (Username, Password, Position) VALUES ('" + emp_Username + "', '" + emp_Password + "', '" + emp_Position + "') ", conn.getConnected);
            loginAdd.ExecuteNonQuery();

            conn.getConnected.Close();
        }

        public void CreateEmployee(Employee emp)
        {
            conn.getConnected.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO Employee (Employee_ID, Name, IC, Gender, Address, City, State, Post_Code, Phone, Email, Date_Creation, Permission, Position, Username) 
VALUES('" + emp.SetorGetEmployeeID + "', '" + emp.SetorGetName + "' , '" + emp.SetorGetIC + "' , '" + emp.SetorGetGender + "' , '" + emp.SetorGetAddress + "' , '" + emp.SetorGetCity + "' , '" + emp.SetorGetState + "' , '" + emp.SetorGetPostCode + "' , '" + emp.SetorGetPhone + "' , '" + emp.SetorGetEmail + "' , '" + emp.SetorGetDateCreation + "' , '" + emp.SetorGetPermission + "' , '" + emp.SetorGetPosition + "', '" + emp.SetorGetUsername + "') ", conn.getConnected);
            cmd.ExecuteNonQuery();

            SqlCommand loginAdd = new SqlCommand("INSERT INTO Login (Username, Password, Position) VALUES ('" + emp.SetorGetUsername + "', '" + emp.SetorGetPassword + "', '" + emp.SetorGetPosition + "') ", conn.getConnected);
            loginAdd.ExecuteNonQuery();

            conn.getConnected.Close();
        }

        public void AddItem(int ProductCode, string Desc, decimal unitPrice, string tCode, decimal tax, decimal disc, int stock, string category, string exprdate, string supplier)
        {
            conn.getConnected.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO Product (Product_Code, Description, Unit_Price, Tax_Code, Tax, Discount, Stock, Category, Expiry_Date, Supplier) 
            VALUES('" + ProductCode + "', '" + Desc + "', '" + unitPrice + "','" + tCode + "', '" + tax + "', '" + disc + "', '" + stock + "', '" + category + "', '" + exprdate + "', '" + supplier + "')", conn.getConnected);
            cmd.ExecuteNonQuery();
            conn.getConnected.Close();
        }

        public void AddItem(Product pr)
        {
            conn.getConnected.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO Product (Product_Code, Description, Unit_Price, Tax_Code, Tax, Discount, Stock, Category, Expiry_Date, Supplier) 
            VALUES('" + pr.SetorGetProduct_Code + "', '" + pr.SetorGetDesc + "', '" + pr.SetorGetUnit_Price + "','" + pr.SetorGetTax_Code + "', '" + pr.SetorGetTax + "', '" + pr.SetorGetDiscount + "', '" + pr.SetorGetStock + "', '" + pr.SetorGetCategory + "', '" + pr.SetorGetExpiry_Date + "', '" + pr.SetorGetSupplier + "')", conn.getConnected);
            cmd.ExecuteNonQuery();
            conn.getConnected.Close();
        }

        public void displayCustomer(DataGridView dgv)
        {
            conn.getConnected.Open();
            SqlCommand cmd = new SqlCommand("Select * from Customer", conn.getConnected);
            SqlDataReader dr = cmd.ExecuteReader();            
            dgv.Rows.Clear();
            while (dr.Read())
            {
                //converting to string
                string CID, Name, IC, Gender, City, Address, State, Email, Regisdt;
                CID = dr[0].ToString();
                Name = dr[1].ToString();
                IC = dr[2].ToString();
                City = dr[5].ToString();
                Address = dr[4].ToString();
                State = dr[6].ToString();                
                Email = dr[9].ToString();
                Gender = dr[3].ToString();
                Regisdt = dr[10].ToString();
                int Phone, pscd, poin;
                Phone = Convert.ToInt32(dr[8].ToString());
                pscd = Convert.ToInt32(dr[7].ToString());
                poin = Convert.ToInt32(dr[11].ToString());
                Customer cs = new Customer(CID, Name, IC, City, Address, State, pscd, Phone, Email, Gender, Regisdt, poin);
                
                int n = dgv.Rows.Add();
                dgv.Rows[n].Cells[0].Value = cs.SetorGetCustomerID;
                dgv.Rows[n].Cells[1].Value = cs.SetorGetName;
                dgv.Rows[n].Cells[2].Value = cs.SetorGetIC;
                dgv.Rows[n].Cells[3].Value = cs.SetorGetGender;
                dgv.Rows[n].Cells[4].Value = cs.SetorGetAddress;
                dgv.Rows[n].Cells[5].Value = cs.SetorGetCity;
                dgv.Rows[n].Cells[6].Value = cs.SetorGetState;
                dgv.Rows[n].Cells[7].Value = cs.SetorGetPostCode.ToString();
                dgv.Rows[n].Cells[8].Value = cs.SetorGetPhone;
                dgv.Rows[n].Cells[9].Value = cs.SetorGetEmail;
                dgv.Rows[n].Cells[10].Value = cs.SetorGetRegistrationDate;
                dgv.Rows[n].Cells[11].Value = cs.SetorGetPoint.ToString();

            }
            conn.getConnected.Close();
            //foreach (DataRow item in dt.Rows)
            //{
            //    int n = dataGridViewCustInfo.Rows.Add();
            //    dataGridViewCustInfo.Rows[n].Cells[0].Value = item[0].ToString();
            //    dataGridViewCustInfo.Rows[n].Cells[1].Value = item[1].ToString();
            //    dataGridViewCustInfo.Rows[n].Cells[2].Value = item[2].ToString();
            //    dataGridViewCustInfo.Rows[n].Cells[3].Value = item[3].ToString();
            //    dataGridViewCustInfo.Rows[n].Cells[4].Value = item[4].ToString();
            //    dataGridViewCustInfo.Rows[n].Cells[5].Value = item[5].ToString();
            //    dataGridViewCustInfo.Rows[n].Cells[6].Value = item[6].ToString();
            //    dataGridViewCustInfo.Rows[n].Cells[7].Value = item[7].ToString();
            //    dataGridViewCustInfo.Rows[n].Cells[8].Value = item[8].ToString();
            //    dataGridViewCustInfo.Rows[n].Cells[9].Value = item[9].ToString();
            //    dataGridViewCustInfo.Rows[n].Cells[10].Value = item[10].ToString();
            //    dataGridViewCustInfo.Rows[n].Cells[11].Value = item[11].ToString();

            //}
        }

        public void displayItem(DataGridView dgv)
        {
            conn.getConnected.Open();
            SqlCommand cmd = new SqlCommand("Select * from Product", conn.getConnected);
            SqlDataReader dr = cmd.ExecuteReader();
            dgv.Rows.Clear();
            while (dr.Read())
            {
                string desc, tcode, catgr, exdt, supplr;
                int pID, stck;
                decimal uprc, tax, disc;
                pID = Convert.ToInt32(dr[0].ToString());
                desc = dr[1].ToString();
                uprc = Convert.ToDecimal(dr[2].ToString());
                tcode = dr[3].ToString();
                tax = Convert.ToDecimal(dr[4].ToString());
                disc = Convert.ToDecimal(dr[5].ToString());
                stck = Convert.ToInt32(dr[6].ToString());
                catgr = dr[7].ToString();
                exdt = dr[8].ToString();
                supplr = dr[9].ToString();


                Product pr = new Product();
                pr.AddDetail(pID, desc, uprc, tcode, tax, disc, stck, catgr, exdt, supplr);
                int n = dgv.Rows.Add();
                dgv.Rows[n].Cells[0].Value = pr.SetorGetProduct_Code;
                dgv.Rows[n].Cells[1].Value = pr.SetorGetDesc;
                dgv.Rows[n].Cells[2].Value = pr.SetorGetUnit_Price;
                dgv.Rows[n].Cells[3].Value = pr.SetorGetTax_Code;
                dgv.Rows[n].Cells[4].Value = pr.SetorGetTax;
                dgv.Rows[n].Cells[5].Value = pr.SetorGetDiscount;
                dgv.Rows[n].Cells[6].Value = pr.SetorGetStock;
                dgv.Rows[n].Cells[7].Value = pr.SetorGetCategory;
                dgv.Rows[n].Cells[8].Value = pr.SetorGetExpiry_Date;
                dgv.Rows[n].Cells[9].Value = pr.SetorGetSupplier;
            }
            conn.getConnected.Close();
            //foreach (DataRow item in dt.Rows)
            //{
            //    int n = dataGridViewCustInfo.Rows.Add();
            //    dataGridViewCustInfo.Rows[n].Cells[0].Value = item[0].ToString();
            //    dataGridViewCustInfo.Rows[n].Cells[1].Value = item[1].ToString();
            //    dataGridViewCustInfo.Rows[n].Cells[2].Value = item[2].ToString();
            //    dataGridViewCustInfo.Rows[n].Cells[3].Value = item[3].ToString();
            //    dataGridViewCustInfo.Rows[n].Cells[4].Value = item[4].ToString();
            //    dataGridViewCustInfo.Rows[n].Cells[5].Value = item[5].ToString();
            //    dataGridViewCustInfo.Rows[n].Cells[6].Value = item[6].ToString();
            //    dataGridViewCustInfo.Rows[n].Cells[7].Value = item[7].ToString();
            //    dataGridViewCustInfo.Rows[n].Cells[8].Value = item[8].ToString();
            //    dataGridViewCustInfo.Rows[n].Cells[9].Value = item[9].ToString();
            //    dataGridViewCustInfo.Rows[n].Cells[10].Value = item[10].ToString();
            //    dataGridViewCustInfo.Rows[n].Cells[11].Value = item[11].ToString();

            //}
        }

        public void UpdateItem(Product pr)
        {
            conn.getConnected.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Product SET Product_Code ='" + pr.SetorGetProduct_Code + "' , Description ='" + pr.SetorGetDesc + "', Unit_Price ='" + pr.SetorGetUnit_Price + "', Tax_Code ='" + pr.SetorGetTax_Code + "', Tax ='" + pr.SetorGetTax + "', Discount ='" + pr.SetorGetDiscount + "', Stock ='" + pr.SetorGetStock + "', Category ='" + pr.SetorGetCategory + "', Expiry_Date ='" + pr.SetorGetExpiry_Date + "', Supplier ='" + pr.SetorGetSupplier + "' WHERE (Product_Code='" + pr.SetorGetProduct_Code + "')", conn.getConnected);
            cmd.ExecuteNonQuery();
            conn.getConnected.Close();
        }

        public void DeleteItem(Product pr)
        {
            conn.getConnected.Open();
            SqlCommand cmd = new SqlCommand(@"DELETE FROM Product WHERE (Product_Code = '" + pr.SetorGetProduct_Code + "')", conn.getConnected);
            cmd.ExecuteNonQuery();
            conn.getConnected.Close();
        }

        public void SearchItem(DataGridView dgv, string textbox)
        {
            conn.getConnected.Open();
            SqlCommand cmd = new SqlCommand("Select * from Product Where (Product_Code like '%" + textbox + "%') or (Description like '%" + textbox + "%') or(Category like '%" + textbox + "%') or(Supplier like '%" + textbox + "%') ", conn.getConnected);
            SqlDataReader dr = cmd.ExecuteReader();
            dgv.Rows.Clear();
            while (dr.Read())
            {
                //converting to string
                string desc, tcode, catgr, exdt, supplr;
                int pID, stck;
                decimal uprc, tax, disc;
                pID = Convert.ToInt32(dr[0].ToString());
                desc = dr[1].ToString();
                uprc = Convert.ToDecimal(dr[2].ToString());
                tcode = dr[3].ToString();
                tax = Convert.ToDecimal(dr[4].ToString());
                disc = Convert.ToDecimal(dr[5].ToString());
                stck = Convert.ToInt32(dr[6].ToString());
                catgr = dr[7].ToString();
                exdt = dr[8].ToString();
                supplr = dr[9].ToString();


                Product pr = new Product();
                pr.AddDetail(pID, desc, uprc, tcode, tax, disc, stck, catgr, exdt, supplr);
                int n = dgv.Rows.Add();
                dgv.Rows[n].Cells[0].Value = pr.SetorGetProduct_Code;
                dgv.Rows[n].Cells[1].Value = pr.SetorGetDesc;
                dgv.Rows[n].Cells[2].Value = pr.SetorGetUnit_Price;
                dgv.Rows[n].Cells[3].Value = pr.SetorGetTax_Code;
                dgv.Rows[n].Cells[4].Value = pr.SetorGetTax;
                dgv.Rows[n].Cells[5].Value = pr.SetorGetDiscount;
                dgv.Rows[n].Cells[6].Value = pr.SetorGetStock;
                dgv.Rows[n].Cells[7].Value = pr.SetorGetCategory;
                dgv.Rows[n].Cells[8].Value = pr.SetorGetExpiry_Date;
                dgv.Rows[n].Cells[9].Value = pr.SetorGetSupplier;

            }
            conn.getConnected.Close();
            //foreach (DataRow item in dt.Rows)
            //{
            //    int n = GridName.Rows.Add();
            //    GridName.Rows[n].Cells[0].Value = item[0].ToString();
            //    GridName.Rows[n].Cells[1].Value = item[1].ToString();
            //    GridName.Rows[n].Cells[2].Value = item[2].ToString();
            //    GridName.Rows[n].Cells[3].Value = item[3].ToString();
            //    GridName.Rows[n].Cells[4].Value = item[4].ToString();
            //    GridName.Rows[n].Cells[5].Value = item[5].ToString();
            //    GridName.Rows[n].Cells[6].Value = item[6].ToString();
            //    GridName.Rows[n].Cells[7].Value = item[7].ToString();
            //    GridName.Rows[n].Cells[8].Value = item[8].ToString();
            //    GridName.Rows[n].Cells[9].Value = item[9].ToString();
            //    GridName.Rows[n].Cells[10].Value = item[10].ToString();
            //    GridName.Rows[n].Cells[11].Value = item[11].ToString();
            //}
        }

        public List<SalesTransaction> getTransaction()
        {
            int numofts = 0;
            List<SalesTransaction> xlist = new List<SalesTransaction>();
            conn.getConnected.Open();
            SqlCommand cmd = new SqlCommand("Select * from Sales_Transaction", conn.getConnected);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SalesTransaction tempo = new SalesTransaction(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), Convert.ToDecimal(dr[5].ToString()), Convert.ToInt32(dr[6].ToString()), Convert.ToDecimal(dr[7].ToString()), dr[8].ToString());
                xlist.Add(tempo);
                numofts++;
            }
            conn.getConnected.Close();
            return xlist;
        }

        public string totalAmount()
        {
            double total = 0;
            conn.getConnected.Open();
            SqlCommand cmd = new SqlCommand("Select Total_Amount from Sales_Transaction", conn.getConnected);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                double amount = Convert.ToDouble(dr[0].ToString());
                total += amount;                
            }            
            conn.getConnected.Close();
            return total.ToString();
        }

        public string totalGST()
        {
            double total = 0;
            conn.getConnected.Open();
            SqlCommand cmd = new SqlCommand("Select GST from Sales_Transaction", conn.getConnected);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                double amount = Convert.ToDouble(dr[0].ToString());
                total += amount;
            }
            conn.getConnected.Close();
            return total.ToString();
        }

        public void checkThreshold()
        {
            conn.getConnected.Open();
            SqlCommand cmd = new SqlCommand("Select Product_Code, Description, Stock, Category from Product Where Stock < 50", conn.getConnected);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Product pr = new Product();
                pr.SetorGetProduct_Code = Convert.ToInt32(dr[0].ToString());
                pr.SetorGetDesc = dr[1].ToString();
                pr.SetorGetStock = Convert.ToInt32(dr[2].ToString());
                pr.SetorGetCategory = dr[3].ToString();

                MessageBox.Show("This product is nearly out of stock !\nProduct Code\t: " + pr.SetorGetProduct_Code.ToString() + "\nDescription\t: " + pr.SetorGetDesc + "\nCurrent Stock\t: " + pr.SetorGetStock.ToString() + "", "out of stock");           
            }
            conn.getConnected.Close();
        }

        public bool checklowstock()
        {
            conn.getConnected.Open();
            bool low = false;
            SqlCommand cmd = new SqlCommand("Select Stock from Product where Stock < 50", conn.getConnected);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr[0].ToString() == null) low = true;
                else { low = false; }
            }
            return low;
        }
    }
}
