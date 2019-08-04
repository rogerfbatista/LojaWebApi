using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Loja.Domain.Entities
{
    [DataContract(Name = "Servico")]
    public class Servico
    {
        protected Servico()
        {
            ServicoUsuarioPerfil = new Collection<ServicoUsuarioPerfil>();
        }

        public Servico(string nomeServico, bool? ativo = true, int servicoId = 0, ICollection<ServicoUsuarioPerfil> servicoUsuarioPerfil = null)
        {
            NomeServico = nomeServico;
            Ativo = ativo;
            ServicoId = servicoId;
            ServicoUsuarioPerfil = servicoUsuarioPerfil;
        }

        public Servico(string nomeServico, bool ativo = true, int servicoId = 0)
        {
            NomeServico = nomeServico;
            Ativo = ativo;
            ServicoId = servicoId;
        }
        [DataMember(Name = "ServicoId")]
        public int ServicoId { get; private set; }
        [DataMember(Name = "NomeServico")]
        public string NomeServico { get; private set; }
        [DataMember(Name = "Ativo")]
        public bool? Ativo { get; private set; }
        [DataMember(Name = "ServicoUsuarioPerfil")]
        public virtual ICollection<ServicoUsuarioPerfil> ServicoUsuarioPerfil { get; private set; }


    }
}
