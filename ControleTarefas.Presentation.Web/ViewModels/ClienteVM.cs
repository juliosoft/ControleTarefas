using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ControleTarefas.Infra.CrossCutting.Language.Resources;
namespace ControleTarefas.Portal.ViewModels
{
    public class ClienteVM
    {
        [Key] 
        public int ClienteId { get; set; }

        [Display(Name = "Cliente_Nome", ResourceType =typeof(Language))]
        [Required(ErrorMessage = "Prencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caractéres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caractéres")]
        public string Nome { get; set; }

        [Display(Name = "Cliente_SobreNome", ResourceType = typeof(Language))]
        [Required(ErrorMessage = "Prencha o campo SobreNome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caractéres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caractéres")]
        public string SobreNome { get; set; }

        [Required(ErrorMessage = "Prencha o campo E-mail")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caractéres")]
        [EmailAddress(ErrorMessage = "Preencha um e-mail válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }

        public virtual IEnumerable<ProdutoVM> Produtos { get; set; }
        
    }
}