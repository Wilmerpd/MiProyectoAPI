namespace MiProyectoAPI.Models
{
    public class GrupoUsuarios
    {
        public int Id { get; set; }
        public string NombreGrupo { get; set; }
        public List<Usuario> Usuarios { get; set; }
    }
}

