namespace MiProyectoAPI.Models
{
    public class Viaje
    {
        public int Id { get; set; }
        public string Destino { get; set; }
        public DateTime Fecha { get; set; }
        public int TaxiId { get; set; }
        public Taxi Taxi { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }  // Usuario que realiza el viaje
    }
}
