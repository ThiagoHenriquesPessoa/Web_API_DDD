using Entidades.Entidades;
using System;

namespace Dominio.Servicos
{
    public class DataNascimento
    {
        public static int Idade(Contato contato)        
        {
            var dataNascimento = contato.DataNascimento;
            int idade = DateTime.Now.Year - dataNascimento.Year;
            if (DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
            {
                idade = idade - 1;
            }
            return idade;
        }        
    }
}
