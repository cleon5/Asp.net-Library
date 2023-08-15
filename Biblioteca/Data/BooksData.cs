using Biblioteca.Models;
using System.Data.SqlClient;
using System.Data;

namespace Biblioteca.Data
{
    public class BooksData
    {
        public List<LibroModelo> ListBook()
        {
            List<LibroModelo> listaReturn = new List<LibroModelo>();
            var conn = new Conexion();

            using(var conexion = new SqlConnection(conn.getCadenaSql())) { 
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_loadAll", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var dr =  cmd.ExecuteReader()) { 
                    
                    while(dr.Read()) {
                        listaReturn.Add(new LibroModelo()
                        {
                            Id_Libro = Convert.ToInt32(dr["Id_Libro"].ToString()),
                            Nombre = dr["Nombre"].ToString(),
                            Pages = Convert.ToInt32(dr["Pages"].ToString()),
                            Tipo = dr["Tipo"].ToString(),
                            Genero = dr["Genero"].ToString(),
                        });
                    }
                }
            }
            return listaReturn;
        }

        public LibroModelo GetBook(int idLibro)
        {
            LibroModelo Libro = new LibroModelo();
            var conn = new Conexion();

            using (var conexion = new SqlConnection(conn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_read", conexion);
                cmd.Parameters.AddWithValue("Id", idLibro);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        Libro.Id_Libro = Convert.ToInt32(dr["Id_Libro"].ToString());
                        Libro.Nombre = dr["Nombre"].ToString();
                        Libro.Pages = Convert.ToInt32(dr["Pages"].ToString());
                        Libro.Tipo = dr["Tipo"].ToString();
                        Libro.Genero = dr["Genero"].ToString();
                    }
                }
            }
            return Libro;
        }
        public bool SaveBook(LibroModelo Libro)
        {
            bool response = false;

            try
            {
                var conn = new Conexion();
                using (var conexion = new SqlConnection(conn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_create", conexion);
                    cmd.Parameters.AddWithValue("Nombre", Libro.Nombre);
                    cmd.Parameters.AddWithValue("Pages", Libro.Pages);
                    cmd.Parameters.AddWithValue("Tipo", Libro.Tipo);
                    cmd.Parameters.AddWithValue("Genero", Libro.Genero);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                response = true;
            }
            catch (Exception err)
            {
                string msg = err.Message;
                response = false;
            }

            return response;
        }
        public bool UpdateBook(LibroModelo Libro)
        {
            bool response = false;

            var conn = new Conexion();
            try
            {
                using (var conexion = new SqlConnection(conn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_UpdateBook", conexion);
                    cmd.Parameters.AddWithValue("IdLibro", Libro.Id_Libro);
                    cmd.Parameters.AddWithValue("Nombre", Libro.Nombre);
                    cmd.Parameters.AddWithValue("Pages", Libro.Pages);
                    cmd.Parameters.AddWithValue("Tipo", Libro.Tipo);
                    cmd.Parameters.AddWithValue("Genero", Libro.Genero);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                response = true;
            }
            catch (Exception err)
            {
                string msg = err.Message;
                response = false;
            }

            return response;
        }
        public bool DeleteBook(int idLibro)
        {
            bool response = false;

            var conn = new Conexion();
            try
            {
                using (var conexion = new SqlConnection(conn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_delete", conexion);
                    cmd.Parameters.AddWithValue("Id", idLibro);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                response = true;
            }
            catch(Exception err)
            {
                string msg = err.Message;
                response = false;
            }

            return response;
        }
    }
}
