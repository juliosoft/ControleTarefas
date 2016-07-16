using System.Collections.Generic;

namespace Itriad.Domain.Entities
{
    public class TipoTarefa :ClasseBase
    {
        public long TipoTarefaId { get; set; }
        public string Descricao { get; set; }
    }
}