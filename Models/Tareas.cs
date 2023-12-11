namespace TODO.Models{
    public class Tarea{
        private int idTarea;
        private int idTablero;
        private string? nombreTarea;
        private string? descripcionTarea;
        private string? color;
        private EstadoTarea Estado;
        private int? IdUsuarioAsignado;

        public int IdTarea { get => idTarea; set => idTarea = value; }
        public string? NombreTarea { get => nombreTarea; set => nombreTarea = value; }
        public string? DescripcionTarea { get => descripcionTarea; set => descripcionTarea = value; }
        public string? Color { get => color; set => color = value; }
        public EstadoTarea Estado1 { get => Estado; set => Estado = value; }
        public int? IdUsuarioAsignado1 { get => IdUsuarioAsignado; set => IdUsuarioAsignado = value; }
        public int IdTablero { get => idTablero; set => idTablero = value; }
    }

    public enum EstadoTarea{
        Ideas,
        ToDo, 
        Doing, 
        Review, 
        Done

    }
}