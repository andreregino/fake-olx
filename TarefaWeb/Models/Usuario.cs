using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TarefaWeb.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Por favor, preencha o nome do usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, preencha o email do usuário")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, preencha a senha do usuário")]
        public String Senha { get; set; }

        [Required(ErrorMessage = "Por favor, preencha a receita do usuário")]
        public Decimal Receita { get; set; }

    }
}