

namespace BlazorVehicleTest.Data
{
    public class tb_vehiculo
    {
        public int Vehiculo_id { get; set; }
        public string Chasis_No { get; set; }
        public int Ano { get; set; }
        public string Color { get; set; }
        public int Marca_id { get; set; }
        public int Modelo_id { get; set; }
        public string Placa { get; set; }
        public DateTime Fecha_Registro { get; set; }


    }

    public class tb_vehiculoDto
    {
        public int Vehiculo_id { get; set; }
        public string Chasis_No { get; set; }
        public string Marca_descripcion { get; set; }
        public string Modelo_descripcion { get; set; }
        public int Ano { get; set; }
        public string Color { get; set; }
        public string Placa { get; set; }
        public DateTime Fecha_Registro { get; set; }
    }
}
