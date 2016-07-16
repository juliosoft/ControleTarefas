using Itriad.Domain.Entities;
using System.Collections.Generic;

namespace Itriad.Domain.Entities
{
    public class Time : ClasseBase
    {
        public long TimeId { get; set; }
        public string Nome { get; set; }
        public long ProjetoId { get; set; }
        public virtual Projeto Projeto { get; set; }
        public virtual ICollection<Profissional> Profissionais { get; set; }
    }
}
