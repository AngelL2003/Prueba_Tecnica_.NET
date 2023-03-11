using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;
using System.Reflection;
using Microsoft.VisualBasic;

namespace CapaNegocio
{
     public class CN_Persona
    
    {
        private CD_Persona ObjetoCD = new CD_Persona();

        public DataTable MostrarPersona()
        {
            DataTable Tabla= new DataTable();
            Tabla = ObjetoCD.Mostrar();
            return Tabla;
        }
        public void InsertarPersona(string Nombres, string Apellidos, string Fecha_Nacimiento, string Sexo)
        {
            ObjetoCD.Insertar(Nombres,Apellidos, Fecha_Nacimiento,Sexo);
        }
        public void EditarRegistro(string Id_Persona, string Nombres, string Apellidos, string Fecha_Nacimiento, string Sexo)
        {
            ObjetoCD.Editar(Id_Persona,Nombres, Apellidos, Fecha_Nacimiento, Sexo);
        }
        public void EliminarPersonas(string id)
        {
            ObjetoCD.Eliminar(Convert.ToInt32(id));
        }

    }
}
