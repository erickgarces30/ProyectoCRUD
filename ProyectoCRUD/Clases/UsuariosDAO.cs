using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico
{
    public static class UsuariosDAO
    {
        private static string cadenaConexion = @"server=ERICK\SQLEXPRESS2016; database=TI2019; user id=sa; password=Lab123456;";

        public static bool validaUsuaruio(string usuario, string clave)
        {
            SqlConnection conn = new SqlConnection(cadenaConexion);
            string sql = "select idLogin,nombreCompleto from usuarios where login=@login and clave=@clave";


            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            ad.SelectCommand.Parameters.AddWithValue("@login", usuario);
            ad.SelectCommand.Parameters.AddWithValue("@clave", clave);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public static int guardar(Usuarios usuarios)
        {

            SqlConnection conn = new SqlConnection(cadenaConexion);
            string sql = "insert into Usuarios(nombreCompleto, login, clave, tipoUsuario)" +
                " values(@nombreCompleto,@login,@clave,@tipoUsuario)";

            //Definimos un comando
            SqlCommand comando = new SqlCommand(sql, conn);
            //configuramos los parámetros
            comando.CommandType = System.Data.CommandType.Text;
            comando.Parameters.AddWithValue("@nombreCompleto", usuarios.nombreCompleto);
            comando.Parameters.AddWithValue("@login", usuarios.login);
            comando.Parameters.AddWithValue("@clave", usuarios.clave);
            comando.Parameters.AddWithValue("@tipoUsuario", usuarios.tipoUsuario);
            conn.Open();
            int x = comando.ExecuteNonQuery(); //Ejeutamos el comando
            conn.Close();

            return x;
        }
        public static DataTable getDatos()
        {
            SqlConnection conn = new SqlConnection(cadenaConexion);
            string sql = "select idLogin, nombreCompleto, login, clave, tipoUsuario " +
                "from Usuarios order by nombreCompleto";
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            ad.Fill(dt); //llena el dataTable dt

            return dt;
        }

        public static int borrar(String id)
        {
            //definimos una objeto conexión
            SqlConnection conn = new SqlConnection(cadenaConexion);

            string sql = "delete from usuarios " +
                "where idLogin=@idLogin";

            //definimos un comando
            SqlCommand comando = new SqlCommand(sql, conn);
            //configuramos los parametros
            comando.CommandType = System.Data.CommandType.Text;
            comando.Parameters.AddWithValue("@idLogin", id);
            conn.Open();
            int x = comando.ExecuteNonQuery();//ejecutamos el comando
            conn.Close();
            return x;

        }

        public static int actualizar(Usuarios usuarios)
        {

            SqlConnection conn = new SqlConnection(cadenaConexion);
            string sql = "UPDATE usuarios SET nombreCompleto=@nombreCompleto, login=@login," +
                " clave=@clave,tipoUsuario=@tipoUsuario" +
                " WHERE idLogin=@idLogin";

            //Definimos un comando
            SqlCommand comando = new SqlCommand(sql, conn);
            //configuramos los parámetros
            comando.CommandType = System.Data.CommandType.Text;
            comando.Parameters.AddWithValue("@idLogin", usuarios.idLogin);
            comando.Parameters.AddWithValue("@nombreCompleto", usuarios.nombreCompleto);
            comando.Parameters.AddWithValue("@login", usuarios.login);
            comando.Parameters.AddWithValue("@clave", usuarios.clave);
            comando.Parameters.AddWithValue("@tipoUsuario", usuarios.tipoUsuario);
            conn.Open();
            int x = comando.ExecuteNonQuery(); //Ejeutamos el comando
            conn.Close();

            return x;
        }
    }
}
