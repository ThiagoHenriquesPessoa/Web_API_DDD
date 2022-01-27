using Entidades.Entidades;
using System;

namespace Dominio.Servicos
{
    public class Validacao
    {
        public static string Validar(Contato contato)
        {
            if (contato.Nome == null)
                return "false-Campo nome deve ser preenchido";

            if (contato.Sexo == null)
                return "false-Campo gênero deve ser preenchido";

            if (contato.DataNascimento.Date > DateTime.Today)
                return "false-Data de nascimento é maior que a data atual";

            if (contato.Idade < 18)
                return "false-O contato tem que ser maior de idade";

            return "true";
        }
    }
}
