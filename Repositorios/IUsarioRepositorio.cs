using TODO.Models;

namespace TODO.Repositorio{
    public interface IUsuarioRepositorio{
        public void CrearUsuario(Usuario nuevoUsuario);
        public void ModificarUsuario(Usuario usuario);
        public List<Usuario> ObtenerTodosUsuarios();
        public Usuario ObtenerUsuarioPorId(int idUsuario);
        public void EliminarUsuarios(int idUsuario);

    }
}