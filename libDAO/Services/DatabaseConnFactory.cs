/*
    AUTOR: Benhur Alencar Azevedo
    UTILIDADE: criar objetos de conexao
*/

using System.Data.Odbc;

namespace libDAO.Services 
{
    public class DatabaseConnFactory
    {
        public static OdbcConnection CreateConn()
        {
            string connection_string = "DSN=teste";
            OdbcConnection conn = new OdbcConnection(connection_string);
            return conn;
        }
    }
}