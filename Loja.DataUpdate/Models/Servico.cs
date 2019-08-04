using System;
using System.Collections.Generic;

namespace Loja.DataUpdate.Models
{
    public partial class Servico
    {
        public Servico()
        {
            this.ServicoUsuarioPerfils = new List<ServicoUsuarioPerfil>();
        }

        public int ServicoId { get; set; }
        public string NomeServico { get; set; }
        public Nullable<bool> Ativo { get; set; }
        public virtual ICollection<ServicoUsuarioPerfil> ServicoUsuarioPerfils { get; set; }
    }
}
