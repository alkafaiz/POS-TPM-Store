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
    public partial class AddNewSupplier : Form
    {
        public string newSupplier
        {
            get
            {
                return txtSupplierName.Text;
            }
        }

        public AddNewSupplier()
        {
            InitializeComponent();
        }
    }
}
