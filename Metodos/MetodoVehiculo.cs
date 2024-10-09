using System.Data;
using System.Data.SqlClient;
using BlazorVehicleTest.Data;

namespace BlazorVehicleTest.Metodos
{
    public class MetodoVehiculo
    {
        public void Insertar(tb_vehiculo modelo)
        {
            try
            {
                ConexionDB.Abrir();
                SqlCommand sql = new SqlCommand("Insertar_Vehiculo", ConexionDB.conexion);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@Chasis_No", modelo.Chasis_No);
                sql.Parameters.AddWithValue("@Ano", modelo.Ano);
                sql.Parameters.AddWithValue("@Color", modelo.Color);
                sql.Parameters.AddWithValue("@Marca_id", modelo.Marca_id);
                sql.Parameters.AddWithValue("@Modelo_id", modelo.Modelo_id);
                sql.Parameters.AddWithValue("@Placa", modelo.Placa);
                sql.Parameters.AddWithValue("@Fecha_Registro", modelo.Fecha_Registro);
                sql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConexionDB.Cerrar();
            }
        }

        public List<tb_modelo> ObtenerModelo(int marcaId)
        {
            List<tb_modelo> modelos = new List<tb_modelo>();
            try
            {
                ConexionDB.Abrir();
                SqlCommand sql = new SqlCommand("Mostrar_Modelo", ConexionDB.conexion);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@Marca_id", marcaId);
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    modelos.Add(new tb_modelo
                    {
                        Modelo_id = (int)reader["Modelo_id"],
                        Marca_id = (int)reader["Marca_id"], 
                        Modelo_descripcion = reader["Modelo_descripcion"].ToString()

                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConexionDB.Cerrar();
            }
            return modelos;
        }

        public List<tb_marca> ObtenerMarcas()
        {
            List<tb_marca> marcas = new List<tb_marca>();
            try
            {
                ConexionDB.Abrir();
                SqlCommand sql = new SqlCommand("Mostrar_Marca", ConexionDB.conexion);
                sql.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    marcas.Add(new tb_marca
                    {
                        Marca_id = (int)reader["Marca_id"],
                        Marca_descripcion = reader["Marca_descripcion"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConexionDB.Cerrar();
            }
            return marcas;
        }
    }
}
