using System.Collections;
using System.Collections.Generic;

namespace Itriad.Domain.Entities
{
    public class Cargo :ClasseBase
    {
        public long CargoId { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Profissional> Profissionais { get; set; }
    }
}