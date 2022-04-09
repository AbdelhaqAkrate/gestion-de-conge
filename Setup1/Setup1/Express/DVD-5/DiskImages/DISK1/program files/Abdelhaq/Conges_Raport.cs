using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Congés
{
    public partial class Conges_Raport : Form
    {
        public Conges_Raport()
        {
            InitializeComponent();
        }

        private void Conges_Raport_Load(object sender, EventArgs e)
        {

            Report_Data rd = new Report_Data();
            Report_DataTableAdapters.CongeTableAdapter daC = new Report_DataTableAdapters.CongeTableAdapter();
            daC.Fill(rd.Conge);
            Report_DataTableAdapters.GesEmployeTableAdapter daGE = new Report_DataTableAdapters.GesEmployeTableAdapter();
            daGE.Fill(rd.GesEmploye);
            CongeReport1 cr = new CongeReport1();
            cr.SetDataSource(rd);
            crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.Refresh();
        }
    }
}
