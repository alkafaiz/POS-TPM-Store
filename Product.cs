using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_TPM__store
{
    class Product
    {
        int Product_Code;
        string Desc;
        decimal Unit_Price;
        string Tax_Code;
        decimal Tax;
        decimal Discount;
        int Stock;
        string Category;
        string Expiry_Date;
        string Supplier;

        public Product() { }
        public Product(int productCode)
        {
            Product_Code = productCode;
        }

        public Product(int productCode, string Descr, decimal Uprice, string Tcode, decimal discount)
        {
            Product_Code = productCode;
            Desc = Descr;
            Unit_Price = Uprice;
            Tax_Code = Tcode;
            Discount = discount;
        }

        public int SetorGetProduct_Code
        {
            set { Product_Code = value; }
            get { return Product_Code; }
        }
        public string SetorGetDesc
        {
            set { Desc = value; }
            get { return Desc; }
        }
        public decimal SetorGetUnit_Price
        {
            set { Unit_Price = value; }
            get { return Unit_Price; }
        }
        public string SetorGetTax_Code
        {
            set { Tax_Code = value; }
            get { return Tax_Code; }
        }
        public decimal SetorGetTax
        {
            set { Tax = value; }
            get { return Tax; }
        }
        public decimal SetorGetDiscount
        {
            set { Discount = value; }
            get { return Discount; }
        }
        public int SetorGetStock
        {
            set { Stock = value; }
            get { return Stock; }
        }
        public string SetorGetCategory
        {
            set { Category = value; }
            get { return Category; }
        }
        public string SetorGetExpiry_Date
        {
            set { Expiry_Date = value; }
            get { return Expiry_Date; }
        }
        public string SetorGetSupplier
        {
            set { Supplier = value; }
            get { return Supplier; }
        }

        public void AddDetail(int _pCode, string _Desc, decimal _uPrice, string _tCode, decimal _tax, decimal _disc, int _stock, string _category, string _exDate, string _supplier)
        {
            Product_Code = _pCode;
            Desc = _Desc;
            Unit_Price = _uPrice;
            Tax_Code = _tCode;
            Tax = _tax;
            Discount = _disc;
            Stock = _stock;
            Category = _category;
            Expiry_Date = _exDate;
            Supplier = _supplier;
        }
    }
}
