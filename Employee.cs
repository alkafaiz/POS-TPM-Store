using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace POS_TPM__store
{
    class Employee : Person
    {
        string EmployeeID;
        string Position;        
        string Permissions;
        string Username;
        string Password;
        string DateCreation;

        Connection conn = new Connection();

        public Employee()
        {
            EmployeeID = "";
            Position = "";            
            Permissions = "";
       
        }
        public Employee(string ID, string name, string IC, string Gender, string Address, string City, string State, int pscd, int phone, string email, string datecreated, string Permission, string _Position, string username)
        {
            EmployeeID = ID;
            SetorGetName = name;
            SetorGetIC = IC;
            SetorGetGender = Gender;
            SetorGetAddress = Address;
            SetorGetCity = City;
            SetorGetState = State;
            SetorGetPostCode = pscd;
            SetorGetPhone = phone;
            SetorGetEmail = email;
            SetorGetDateCreation = datecreated;
            Permissions = Permission;
            Position = _Position;
            Username = username;

        }

        public string SetorGetEmployeeID
        {
            set { EmployeeID = value; }
            get { return EmployeeID; }
        }

        public string SetorGetPosition
        {
            set { Position = value; }
            get { return Position; }
        }
        public string SetorGetPermission
        {
            set { Permissions = value; }
            get { return Permissions; }
        }
        public string SetorGetUsername
        {
            set { Username = value; }
            get { return Username; }
        }
        public string SetorGetPassword
        {
            set { Password = value; }
            get { return Password; }
        }
        public string SetorGetDateCreation
        {
            set { DateCreation = value; }
            get { return DateCreation; }
        }

        public void RetrieveName(string username, TextBox textboxname )
        {
            conn.getConnected.Open();
            SqlCommand cmd = new SqlCommand("SELECT Employee_ID, Name from Employee Where (Username='" + username + "')", conn.getConnected);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textboxname.Text = dr[1].ToString();
            }
            conn.getConnected.Close();
        }

        public string RetrievePermission(string username)
        {
            conn.getConnected.Open();
            SqlCommand cmd = new SqlCommand("SELECT Permission from Employee Where (Username='" + username + "')", conn.getConnected);
            SqlDataReader dr = cmd.ExecuteReader();
            string currentPermission = "";
            while (dr.Read())
            {
                currentPermission =  dr[0].ToString();
            }
            return currentPermission;
            conn.getConnected.Close();
        }

    }

    
}
