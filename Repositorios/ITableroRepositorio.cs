using TODO.Models;
public interface ITableroRepositorio{
    public Tablero CrearTablero(Tablero NuevoTablero);
    public void ModificarTablero(int id, Tablero tablero);
    public Tablero ObtenerTablero(int idTablero);
    public List<Tablero> ListarTableros();
    public List<Tablero> ListarTablerosPorUsuario(int idUsuario);
    public void EliminarTablero(int idTablero);
}