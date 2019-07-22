using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_TPM__store
{
    class Customer : Person
    {
        
        string CustomerID;
        string RegisterationDate;
        int point = 0;


       public Customer()
        {
            CustomerID = "";
            RegisterationDate = "";
            point = 0;
        }

        public Customer(string CID)
        {            
            CustomerID = CID;            
        }

        public Customer(string CID, string name, string IC, string city, string address, string state, int pc, int phone, string email, string gender, string Date, int Point)
        {            
            SetorGetName = name;
            SetorGetIC = IC;
            SetorGetAddress = address;
            SetorGetCity = city;
            SetorGetState = state;
            SetorGetPostCode = pc;
            SetorGetPhone = phone;
            SetorGetEmail = email;
            SetorGetGender = gender;
            CustomerID = CID;
            RegisterationDate = Date;
            point = Point;
        }

        //set and get properties
        public string SetorGetCustomerID
        {
            set { CustomerID = value; }
            get { return CustomerID; }
        }

        public string SetorGetRegistrationDate
        {
            set { RegisterationDate = value; }
            get { return RegisterationDate; }
        }

        public int SetorGetPoint
        {
            set { point = value; }
            get { return point; }
        }

        //behaviour
        public void gainPoint(int newPoint)
        {
            point += newPoint;
        }

        public void updateDetail(string name, string IC, string address, string city, string state, int pc, int phone, string email, string gender, string ID)
        {
            SetorGetName = name;
            SetorGetIC = IC;
            SetorGetAddress = address;
            SetorGetCity = city;
            SetorGetState = state;
            SetorGetPostCode = pc;
            SetorGetPhone = phone;
            SetorGetEmail = email;
            SetorGetGender = gender;
            CustomerID = ID;
            //RegisterationDate = Date;
            //point = Point;
        }

        
    }
}
