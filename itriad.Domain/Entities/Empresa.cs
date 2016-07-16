using System.Collections.Generic;

namespace Itriad.Domain.Entities
{
    public class Empresa :ClasseBase
    {
        public long EmpresaId { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }

        public virtual ICollection<Profissional> Profissional { get; set; }
    }
}