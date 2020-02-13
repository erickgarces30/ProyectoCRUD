using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCRUD
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //Application.Run(new frmBorrar());
            //Application.Run(new frmMenu ());
            //Application.Run(new ProyectoAdm.frmUsuarios());
            Application.Run(new frmLogin());
            //Application.Run(new informes.frmInformeEstudiantes());
        }
    }
}
