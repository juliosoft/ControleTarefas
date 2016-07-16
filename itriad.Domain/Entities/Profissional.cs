using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itriad.Domain.Entities
{
    public class Profissional : ClasseBase
    {
        public long ProfissionalId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public long CargoId { get; set; }
        public long EmpresaId { get; set; }

        public virtual Cargo Cargo { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<HistoricoTarefa> HistoricoTarefas { get; set; }
        public virtual ICollection<Tarefa> Tarefas { get; set; }
    }
}
