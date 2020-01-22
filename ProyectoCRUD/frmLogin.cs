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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            bool existe = Academico.UsuariosDAO.validaUsuaruio(this.txtUsuario.Text, this.txtClave.Text);
            if (existe)
            {
                this.Visible = false;
                frmMenu frm1 = new frmMenu();
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Usuarios y/o clave incorrectos");
            }
        }
    }
}
