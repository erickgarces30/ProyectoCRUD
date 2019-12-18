using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico
{
    public static class EstudianteDAO
    {
        public static int guardar(Estudiante estudiante)
        {
            string cadenaConexion = @"server=ERICK\SQLEXPRESS2016; database=TI2019; user id=sa; password=Lab123456;";
            SqlConnection conn = new SqlConnection(cadenaConexion);
            string sql = "insert into estudiantes(matricula, apellidos, nombres, genero, fechaNacimiento,email) values(@matricula,@apellidos,@nombres,@genero,@fechaNacimiento,@email)";

            //Definimos un comando
            SqlCommand comando = new SqlCommand(sql, conn);
            //configuramos los parámetros
            comando.CommandType = System.Data.CommandType.Text;
            comando.Parameters.AddWithValue("@matricula", estudiante.Matricula);
            comando.Parameters.AddWithValue("@apellidos", estudiante.Apellidos);
            comando.Parameters.AddWithValue("@nombres", estudiante.Nombres);
            comando.Parameters.AddWithValue("@genero", estudiante.Genero);
            comando.Parameters.AddWithValue("@fechaNacimiento", estudiante.FechaNacimiento.Date);
            comando.Parameters.AddWithValue("@email", estudiante.Correo);
            conn.Open();
            int x = comando.ExecuteNonQuery(); //Ejeutamos el comando
            conn.Close();

            return x;
        }
    }
}
