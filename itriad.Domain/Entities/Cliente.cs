using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itriad.Domain.Entities
{
    public class Cliente : ClasseBase
    {
        public long ClienteId { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }

        public virtual  ICollection<Projeto> Projetos { get; set; }
    }
}
