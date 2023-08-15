﻿using System.Data.SqlClient;
namespace Biblioteca.Data
{
    public class Conexion
    {
        private string cadenaSQL = "";
        public Conexion() {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        public string getCadenaSql()
        {
            return cadenaSQL;
        }
    }
}
