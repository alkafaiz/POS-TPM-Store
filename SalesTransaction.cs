using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_TPM__store
{
    public class SalesTransaction
    {
        string Invoice_Code;
        string Cashier;
        string Customer;
        string Date;
        string Time;
        decimal TotalAmount;
        int TotalQty;
        decimal GST;
        string Payment;

        public SalesTransaction(string invcd, string cs, string cus, string dte, string tme, decimal tamount, int tqty, decimal gst, string paymentmtds)
        {
            Invoice_Code = invcd;
            Cashier = cs;
            Customer = cus;
            Date = dte;
            Time = tme;
            TotalAmount = tamount;
            TotalQty = tqty;
            GST = gst;
            Payment = paymentmtds;
        }

        public string SetorGetInvoice_Code
        {
            set { Invoice_Code = value; }
            get { return Invoice_Code; }
        }
        public string SetorGetCashier
        {
            set { Cashier = value; }
            get { return Cashier; }
        }
        public string SetorGetCustomer
        {
            set { Customer = value; }
            get { return Customer; }
        }
        public string SetorGetDate
        {
            set { Date = value; }
            get { return Date; }
        }
        public string SetorGetTime
        {
            set { Time = value; }
            get { return Time; }
        }
        public decimal SetorGetTotalAmount
        {
            set { TotalAmount = value; }
            get { return TotalAmount; }
        }
        public int SetorGetTotalQty
        {
            set { TotalQty = value; }
            get { return TotalQty; }
        }
        public decimal SetorGetGST
        {
            set { GST = value; }
            get { return GST; }
        }
        public string  SetorGetPayment
        {
            set { Payment = value; }
            get { return Payment; }
        }


    }
}
