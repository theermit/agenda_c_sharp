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
    public interface IContatoDAO
    {
        public Task<List<Contato>> List();
        public void Create(Contato contato);
        public void Destroy(int Id);
    }
}