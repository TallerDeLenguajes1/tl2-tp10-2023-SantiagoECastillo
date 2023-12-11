using TODO.Models;
public interface ITareaRepositorio{
    public Tarea CrearTarea(int idTablero, Tarea tarea);
    public void ModificarTarea(int idTarea, Tarea tarea);
    public Tarea ObtenerTarea(int idTarea);
    public List<Tarea> ListarTareasUsuario(int idUsuario);
    public List<Tarea> ListarTareasTablero(int idTablero);
    public void EliminarTarea(int idTarea);
    public void AsignarUsuarioATarea(int idUsuario, int idTarea);
}