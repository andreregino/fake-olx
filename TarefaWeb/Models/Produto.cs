using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TarefaWeb.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }

        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Por favor, preencha o nome do produto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, preencha o preço do produto")]
        public Decimal Preco { get; set; }

        [Required(ErrorMessage = "Por favor, preencha se o produto foi vendido ou não")]
        public bool Vendido { get; set; }

    }
}
