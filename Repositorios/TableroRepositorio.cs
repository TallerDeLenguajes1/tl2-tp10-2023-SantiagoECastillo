using System.Data.SqlClient;
using System.Data.SQLite;

using TODO.Models;

namespace TODO.Repositorio{
    public class TableroRepositorio : ITableroRepositorio{
        private string cadenaConexion = "Data Source=DB/kanban.db;Cache=Shared";
 
        public Tablero CrearTablero(Tablero NuevoTablero){
            var query = $"INSERT INTO Tablero (id_usuario_propietario, nombre, descripcion) VALUES (@id_usuario_propietario, @nombre, @descripcion)";
            using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
                
                connection.Open();
                var comando = new SQLiteCommand(query, connection);

                comando.Parameters.Add(new SQLiteParameter("@id_usuario_propietario", NuevoTablero.IdUsuarioPropietario));
                comando.Parameters.Add(new SQLiteParameter("@nombre", NuevoTablero.Nombre));
                comando.Parameters.Add(new SQLiteParameter("@descripcion", NuevoTablero.Descripcion));

                comando.ExecuteNonQuery();
                connection.Close();
            }
            return NuevoTablero;
        }

        public void ModificarTablero(int id, Tablero tablero){
            SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
            SQLiteCommand command = connection.CreateCommand();
            
            command.CommandText = $"UPDATE Tablero SET nombre = '{tablero.Nombre}', descripcion = '{tablero.Descripcion}'  WHERE id = '{tablero.IdTablero}' AND id_usuario_propietario ='{id}';";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Tablero ObtenerTablero(int idTablero){
            SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
            var tablero = new Tablero();
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Tablero WHERE id = @idTablero";
            command.Parameters.Add(new SQLiteParameter("@idTablero", idTablero));
            connection.Open();
            using(SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    tablero.IdTablero = Convert.ToInt32(reader["id"]);
                    tablero.IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                    tablero.Nombre = reader["nombre"].ToString();
                    tablero.Descripcion = reader["descripcion"].ToString();
                }
            }
            connection.Close();
            return (tablero);
        }

        public List<Tablero> ListarTableros(){
            var query = @"SELECT * FROM Tablero";
            List<Tablero> tableros = new List<Tablero>();
            using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
                
                SQLiteCommand command = new SQLiteCommand(query, connection);
                connection.Open();
            
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tablero = new Tablero();
                        tablero.IdTablero = Convert.ToInt32(reader["id"]);
                        tablero.IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                        tablero.Nombre = reader["nombre"].ToString();
                        tablero.Descripcion = reader["descripcion"].ToString();

                        tableros.Add(tablero);
                    }
                }
                connection.Close();
                return tableros;
            }
        }
        public List<Tablero> ListarTablerosPorUsuario(int idUsuario){
            var query = @"SELECT * FROM Tablero where id_usuario_propietario = '{@idUsuario}'";
            List<Tablero> tableros = new List<Tablero>();
            using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
                
                SQLiteCommand command = new SQLiteCommand(query, connection);
                connection.Open();
            
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tablero = new Tablero();
                        tablero.IdTablero = Convert.ToInt32(reader["id"]);
                        tablero.IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                        tablero.Nombre = reader["nombre"].ToString();
                        tablero.Descripcion = reader["descripcion"].ToString();

                        tableros.Add(tablero);
                    }
                }
                connection.Close();
                return tableros;
            }
        }
        public void EliminarTablero(int idTablero){
            SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
            SQLiteCommand command = connection.CreateCommand();
            
            command.CommandText = $"DELETE FROM Tablero WHERE id = '{idTablero}';";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }       
    }
}