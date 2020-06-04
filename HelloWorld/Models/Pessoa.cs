using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Models
{
    public class Pessoa
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public String Nome { get; set; }
        [Required]
        [Display(Name = "Sobrenome")]
        public String Sobrenome { get; set; }
        [Required]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataDeNascimento { get; set; }
    }
}
