using Bogus;
using Bogus.DataSets;
using Entidades.Entidades;
using System;

namespace Testes.TesteContato
{
    public class GerarContato
    {
        public static Contato GerarContatoValido()
        {
            var sexo = new Faker().PickRandom<Name.Gender>();
            string genero = Convert.ToString(sexo);
            var contato = new Faker<Contato>();
            contato.RuleFor(c => c.Id, (f, c) => f.Random.Guid());
            contato.RuleFor(c => c.Nome, (f, c) => f.Name.FullName());
            contato.RuleFor(c => c.DataNascimento, (f, c) => f.Date.Past(100, DateTime.Now.AddYears(-18)));
            contato.RuleFor(c => c.Sexo, (f, c) => f.PickRandom(genero));
            contato.RuleFor(c => c.Ativo, (f, c) => f.Random.Bool());
            return contato;
        }
        public static Contato GerarContatoInvalidoNome()
        {
            var sexo = new Faker().PickRandom<Name.Gender>();
            string genero = Convert.ToString(sexo);
            var contato = new Faker<Contato>();
            contato.RuleFor(c => c.Id, (f, c) => f.Random.Guid());
            contato.RuleFor(c => c.Nome, (f, c) => f.PickRandom(""));
            contato.RuleFor(c => c.DataNascimento, (f, c) => f.Date.Past(100, DateTime.Now.AddYears(-18)));
            contato.RuleFor(c => c.Sexo, (f, c) => f.PickRandom(genero));
            contato.RuleFor(c => c.Ativo, (f, c) => f.Random.Bool());
            return contato;
        }
        public static Contato GerarContatoInvalidoGenero()
        {            
            string genero = "";
            var contato = new Faker<Contato>();
            contato.RuleFor(c => c.Id, (f, c) => f.Random.Guid());
            contato.RuleFor(c => c.Nome, (f, c) => f.Name.FullName());
            contato.RuleFor(c => c.DataNascimento, (f, c) => f.Date.Past(100, DateTime.Now.AddYears(-18)));
            contato.RuleFor(c => c.Sexo, (f, c) => f.PickRandom(genero));
            contato.RuleFor(c => c.Ativo, (f, c) => f.Random.Bool());
            return contato;
        }
        public static Contato GerarContatoInvalidoIdade()
        {
            var sexo = new Faker().PickRandom<Name.Gender>();
            string genero = Convert.ToString(sexo);
            var contato = new Faker<Contato>();
            contato.RuleFor(c => c.Id, (f, c) => f.Random.Guid());
            contato.RuleFor(c => c.Nome, (f, c) => f.Name.FullName());
            contato.RuleFor(c => c.DataNascimento, (f, c) => f.Date.Past(10, DateTime.Now.AddYears(-1)));
            contato.RuleFor(c => c.Sexo, (f, c) => f.PickRandom(genero));
            contato.RuleFor(c => c.Ativo, (f, c) => f.Random.Bool());
            return contato;
        }
        public static Contato GerarContatoInvalidoDNascimento()
        {
            var sexo = new Faker().PickRandom<Name.Gender>();
            string genero = Convert.ToString(sexo);
            var contato = new Faker<Contato>();
            contato.RuleFor(c => c.Id, (f, c) => f.Random.Guid());
            contato.RuleFor(c => c.Nome, (f, c) => f.Name.FullName());
            contato.RuleFor(c => c.DataNascimento, (f, c) => f.Date.Past(-5, DateTime.Now.AddYears(-1)));
            contato.RuleFor(c => c.Sexo, (f, c) => f.PickRandom(genero));
            contato.RuleFor(c => c.Ativo, (f, c) => f.Random.Bool());
            return contato;
        }
    }
}
