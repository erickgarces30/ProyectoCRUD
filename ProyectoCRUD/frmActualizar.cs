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
    public partial class frmActualizar : Form
    {
        public frmActualizar()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmActualizar_Load(object sender, EventArgs e)
        {
            DataTable dt = Academico.EstudianteDAO.getNombresCompletos();
            this.cmbMatricula.DataSource = dt;
            this.cmbMatricula.DisplayMember = "Estudiantes";
            this.cmbMatricula.ValueMember = "Matricula";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(buscar()==false)
            {
                MessageBox.Show("No existe el registro...");
            }
        }
        //private void bus

        private void cmbMatricula_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.cmbMatricula.SelectedIndex>=0)
            {
                buscar();
            }
        }
        private bool buscar()
        {
            bool encontrado = false;
            DataTable dt = Academico.EstudianteDAO.getDatos(this.cmbMatricula.SelectedValue.ToString());
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow fila in dt.Rows)
                {
                    encontrado = true;
                    this.txtApellido.Text = fila["apellidos"].ToString();
                    this.txtNombres.Text = fila["nombres"].ToString();
                    this.cmbGenero.Text = fila["genero"].ToString();
                    this.txtCorreo.Text = fila["email"].ToString();
                    this.dtFechaNacimiento.Text = fila["fechaNacimiento"].ToString();
                    break;
                }
            }
            return encontrado;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int x = 0;
            Academico.Estudiante estudiante = new Academico.Estudiante();
            estudiante.Matricula = Convert.ToString( this.cmbMatricula.SelectedValue);
            estudiante.Apellidos = this.txtApellido.Text;
            estudiante.Nombres = this.txtNombres.Text;
            estudiante.FechaNacimiento = Convert.ToDateTime(this.dtFechaNacimiento.Value);
            string genero = "F";
            if (Academico.EstudianteDAO.validarEmail(this.txtCorreo.Text) == false)
            {
                MessageBox.Show("Dirección de correo no valida", "Validación de correo electrónico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                estudiante.Correo = this.txtCorreo.Text;
            }
            if (this.cmbGenero.Text.ToString().Equals("Masculino"))
            {
                genero = "M";
            }
            estudiante.Genero = genero;
            try
            {
                x = Academico.EstudianteDAO.actualizar(estudiante);
                MessageBox.Show("Datos actualizados con éxito...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            
        }
    }
}
