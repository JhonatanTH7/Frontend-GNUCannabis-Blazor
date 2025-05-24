namespace GNUCannabis.Models
{
    public class Plant
    {
        public int IdPlanta { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Cultivo { get; set; } = string.Empty;
        public string TipoPlanta { get; set; } = string.Empty;
        public string EstadoPlanta { get; set; } = string.Empty;
    }
}