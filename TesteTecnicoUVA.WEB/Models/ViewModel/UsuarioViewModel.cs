using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteTecnicoUVA.WEB.Models.ViewModel
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome completo deve ser informado")]
        [MaxLength(50)]
        [DisplayName("Nome Completo")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O CPF deve ser informado")]
        [RegularExpression("^\\d{3}.\\d{3}.\\d{3}-\\d{2}$", ErrorMessage = "Informe um cpf válido!")]
        [MaxLength(14)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O telefone deve ser informado")]
        [MaxLength(14)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O celular deve ser informado")]
        [MaxLength(15)]
        [DisplayName("Telefone Celular")]
        public string TelefoneCelular { get; set; }

        [Required(ErrorMessage = "O e-mail deve ser informado")]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Informe um e-mail válido!")]
        [MaxLength(100)]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "A data de criação deve ser informada")]
        [DisplayName("Data de Criação")]
        public DateTime DataCriacao { get; set; }

        public bool Ativo { get; set; }
    }
}