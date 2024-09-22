namespace MiProyectoAPI.Models
{
    public class Taxi
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }  // Relación con el conductor
    }
}

