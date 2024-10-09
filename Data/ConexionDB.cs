using System.Data;
using System.Data.SqlClient;

namespace BlazorVehicleTest.Data
{
    public class ConexionDB
    {
        public static string cadena_conexion = "Data source = DESKTOP-B63DB53; Initial Catalog = VehicleTest; Integrated Security = True; ";
        public static SqlConnection conexion = new SqlConnection(cadena_conexion);

        public static void Abrir()
        {
            if(conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
        }

        public static void Cerrar()
        {
            if(conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}
