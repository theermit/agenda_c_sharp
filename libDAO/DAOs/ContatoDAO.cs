/*
    AUTOR: Benhur Alencar Azevedo
    UTILIDADE: DAO de contatos da agenda
*/

using System;
using System.Data.Odbc;
using libDAO.Services;
using libDAO.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data.Common;

namespace libDAO.DAOs
{
    public class ContatoDAO
    {
        private OdbcConnection? conn;

        public ContatoDAO()
        {
            conn = DatabaseConnFactory.CreateConn();
        }
        public async Task<List<Contato>> List()
        {
            List<Contato> lista = new List<Contato>();
            Contato contato;

            string queryString = "SELECT ID, NOME, TELEFONE FROM NOMES";
            OdbcCommand command = new OdbcCommand(queryString, conn);
            try 
            {
                await conn.OpenAsync();
                DbDataReader reader = await command.ExecuteReaderAsync();
                while(await reader.ReadAsync())
                {
                    contato = new Contato
                    {
                        Id = (Int32)reader[0],
                        Nome = (string)reader[1],
                        Telefone = (string)reader[2]
                    };
                    lista.Add(contato);
                }
                await reader.CloseAsync();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                await conn.CloseAsync();
            }
            return lista;
        } 
        public async void Create(Contato contato)
        {
            string queryString = "INSERT INTO NOMES (NOME, TELEFONE) VALUES ('" + contato.Nome + "', '" + contato.Telefone + "')";
            OdbcCommand command = new OdbcCommand(queryString, conn);
            //command.Parameters.Add(new OdbcParameter("NOMECONTATO", contato.Nome));
            try 
            {
                await conn.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                await conn.CloseAsync();
            }
        }
        public async void Destroy(int Id)
        {
            string queryString = "DELETE FROM NOMES WHERE ID = " + Id;
            OdbcCommand command = new OdbcCommand(queryString, conn);
            //command.Parameters.Add(new OdbcParameter("NOMECONTATO", contato.Nome));
            try 
            {
                await conn.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                await conn.CloseAsync();
            }
        }
    }
}