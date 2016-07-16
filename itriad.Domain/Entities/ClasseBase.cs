using Itriad.Infra.CrossCutting.Common.Enum;
using System;

namespace Itriad.Domain.Entities
{
    public class ClasseBase
    {
        public bool Ativo { get; set; }

        #region Auditoria
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime? DataInativacao { get; set; }
        public string UsuarioCadastro { get; set; }
        public string UsuarioAtualizacao { get; set; }
        public eOPERACAO Operacao { get; set; }
        #endregion

    }
}
