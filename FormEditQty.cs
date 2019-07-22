using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_TPM__store
{
    public partial class FormEditQty : Form
    {
        public FormEditQty()
        {
            InitializeComponent();
        }

        public FormEditQty(string DescItem, decimal Qty)
        {
            InitializeComponent();
            txtDescItem.Text = DescItem;
            
            numericUpDownnQty.Value = Qty;
        }

        

        public decimal newQty()
        {
            return Convert.ToDecimal((numericUpDownnQty.Value.ToString()));
        }

        public decimal newSubtotal( decimal uprice, decimal disc)
        {
            Cashier cs = new Cashier();
            return cs.SubTotal(Convert.ToDecimal(numericUpDownnQty.Value), uprice, disc);

        }
       

    }
}
