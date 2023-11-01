using WebAPIFrutaria.Enums;

namespace WebAPIFrutaria.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public int? NivelAcesso { get; set; }
        public StatusUsuario Ativo { get; set; }
    }
}
