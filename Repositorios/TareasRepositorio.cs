using System.Data.SqlClient;
using System.Data.SQLite;

using tl2_tp10_2023_SantiagoECastillo.Models;

namespace tl2_tp10_2023_SantiagoECastillo.Repositorio{
    public class TareasRepositorio : ITareaRepositorio{
        
        private string cadenaConexion = "Data Source=DB/kanban.db;Cache=Shared";
        
        public Tarea CrearTarea(int idTablero, Tarea tarea){
            var query = $"INSERT INTO Tarea (id_tablero, nombre, estado, descripcion, color, id_usuario_asignado) VALUES (@idTablero, @nombre, @estado, @descrip, @color, @idUsuAsig)";
            
            using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
                
                connection.Open();
                var comando = new SQLiteCommand(query, connection);
                
                comando.Parameters.Add(new SQLiteParameter("@idTablero", idTablero));
                comando.Parameters.Add(new SQLiteParameter("@nombre", tarea.NombreTarea));
                comando.Parameters.Add(new SQLiteParameter("@estado", tarea.Estado1));
                comando.Parameters.Add(new SQLiteParameter("@descrip", tarea.DescripcionTarea));
                comando.Parameters.Add(new SQLiteParameter("@color", tarea.Color));
                comando.Parameters.Add(new SQLiteParameter("@idUsuAsig", tarea.IdUsuarioAsignado1));

                comando.ExecuteNonQuery();
                connection.Close();
            }
            return tarea;
        }

        public void ModificarTarea(int idTarea, Tarea tarea){
            SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
            SQLiteCommand command = connection.CreateCommand();
            
            command.CommandText = $"UPDATE Tarea SET id_tablero = '{tarea.IdTablero}', nombre = '{tarea.NombreTarea}', estado = '{tarea.Estado1}', descripcion = '{tarea.DescripcionTarea}', color = '{tarea.Color}', id_usuario_asignado = '{tarea.IdUsuarioAsignado1}' WHERE id = '{idTarea}';";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Tarea ObtenerTarea(int idTarea){
            SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
            var tarea = new Tarea();
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Tarea WHERE id = @idTarea";
            command.Parameters.Add(new SQLiteParameter("@idTarea", idTarea));
            connection.Open();
            using(SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    tarea.IdTarea = Convert.ToInt32(reader["id"]);
                    tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                    tarea.NombreTarea = reader["nombre"].ToString();
                    tarea.Estado1 = (EstadoTarea)Convert.ToInt32(reader["estado"]);
                    tarea.DescripcionTarea = reader["descripcion"].ToString();
                    tarea.Color = reader["color"].ToString();
                    tarea.IdUsuarioAsignado1 = Convert.ToInt32(reader["id_usuario_asignado"]);
                }
            }
            connection.Close();
            return (tarea);
        }
        
        public List<Tarea> ListarTareasUsuario(int idUsuario){
            SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
            List<Tarea> listaTareas = new List<Tarea>();

            SQLiteCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Tarea WHERE id_usuario_asignado = @idUsuario";
            command.Parameters.Add(new SQLiteParameter("@idUsuario", idUsuario));
            
            connection.Open();
            
            using(SQLiteDataReader reader = command.ExecuteReader()){
                
                while (reader.Read()){     
                    var tarea = new Tarea();
                    tarea.IdTarea = Convert.ToInt32(reader["id"]);
                    tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                    tarea.NombreTarea = reader["nombre"].ToString();
                    tarea.Estado1 = (EstadoTarea)(Convert.ToInt32(reader["estado"]));
                    tarea.DescripcionTarea = reader["descripcion"].ToString();
                    tarea.Color = reader["color"].ToString();
                    tarea.IdUsuarioAsignado1 = Convert.ToInt32(reader["id_usuario_asignado"]);
                    listaTareas.Add(tarea);
                }
            }   
            connection.Close();
            return listaTareas; 
        }

        public List<Tarea> ListarTareasTablero(int idTablero){
            SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
            List<Tarea> listaTareas = new List<Tarea>();

            SQLiteCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Tarea WHERE id_usuario_asignado = @idTablero";
            command.Parameters.Add(new SQLiteParameter("@idTablero", idTablero));
            
            connection.Open();
            
            using(SQLiteDataReader reader = command.ExecuteReader()){
                
                while (reader.Read()){     
                    var tarea = new Tarea();
                    tarea.IdTarea = Convert.ToInt32(reader["id"]);
                    tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                    tarea.NombreTarea = reader["nombre"].ToString();
                    tarea.Estado1 = (EstadoTarea)(Convert.ToInt32(reader["estado"]));
                    tarea.DescripcionTarea = reader["descripcion"].ToString();
                    tarea.Color = reader["color"].ToString();
                    tarea.IdUsuarioAsignado1 = Convert.ToInt32(reader["id_usuario_asignado"]);
                    listaTareas.Add(tarea);
                }
            }   
            connection.Close();
            return listaTareas; 
        }

        public void EliminarTarea(int idTarea){
            SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
            SQLiteCommand command = connection.CreateCommand();
            
            command.CommandText = $"DELETE FROM Tarea WHERE id = '{idTarea}';";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void AsignarUsuarioATarea(int idUsuario, int idTarea){
            SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
            SQLiteCommand command = connection.CreateCommand();
            
            command.CommandText = $"UPDATE Tarea SET id_usuario_asignado = '{idUsuario}' WHERE id = '{idTarea}';";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

    }
}