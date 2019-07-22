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
    public partial class FormGSTReport : Form
    {
        List<SalesTransaction> transList;
        string _date, _supervisor, _totaltrans, _totaltransamo, _totalgst;
        public FormGSTReport(List<SalesTransaction> xlist, string date, string supervisor, string totaltrans, string totaltransamo, string totalgst)
        {
            InitializeComponent();
            transList = xlist;
            _date = date;
            _supervisor = supervisor;
            _totaltrans = totaltrans;
            _totaltransamo = totaltransamo;
            _totalgst = totalgst;
            
        }
       
        private void FormGSTReport_Load(object sender, EventArgs e)
        {
            SalesTransactionBindingSource.DataSource = transList;
            Microsoft.Reporting.WinForms.ReportParameter[] para = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("pDate", _date),
                new Microsoft.Reporting.WinForms.ReportParameter("pSupervisorName", _supervisor),
                new Microsoft.Reporting.WinForms.ReportParameter("pTotalTransaction", _totaltrans),
                new Microsoft.Reporting.WinForms.ReportParameter("pTotalTranscAmo", _totaltransamo),
                new Microsoft.Reporting.WinForms.ReportParameter("pTotalGSt", _totalgst),               
            };
            this.reportViewer1.LocalReport.SetParameters(para);
            this.reportViewer1.RefreshReport();
        }
    }
}
