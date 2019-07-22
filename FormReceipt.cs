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
    public partial class FormReceipt : Form
    {
        List<Receipt> items;
        int _totalitem;
        string _date, _total, _cash, _change, _cashier, _invoice, _onlyGST, _GST, _NonGST;
        public FormReceipt(List<Receipt> Itempurc, string invoice, int totalitem, string date, string total, string cash, string change, string cashier, string onlyGST, string nonGST, string GST)
        {
            InitializeComponent();
            items = Itempurc;
            _invoice = invoice;
            _totalitem = totalitem;
            _date = date;
            _total = total;
            _cash = cash;
            _change = change;
            _cashier = cashier;
            _onlyGST = onlyGST;
            _GST = GST;
            _NonGST = nonGST;
        }

        private void FormReceipt_Load(object sender, EventArgs e)
        {
            ReceiptBindingSource.DataSource = items;
            Microsoft.Reporting.WinForms.ReportParameter[] para = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("pInvoice_Code", _invoice.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("pDateTime", _date),
                new Microsoft.Reporting.WinForms.ReportParameter("pTotal", _total),
                new Microsoft.Reporting.WinForms.ReportParameter("pCash", _cash),
                new Microsoft.Reporting.WinForms.ReportParameter("pChange", _change),
                new Microsoft.Reporting.WinForms.ReportParameter("pCashier", _cashier),
                new Microsoft.Reporting.WinForms.ReportParameter("pTotalItem", _totalitem.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("pGSTamount", _GST),
                new Microsoft.Reporting.WinForms.ReportParameter("pNonGSTAmount", _NonGST),
                new Microsoft.Reporting.WinForms.ReportParameter("pOnlyGST", _onlyGST)
            };
            this.reportViewer1.LocalReport.SetParameters(para);
            this.reportViewer1.RefreshReport();
        }
    }
}
