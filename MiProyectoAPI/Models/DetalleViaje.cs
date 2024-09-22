namespace MiProyectoAPI.Models
{
    public class DetalleViaje
    {
        public int Id { get; set; }
        public string Detalle { get; set; }
        public decimal Costo { get; set; }
        public int ViajeId { get; set; }
        public Viaje Viaje { get; set; }
    }
}

