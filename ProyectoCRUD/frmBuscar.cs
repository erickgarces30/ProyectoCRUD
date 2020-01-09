﻿using System;
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
    public partial class frmBuscar : Form
    {
        public frmBuscar()
        {
            InitializeComponent();
        }

        private void frmBuscar_Load(object sender, EventArgs e)
        {
           DataTable dt= Academico.EstudianteDAO.getNombresCompletos();
            this.cmbMatricula.DataSource = dt;
            this.cmbMatricula.DisplayMember = "Estudiantes";
            this.cmbMatricula.ValueMember = "Matricula";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable dt = Academico.EstudianteDAO.getDatos(this.cmbMatricula.SelectedValue.ToString());
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow fila in dt.Rows)
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
