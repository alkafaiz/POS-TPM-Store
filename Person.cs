using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_TPM__store
{
    abstract class Person
    {
        private string Name;
        private string IC;
        private string Address;
        private string City;
        private string State;
        private int PostCode;
        private int Phone;
        private string Email;
        private string Gender;

        public Person()
        {
            Name = "Unknown";
            IC = "XXXXXX";
            Address = "";
            City = "";
            State = "";
            PostCode = 0;
            Phone = 0;
            Email = "";
            Gender = "";                
        }

        public Person(string newName, string newIC, string newAddress, string newCity, string newState, int newPostCode, int newPhone, string newEmail, string newGender)
        {
            Name = newName;
            IC = newIC;
            Address = newAddress;
            City = newCity;
            State = newState;
            PostCode = newPostCode;
            Phone = newPhone;
            Email = newEmail;
            Gender = newGender;
        }

        //set and get properties
        public string SetorGetName
        {
            set { Name = value; }
            get { return Name; }
        }

        public string SetorGetIC
        {
            set { IC = value; }
            get { return IC; }
        }

        public string SetorGetAddress
        {
            set { Address = value; }
            get { return Address; }
        }

        public string SetorGetCity
        {
            set { City = value; }
            get { return City; }
        }

        public string SetorGetState
        {
            set { State = value; }
            get { return State; }
        }

        public int SetorGetPostCode
        {
            set { PostCode = value; }
            get { return PostCode; }
        }

        public int SetorGetPhone
        {
            set { Phone = value; }
            get { return Phone; }
        }

        public string SetorGetEmail
        {
            set { Email = value; }
            get { return Email; }
        }

        public string SetorGetGender
        {
            set { Gender = value; }
            get { return Gender; }
        }
    }
}
