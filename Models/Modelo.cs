using System.ComponentModel.DataAnnotations;

namespace ApiComMysql.Models
{
    public class Modelo
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Nome muito longo, somente 20 caracteres")]
        public string Nome { get; set; }
        [Required]
        public DateTime DataCriacao { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Nome do Criador muito longo, somente 30 caracteres")]
        public string NomeCriador { get; set; }

    }
}