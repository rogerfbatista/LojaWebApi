using System.Runtime.Serialization;

namespace Loja.Domain.Entities
{
    [DataContract(Name = "ServicoUsuarioPerfil")]
    public class ServicoUsuarioPerfil
    {
        protected ServicoUsuarioPerfil()
        {

        }


        public ServicoUsuarioPerfil(int servicoUsuarioPerfilId, int? servicoId, int? usuarioPerfilId, bool? ativo,
              UsuarioPerfil usuarioPerfil, Servico servico)
        {
            ServicoUsuarioPerfilId = servicoUsuarioPerfilId;
            ServicoId = servicoId;
            UsuarioPerfilId = usuarioPerfilId;
            Ativo = ativo;
            UsuarioPerfil = usuarioPerfil;
            Servico = servico;
        }

        public ServicoUsuarioPerfil(int servicoUsuarioPerfilId, int? servicoId, int? usuarioPerfilId, bool? ativo)
        {
            ServicoUsuarioPerfilId = servicoUsuarioPerfilId;
            ServicoId = servicoId;
            UsuarioPerfilId = usuarioPerfilId;
            Ativo = ativo;

        }


        [DataMember(Name = "ServicoUsuarioPerfilId")]
        public int ServicoUsuarioPerfilId { get; private set; }

        [DataMember(Name = "ServicoId")]
        public int? ServicoId { get; private set; }

        [DataMember(Name = "UsuarioPerfilId")]
        public int? UsuarioPerfilId { get; private set; }

        [DataMember(Name = "Ativo")]
        public bool? Ativo { get; private set; }

       [DataMember(Name = "UsuarioPerfil")]
        public virtual UsuarioPerfil UsuarioPerfil { get; private set; }
        [DataMember(Name = "Servico")]
        public virtual Servico Servico { get; private set; }


        public void SetObjNull()
        {
            UsuarioPerfil = null;
            Servico = null;
            ServicoUsuarioPerfilId = 0;
        }

        public void SetAtivoFalse()
        {
            Ativo = false;
        }



    }
}
