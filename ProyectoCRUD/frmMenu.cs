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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            //llamada al form para agregar nuevos registros
            frmGuardar frm1 = new frmGuardar();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            //abre el formulario de búsqueda
            frmBuscar frm1 = new frmBuscar();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //abre el formulario de actualizacion de datos
            frmActualizar frm1 = new frmActualizar();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBorrar frm1 = new frmBorrar();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void printPreviewToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void editMenu_Click(object sender, EventArgs e)
        {

        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProyectoAdm.frmUsuarios frm1 = new ProyectoAdm.frmUsuarios();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProyectoCRUD.informes.frmInformeEstudiantes frm1 = new ProyectoCRUD.informes.frmInformeEstudiantes();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void informeDeRecordAcademicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void informesXdToolStripMenuItem_Click(object sender, EventArgs e)
        {
               frmRecordAcad_selEstudiante frm1 = new frmRecordAcad_selEstudiante();
            frm1.MdiParent = this;
            frm1.Show();
        }
    }
}
