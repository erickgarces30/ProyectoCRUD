using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Academico
{
    public static class EstudianteDAO
    {
        public static SqlConnection conn = new SqlConnection(cadenaConexion);
        private static string cadenaConexion = @"server=ERICK\SQLEXPRESS2016; database=TI2019; user id=sa; password=Lab123456;";
      
       /// <summary>
       /// metodo gaurdar
       /// </summary>
       /// <param name="estudiante"></param>
       /// <returns></returns>
        public static int guardar(Estudiante estudiante)
        {
            
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
        /// <summary>
        /// Función de borrado
        /// </summary>
        /// <param name="estudiante"></param>
        /// <returns></returns>

        public static int eliminar(string matricula)
        {

            SqlConnection conn = new SqlConnection(cadenaConexion);
            string sql = "delete from estudiantes where matricula=@matricula";

            //Definimos un comando
            SqlCommand comando = new SqlCommand(sql, conn);
            //configuramos los parámetros
            comando.CommandType = System.Data.CommandType.Text;
            comando.Parameters.AddWithValue("@matricula", matricula);
            conn.Open();
            int x = comando.ExecuteNonQuery(); //Ejeutamos el comando
            conn.Close();

            return x;
        }

        /// <summary>
        /// Devuelve todas las filas de la tabla estudiante
        /// </summary>
        /// <returns></returns>
        public static DataTable getDatos()
        {
            SqlConnection conn = new SqlConnection(cadenaConexion);
            string sql = "select matricula, apellidos, nombres, genero, fechaNacimiento,email from estudiantes order by apellidos";
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            ad.Fill(dt); //llena el dataTable dt

            return dt;
        }
        public static DataTable getNombresCompletos()
        {
            SqlConnection conn = new SqlConnection(cadenaConexion);
            string sql = "select matricula, upper(apellidos + ' '+ nombres) as Estudiantes from estudiantes order by apellidos,nombres";
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            return dt;
        }
        /// <summary>
        /// Obtiene un estudiante por su número de matrícula
        /// </summary>
        /// <param name="matricula"></param>
        /// <returns></returns>
        public static DataTable getDatos(String matricula)
        {
            SqlConnection conn = new SqlConnection(cadenaConexion);
            string sql = "select matricula, apellidos, nombres, genero, fechaNacimiento,email from estudiantes where matricula=@matricula order by apellidos,nombres";
            
            
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            ad.SelectCommand.Parameters.AddWithValue("@matricula", matricula);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            return dt;
        }
        /// <summary>
        /// validar email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool validarEmail(string email)
        {
            String expresion;
            expresion = @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9 -]+)*(\.[a-z]{2,4})$";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return true;
            }
        }
    }   
}
