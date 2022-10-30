using System.ComponentModel.DataAnnotations;

namespace TesteTecnicoUVA.API.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string NomeCompleto { get; set; }

        [Required]
        [MaxLength(14)]
        public string Cpf { get; set; }

        [Required]
        [MaxLength(14)]
        public string Telefone { get; set; }

        [Required]
        [MaxLength(15)]
        public string TelefoneCelular { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataCriacao { get; set; }

        public bool Ativo { get; set; }
    }
}
