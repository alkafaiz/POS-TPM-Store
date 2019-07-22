using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_TPM__store
{
    public class Receipt
    {
        public string ID { get; set; }

        public string Desc { get; set; }

        public decimal uPrice { get; set; }

        public decimal disc { get; set; }

        public int qty { get; set; }

        public string taxcd { get; set; }

        public decimal subtotal { get; set; }
    }
}
