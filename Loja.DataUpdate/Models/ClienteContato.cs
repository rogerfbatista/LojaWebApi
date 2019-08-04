using System;
using System.Collections.Generic;

namespace Loja.DataUpdate.Models
{
    public partial class ClienteContato
    {
        public int ClienteContatoId { get; set; }
        public Nullable<int> ClienteId { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
