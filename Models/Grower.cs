namespace GNUCannabis.Models
{
    public class Grower
    {
        public int IdUsuario { get; set; }
        public string Persona { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public string? Cultivo { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
    
}
