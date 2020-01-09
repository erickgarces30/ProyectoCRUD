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
    public partial class frmBorrar : Form
    {
        public frmBorrar()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable dt = Academico.EstudianteDAO.getDatos(this.cmbMatricula.SelectedValue.ToString());
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow fila in dt.Rows)
                {
                    this.txtApellido.Text = fila["apellidos"].ToString();
                    this.txtNombres.Text = fila["nombres"].ToString();
                    this.cmbGenero.Text = fila["genero"].ToString();
                    this.txtCorreo.Text = fila["email"].ToString();
                    this.txtFechaNacimiento.Text = fila["fechaNacimiento"].ToString();
                    break;
                }
            }
            else
            {
                MessageBox.Show("No existe el estudiante...");
            }
        }

        private void frmBorrar_Load(object sender, EventArgs e)
        {
            DataTable dt = Academico.EstudianteDAO.getNombresCompletos();
            this.cmbMatricula.DataSource = dt;
            this.cmbMatricula.DisplayMember = "Estudiantes";
            this.cmbMatricula.ValueMember = "Matricula";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult eleccion=MessageBox.Show("¿Estas seguro de eliminar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if ( eleccion == DialogResult.Yes)
            {
                int x = Academico.EstudianteDAO.eliminar(this.cmbMatricula.SelectedValue.ToString());
                this.txtApellido.Clear();
                this.txtNombres.Clear();
                this.cmbGenero.Text.Length.ToString("");
                this.txtCorreo.Clear();
                DataTable dt = Academico.EstudianteDAO.getNombresCompletos();
                this.cmbMatricula.DataSource = dt;
            }
        }
    }
}
