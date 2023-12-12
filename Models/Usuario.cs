namespace tl2_tp10_2023_SantiagoECastillo.Models{
    public class Usuario {
        private int idUsuario;
        private string? nombreUsuario;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string? NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
    }
}