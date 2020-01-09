using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int x = 0;
            Academico.Estudiante estudiante = new Academico.Estudiante();
            estudiante.Matricula = this.txtMatricula.Text;
            estudiante.Apellidos = this.txtApellido.Text;
            estudiante.Nombres = this.txtNombres.Text;
            estudiante.FechaNacimiento = this.dtFechaNacimiento.Value;
            string genero = "F";
            if (Academico.EstudianteDAO.validarEmail(this.txtCorreo.Text) == false)
            {
                MessageBox.Show("Dirección de correo no valida", "Validación de correo electrónico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                estudiante.Correo = this.txtCorreo.Text;
            }
            if(this.cmbGenero.Text.ToString().Equals("Masculino"))
            {
                genero = "M";
            }
            estudiante.Genero = genero;
            try
            {
                x = Academico.EstudianteDAO.guardar(estudiante);
                MessageBox.Show("Filas agregadas: " + x.ToString());
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            cargarGridEstudiantes();

        }
        
        private void txtCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarGridEstudiantes();
        }
        private void cargarGridEstudiantes()
        {
            this.dgEstudiantes.DataSource = Academico.EstudianteDAO.getDatos();
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {

        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
