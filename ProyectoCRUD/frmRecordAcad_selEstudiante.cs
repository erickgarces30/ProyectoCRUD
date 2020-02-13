using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCRUD
{
    public partial class frmRecordAcad_selEstudiante : Form
    {
        public static string Matricula;

        public frmRecordAcad_selEstudiante()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RecordAcad_selEstudiante_Load(object sender, EventArgs e)
        {
            DataTable dt = Academico.EstudianteDAO.getNombresCompletos();
            this.cmbMatricula.DataSource = dt;
            this.cmbMatricula.DisplayMember = "Estudiantes";
            this.cmbMatricula.ValueMember = "Matricula";
        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            if (this.cmbMatricula.SelectedValue.ToString().Length == 0)
            {
                MessageBox.Show("Seleccione un estudiante");
                this.cmbMatricula.Focus(); //ubicar el enfoque en cmbmatricula
                return; //abandonar ejecución
            }
            Matricula = this.cmbMatricula.SelectedValue.ToString();
            informes.frmRecordAcad_Mostrarrecord frm1 = new informes.frmRecordAcad_Mostrarrecord();
            frm1.Show();
        }
    }
}
