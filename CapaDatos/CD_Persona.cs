using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace CapaDatos
{
    public class CD_Persona
    {
        private CD_Conexion Conexion = new CD_Conexion();

        SqlDataReader Leer;
        DataTable Tabla = new DataTable();
        SqlCommand Comando = new SqlCommand();


        //Cargar todos los datos de la tabla
        public DataTable Mostrar()
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "MostrarPersonas";
            Comando.CommandType = CommandType.StoredProcedure;
            Leer = Comando.ExecuteReader();
            Tabla.Load(Leer);
            Conexion.CerrarConexion();
            return Tabla;
        }

        //insertar los datos 
        public void Insertar(string Nombres, string Apellidos, string Fecha_Nacimiento, string Sexo)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "InsertarPersonas";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Nombres", Nombres);
            Comando.Parameters.AddWithValue("@Apellidos", Apellidos);
            Comando.Parameters.AddWithValue("@Fecha_Nacimiento", Fecha_Nacimiento);
            Comando.Parameters.AddWithValue("@Sexo", Sexo);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();
        }

        //Editar los datos
        public void Editar(string Id_Persona,string Nombres,string Apellidos, string Fecha_Nacimiento,string Sexo)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "EditarRegistros";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Id_Persona", Id_Persona);
            Comando.Parameters.AddWithValue("@Nombres", Nombres);
            Comando.Parameters.AddWithValue("@Apellidos", Apellidos);
            Comando.Parameters.AddWithValue("@Fecha_Nacimiento", Fecha_Nacimiento);
            Comando.Parameters.AddWithValue("@Sexo", Sexo);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();
        }

        //Eliminar los datos
        public void Eliminar(int id)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "EliminarPersonas";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Id_Personas", id);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();
        }
    }
}
