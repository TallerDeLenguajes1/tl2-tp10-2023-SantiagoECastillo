using System.Data.SqlClient;
using System.Data.SQLite;

using tl2_tp10_2023_SantiagoECastillo.Models;

namespace tl2_tp10_2023_SantiagoECastillo.Repositorio{
    public class UsuarioRepositorio : IUsuarioRepositorio{
        private string cadenaConexion = "Data Source=DB/kanban.db;Cache=Shared";
        
        public void CrearUsuario(Usuario nuevoUsuario){

            var query = $"INSERT INTO Usuario (nombre_de_usuario) VALUES (@nombre_de_usuario)";
            using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
                
                connection.Open();
                var comando = new SQLiteCommand(query, connection);

                comando.Parameters.Add(new SQLiteParameter("@nombre_de_usuario", nuevoUsuario.NombreUsuario));

                comando.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void ModificarUsuario(Usuario usuario){
            SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
            SQLiteCommand command = connection.CreateCommand();
            
            command.CommandText = $"UPDATE Usuario SET nombre_de_usuario = '{usuario.NombreUsuario}' WHERE id = '{usuario.IdUsuario}';";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        
        public List<Usuario> ObtenerTodosUsuarios(){
            var query = @"SELECT * FROM Usuario";
            List<Usuario> usuarios = new List<Usuario>();
            using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
                
                SQLiteCommand command = new SQLiteCommand(query, connection);
                connection.Open();
            
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var usuario = new Usuario();
                        usuario.IdUsuario = Convert.ToInt32(reader["id"]);
                        usuario.NombreUsuario = reader["nombre_de_usuario"].ToString();
                        usuarios.Add(usuario);
                    }
                }
                connection.Close();
                return usuarios;
            }
        }

        public Usuario ObtenerUsuarioPorId(int idUsuario){
            
            SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
            var usuario = new Usuario();
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Usuario WHERE id = @idUsuario";
            command.Parameters.Add(new SQLiteParameter("@idUsuario", idUsuario));
            connection.Open();
            using(SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    usuario.IdUsuario = Convert.ToInt32(reader["id"]);
                    usuario.NombreUsuario = reader["nombre_de_usuario"].ToString();
                }
            }
            connection.Close();
            return (usuario);
        }

        public void EliminarUsuarios(int idUsuario){
            SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
            SQLiteCommand command = connection.CreateCommand();
            
            command.CommandText = $"DELETE FROM Usuario WHERE id = '{idUsuario}';";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

    }
}