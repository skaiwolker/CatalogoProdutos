using System.ComponentModel.DataAnnotations;

namespace CatalogoProdutos.Models
{
    public class Produto
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; } = null!;

        [Range(0, double.MaxValue, ErrorMessage = "Insira um numero valido!")]
        public string Preco { get; set; } = null!;

        [MaxLength(500)]
        public string Descricao { get; set; } = null!;

        [Range(0, int.MaxValue, ErrorMessage = "Insira um numero valido!")]
        public int Quantidade { get; set; }

        [Required]
        public string Tipo { get; set; } = null!;

        public DateTime DataDeCadastro { get; set; }

        public void GenerateNewProduto()
        {
            Id = Guid.NewGuid();
            DataDeCadastro = DateTime.Now;
        }
    }
}
