/*
    AUTOR: Benhur Alencar Azevedo
    UTILIDADE: model de contato da agenda
*/

namespace libDAO.Models
{
    public class Contato
    {
        public long Id{get;set;}
        public string? Nome {get;set;}
        public string? Telefone{get;set;}
    }
}