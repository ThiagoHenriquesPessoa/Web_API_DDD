using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades
{
    public class Contato : Entity
    {
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [Display(Name = "Data de nascimento")]
        public DateTime DataNascimento { get; set; }

        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [Display(Name = "Gênero")]
        public string Sexo { get; set; }
        public int Idade { get; set; }
    }
}
