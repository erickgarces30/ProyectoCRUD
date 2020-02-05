using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoAdm
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.txtNombreCompleto.Text.Length == 0)
            {
                MessageBox.Show("Por favor ingresar el nombre Completo");
                this.txtNombreCompleto.Focus();
                return;
            }
            if (this.txtLogin.Text.Length == 0)
            {
                MessageBox.Show("Por favor ingresar el login");
                this.txtLogin.Focus();
                return;
            }
            if (this.txtClave.Text.Length == 0)
            {
                MessageBox.Show("Por favor ingresar la clave");
                this.txtClave.Focus();
                return;
            }
            Academico.Usuarios usuario = new Academico.Usuarios(); //Creando instancia
            int a = int.Parse(this.txtID.Text);
            if (a > 0)
            {
                usuario.idLogin = a;
                usuario.nombreCompleto = this.txtNombreCompleto.Text;
                usuario.login = this.txtLogin.Text;
                usuario.clave = this.txtClave.Text;
                usuario.tipoUsuario = this.cmbTipoUsuario.Text;
                int x = Academico.UsuariosDAO.actualizar(usuario);
                if (x > 0)
                {
                    MessageBox.Show("Usuario actualizado con éxito...");
                    cargarDatosUsuario();
                    encerar();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar al usuario...");
                }
            }
            else
            {
                usuario.nombreCompleto = this.txtNombreCompleto.Text;
                usuario.login = this.txtLogin.Text;
                usuario.clave = this.txtClave.Text;
                usuario.tipoUsuario = this.cmbTipoUsuario.Text;
                int x = Academico.UsuariosDAO.guardar(usuario);
                cargarDatosUsuario();
                if (x > 0)
                {
                    MessageBox.Show("Usuario guardado con éxito...");
                    cargarDatosUsuario();
                    encerar();
                }
                else
                {
                    MessageBox.Show("No se pudo agregar al usuario...");
                }

            }




        }

        // para crear el botón dentro del Datagridview//
        void origendatos()
        {
            dgUsuarios.DataSource = Academico.UsuariosDAO.getDatos();
            dgUsuarios.Columns["imagen"].Visible = false;
        }
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            btnseleccionar();
            btnborrar();
            cargarDatosUsuario();
            encerar();
            //dgUsuarios.Columns["imagen"].Visible = false;


        }
        private void btnseleccionar()
        {
            DataGridViewButtonColumn btnseleccionar = new DataGridViewButtonColumn();
            btnseleccionar.Name = "Seleccionar";
            dgUsuarios.Columns.Add(btnseleccionar);
        }
        private void btnborrar()
        {
            DataGridViewButtonColumn btnseleccionar = new DataGridViewButtonColumn();
            btnseleccionar.Name = "Eliminar";
            dgUsuarios.Columns.Add(btnseleccionar);
        }
        private void encerar()
        {
            this.txtID.Text = "0";
            this.txtNombreCompleto.Text = String.Empty;
            this.txtLogin.Text = String.Empty;
            this.txtClave.Text = String.Empty;
            this.cmbTipoUsuario.Text = "Secretaria";
        }
        private void cargarDatosUsuario()
        {
            this.dgUsuarios.DataSource = Academico.UsuariosDAO.getDatos();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dgUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgUsuarios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.ColumnIndex >=0 && this.dgUsuarios.Columns[e.ColumnIndex].Name=="Seleccionar" && e.RowIndex >=0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell celboton = this.dgUsuarios.Rows[e.RowIndex].Cells["Seleccionar"] as DataGridViewButtonCell;
                Icon icoSeleccionar = new Icon(Environment.CurrentDirectory + @"\\flecha.ico");
                e.Graphics.DrawIcon(icoSeleccionar, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dgUsuarios.Rows[e.RowIndex].Height = icoSeleccionar.Height + 5;
                this.dgUsuarios.Columns[e.ColumnIndex].Width = icoSeleccionar.Width + 8;

                e.Handled = true;
            }
            if (e.ColumnIndex >= 0 && this.dgUsuarios.Columns[e.ColumnIndex].Name == "Eliminar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell celboton = this.dgUsuarios.Rows[e.RowIndex].Cells["Eliminar"] as DataGridViewButtonCell;
                Icon icoSeleccionar = new Icon(Environment.CurrentDirectory + @"\\elim.ico");
                e.Graphics.DrawIcon(icoSeleccionar, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dgUsuarios.Rows[e.RowIndex].Height = icoSeleccionar.Height + 5;
                this.dgUsuarios.Columns[e.ColumnIndex].Width = icoSeleccionar.Width + 8;

                e.Handled = true;
            }
        }

        private void dgUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(this.dgUsuarios.Columns[e.ColumnIndex].Name=="Seleccionar")
            {

                txtID.Text = dgUsuarios.CurrentRow.Cells[2].Value.ToString();
                txtNombreCompleto.Text = dgUsuarios.CurrentRow.Cells[3].Value.ToString();
                txtLogin.Text = dgUsuarios.CurrentRow.Cells[4].Value.ToString();
                txtClave.Text = dgUsuarios.CurrentRow.Cells[5].Value.ToString();
                cmbTipoUsuario.Text = dgUsuarios.CurrentRow.Cells[6].Value.ToString();
            }
            if (this.dgUsuarios.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                DialogResult eleccion = MessageBox.Show("¿Estas seguro de eliminar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (eleccion == DialogResult.Yes)
                {
                    int x = Academico.UsuariosDAO.borrar(dgUsuarios.CurrentRow.Cells[2].Value.ToString());
                    cargarDatosUsuario();
                    encerar();
                }
            }
        }
    }
}
