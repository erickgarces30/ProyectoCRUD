using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCRUD.informes
{
    public partial class frmRecordAcad_Mostrarrecord : Form
    {
        public frmRecordAcad_Mostrarrecord()
        {
            InitializeComponent();
        }

        private void frmRecordAcad_Mostrarrecord_Load(object sender, EventArgs e)
        {
            string smatricula = frmRecordAcad_selEstudiante.Matricula;
            this.dataTable1TableAdapter.FillxMatricula(dsNotas.DataTable1, smatricula);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
