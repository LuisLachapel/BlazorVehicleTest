using System.Data;
using System.Data.SqlClient;
using BlazorVehicleTest.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorVehicleTest.Metodos
{
    public class MetodoVehiculo
    {

        private readonly ConexionDBContext _context;

        public MetodoVehiculo(ConexionDBContext context)
        {
            _context = context;
        }
        public void Insertar(tb_vehiculo modelo)
        {
            try
            {
                SqlConnection connection = new SqlConnection("Data source = DESKTOP-B63DB53; Initial Catalog = VehicleTest; Integrated Security = True;");
                connection.Open();
                SqlCommand sql = new SqlCommand("Insertar_Vehiculo", connection);
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

        }

        public async Task<List<tb_marca>> ObtenerMarcas()
        {
            return await _context.tb_marca.ToListAsync();
        }

        public async Task<List<tb_vehiculoDto>> ObtenerVehiculos()
        {
            List<tb_vehiculoDto> vehiculos = new List<tb_vehiculoDto>();

            using (SqlConnection connection = new SqlConnection("Data source=DESKTOP-B63DB53;Initial Catalog=VehicleTest;Integrated Security=True;"))
            {
                await connection.OpenAsync();

                using (SqlCommand sql = new SqlCommand("ObtenerVehiculos", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = await sql.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            vehiculos.Add(new tb_vehiculoDto
                            {
                                Vehiculo_id = reader.GetInt32(reader.GetOrdinal("Vehiculo_id")),
                                Chasis_No = reader.GetString(reader.GetOrdinal("Chasis_No")),
                                Marca_descripcion = reader["Marca_descripcion"].ToString(),
                                Modelo_descripcion = reader.GetString(reader.GetOrdinal("Modelo_descripcion")),
                                Ano = reader.GetInt32(reader.GetOrdinal("Ano")),
                                Color = reader.GetString(reader.GetOrdinal("Color")),
                                Placa = reader.GetString(reader.GetOrdinal("Placa")),
                                Fecha_Registro = reader.GetDateTime(reader.GetOrdinal("Fecha_Registro")),
                            });
                        }
                    }
                }
            }

            return vehiculos;
        }



        public async Task<List<tb_modelo>> ObtenerModelos(int marcaId)
        {
            return await _context.tb_modelo
                                 .Where(m => m.Marca_id == marcaId) 
                                 .ToListAsync();  
        }
    }
}
