using System;
using System.Reflection;
using Loja.Application;
using Loja.Application.Interfaces;
using Loja.Data.Repositorys;
using Loja.Domain.Interfaces.Repositorys;
using Loja.Domain.Interfaces.Services;
using Loja.Domain.Services;
using Ninject;
using Ninject.Extensions.Wcf;
using Ninject.Web.Common;

namespace Loja.Startup
{
    public static class NinjectConfig
    {
        #region Métodos

        public static void CreateKernelWcf(WcfModule kernel)
        {
            try
            {
               
                //Cliente
                kernel.Bind<IClienteAppService>().To<ClienteAppService>().InRequestScope();
                kernel.Bind<IClienteService>().To<ClienteService>().InRequestScope();
                kernel.Bind<IClienteRepository>().To<ClienteRepository>().InRequestScope();

                //ClienteContato
                kernel.Bind<IClienteContatoAppService>().To<ClienteContatoAppService>().InRequestScope();
                kernel.Bind<IClienteContatoService>().To<ClienteContatoService>().InRequestScope();
                kernel.Bind<IClienteContatoRepository>().To<ClienteContatoRepository>().InRequestScope();

                //Empresa
                kernel.Bind<IEmpresaAppService>().To<EmpresaAppService>().InRequestScope();
                kernel.Bind<IEmpresaService>().To<EmpresaService>().InRequestScope();
                kernel.Bind<IEmpresaRepository>().To<EmpresaRepository>().InRequestScope();

                //EmpresaCliente
                kernel.Bind<IEmpresaClienteAppService>().To<EmpresaClienteAppService>().InRequestScope();
                kernel.Bind<IEmpresaClienteService>().To<EmpresaClienteService>().InRequestScope();
                kernel.Bind<IEmpresaClienteRepository>().To<EmpresaClienteRepository>().InRequestScope();

                //EmpresaContato
                kernel.Bind<IEmpresaContatoAppService>().To<EmpresaContatoAppService>().InRequestScope();
                kernel.Bind<IEmpresaContatoService>().To<EmpresaContatoService>().InRequestScope();
                kernel.Bind<IEmpresaContatoRepository>().To<EmpresaContatoRepository>().InRequestScope();

                //EmpresaFornecedor
                kernel.Bind<IEmpresaFornecedorAppService>().To<EmpresaFornecedorAppService>().InRequestScope();
                kernel.Bind<IEmpresaFornecedorService>().To<EmpresaFornecedorService>().InRequestScope();
                kernel.Bind<IEmpresaFornecedorRepository>().To<EmpresaFornecedorRepository>().InRequestScope();

                //Fornecedor
                kernel.Bind<IFornecedorAppService>().To<FornecedorAppService>().InRequestScope();
                kernel.Bind<IFornecedorService>().To<FornecedorService>().InRequestScope();
                kernel.Bind<IFornecedorRepository>().To<FornecedorRepository>().InRequestScope();

                //FornecedorContato
                kernel.Bind<IFornecedorContatoAppService>().To<FornecedorContatoAppService>().InRequestScope();
                kernel.Bind<IFornecedorContatoService>().To<FornecedorContatoService>().InRequestScope();
                kernel.Bind<IFornecedorContatoRepository>().To<FornecedorContatoRepository>().InRequestScope();

                //Menu
                kernel.Bind<IMenuAppService>().To<MenuAppService>().InRequestScope();
                kernel.Bind<IMenuService>().To<MenuService>().InRequestScope();
                kernel.Bind<IMenuRepository>().To<MenuRepository>().InRequestScope();

                //MenuTipo
                kernel.Bind<IMenuTipoAppService>().To<MenuTipoAppService>().InRequestScope();
                kernel.Bind<IMenuTipoService>().To<MenuTipoService>().InRequestScope();
                kernel.Bind<IMenuTipoRepository>().To<MenuTipoRepository>().InRequestScope();

                //Produto
                kernel.Bind<IProdutoAppService>().To<ProdutoAppService>().InRequestScope();
                kernel.Bind<IProdutoService>().To<ProdutoService>().InRequestScope();
                kernel.Bind<IProdutoRepository>().To<ProdutoRepository>().InRequestScope();

                //ProdutoClienteSaida
                kernel.Bind<IProdutoClienteSaidaAppService>().To<ProdutoClienteSaidaAppService>().InRequestScope();
                kernel.Bind<IProdutoClienteSaidaService>().To<ProdutoClienteSaidaService>().InRequestScope();
                kernel.Bind<IProdutoClienteSaidaRepository>().To<ProdutoClienteSaidaRepository>().InRequestScope();

                //ProdutoEstoque
                kernel.Bind<IProdutoEstoqueAppService>().To<ProdutoEstoqueAppService>().InRequestScope();
                kernel.Bind<IProdutoEstoqueService>().To<ProdutoEstoqueService>().InRequestScope();
                kernel.Bind<IProdutoEstoqueRepository>().To<ProdutoEstoqueRepository>().InRequestScope();

                //ProdutoFormasDePagamento
                kernel.Bind<IProdutoFormasDePagamentoAppService>()
                    .To<ProdutoFormasDePagamentoAppService>()
                    .InRequestScope();
                kernel.Bind<IProdutoFormasDePagamentoService>().To<ProdutoFormasDePagamentoService>().InRequestScope();
                kernel.Bind<IProdutoFormasDePagamentoRepository>()
                    .To<ProdutoFormasDePagamentoRepository>()
                    .InRequestScope();

                //ProdutoFornecedorEntrada
                kernel.Bind<IProdutoFornecedorEntradaAppService>()
                    .To<ProdutoFornecedorEntradaAppService>()
                    .InRequestScope();
                kernel.Bind<IProdutoFornecedorEntradaService>().To<ProdutoFornecedorEntradaService>().InRequestScope();
                kernel.Bind<IProdutoFornecedorEntradaRepository>()
                    .To<ProdutoFornecedorEntradaRepository>()
                    .InRequestScope();

                //ProdutoTipo
                kernel.Bind<IProdutoTipoAppService>().To<ProdutoTipoAppService>().InRequestScope();
                kernel.Bind<IProdutoTipoService>().To<ProdutoTipoService>().InRequestScope();
                kernel.Bind<IProdutoTipoRepository>().To<ProdutoTipoRepository>().InRequestScope();


                //Usuario
                kernel.Bind<IUsuarioAppService>().To<UsuarioAppService>().InRequestScope();
                kernel.Bind<IUsuarioService>().To<UsuarioService>().InRequestScope();
                kernel.Bind<IUsuarioRepository>().To<UsuarioRepository>().InRequestScope();

                //UsuarioPerfil
                kernel.Bind<IUsuarioPerfilAppService>().To<UsuarioPerfilAppService>().InRequestScope();
                kernel.Bind<IUsuarioPerfilService>().To<UsuarioPerfilService>().InRequestScope();
                kernel.Bind<IUsuarioPerfilRepository>().To<UsuarioPerfilRepository>().InRequestScope();


                //UsuarioPerfilMenu
                kernel.Bind<IUsuarioPerfilMenuAppService>().To<UsuarioPerfilMenuAppService>().InRequestScope();
                kernel.Bind<IUsuarioPerfilMenuService>().To<UsuarioPerfilMenuService>().InRequestScope();
                kernel.Bind<IUsuarioPerfilMenuRepository>().To<UsuarioPerfilMenuRepository>().InRequestScope();


                //Servico
                kernel.Bind<IServicoAppService>().To<ServicoAppService>().InRequestScope();
                kernel.Bind<IServicoService>().To<ServicoService>().InRequestScope();
                kernel.Bind<IServicoRepository>().To<ServicoRepository>().InRequestScope();

                //ServicoUsuarioPerfil
                kernel.Bind<IServicoUsuarioPerfilAppService>().To<ServicoUsuarioPerfilAppService>().InRequestScope();
                kernel.Bind<IServicoUsuarioPerfilService>().To<ServicoUsuarioPerfilService>().InRequestScope();
                kernel.Bind<IServicoUsuarioPerfilRepository>().To<ServicoUsuarioPerfilRepository>().InRequestScope();

                //Email
                kernel.Bind<IEmailAppService>().To<EmailAppService>().InRequestScope();
                kernel.Bind<IEmailService>().To<EmailService>().InRequestScope();
                kernel.Bind<IEmailRepository>().To<EmailRepository>().InRequestScope();


                //ProdutoClienteSaidaItem
                kernel.Bind<IProdutoClienteSaidaItemAppService>().To<ProdutoClienteSaidaItemAppService>().InRequestScope();
                kernel.Bind<IProdutoClienteSaidaItemService>().To<ProdutoClienteSaidaItemService>().InRequestScope();
                kernel.Bind<IProdutoClienteSaidaItemRepository>().To<ProdutoClienteSaidaItemRepository>().InRequestScope();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            try
            {
                kernel.Load(Assembly.GetExecutingAssembly());

                //Cliente
                kernel.Bind<IClienteAppService>().To<ClienteAppService>();
                kernel.Bind<IClienteService>().To<ClienteService>();
                kernel.Bind<IClienteRepository>().To<ClienteRepository>();

                //ClienteContato
                kernel.Bind<IClienteContatoAppService>().To<ClienteContatoAppService>();
                kernel.Bind<IClienteContatoService>().To<ClienteContatoService>();
                kernel.Bind<IClienteContatoRepository>().To<ClienteContatoRepository>();

                //Empresa
                kernel.Bind<IEmpresaAppService>().To<EmpresaAppService>();
                kernel.Bind<IEmpresaService>().To<EmpresaService>();
                kernel.Bind<IEmpresaRepository>().To<EmpresaRepository>();

                //EmpresaCliente
                kernel.Bind<IEmpresaClienteAppService>().To<EmpresaClienteAppService>();
                kernel.Bind<IEmpresaClienteService>().To<EmpresaClienteService>();
                kernel.Bind<IEmpresaClienteRepository>().To<EmpresaClienteRepository>();

                //EmpresaContato
                kernel.Bind<IEmpresaContatoAppService>().To<EmpresaContatoAppService>();
                kernel.Bind<IEmpresaContatoService>().To<EmpresaContatoService>();
                kernel.Bind<IEmpresaContatoRepository>().To<EmpresaContatoRepository>();

                //EmpresaFornecedor
                kernel.Bind<IEmpresaFornecedorAppService>().To<EmpresaFornecedorAppService>();
                kernel.Bind<IEmpresaFornecedorService>().To<EmpresaFornecedorService>();
                kernel.Bind<IEmpresaFornecedorRepository>().To<EmpresaFornecedorRepository>();

                //Fornecedor
                kernel.Bind<IFornecedorAppService>().To<FornecedorAppService>();
                kernel.Bind<IFornecedorService>().To<FornecedorService>();
                kernel.Bind<IFornecedorRepository>().To<FornecedorRepository>();

                //FornecedorContato
                kernel.Bind<IFornecedorContatoAppService>().To<FornecedorContatoAppService>();
                kernel.Bind<IFornecedorContatoService>().To<FornecedorContatoService>();
                kernel.Bind<IFornecedorContatoRepository>().To<FornecedorContatoRepository>();

                //Menu
                kernel.Bind<IMenuAppService>().To<MenuAppService>();
                kernel.Bind<IMenuService>().To<MenuService>();
                kernel.Bind<IMenuRepository>().To<MenuRepository>();

                //MenuTipo
                kernel.Bind<IMenuTipoAppService>().To<MenuTipoAppService>();
                kernel.Bind<IMenuTipoService>().To<MenuTipoService>();
                kernel.Bind<IMenuTipoRepository>().To<MenuTipoRepository>();

                //Produto
                kernel.Bind<IProdutoAppService>().To<ProdutoAppService>();
                kernel.Bind<IProdutoService>().To<ProdutoService>();
                kernel.Bind<IProdutoRepository>().To<ProdutoRepository>();

                //ProdutoClienteSaida
                kernel.Bind<IProdutoClienteSaidaAppService>().To<ProdutoClienteSaidaAppService>();
                kernel.Bind<IProdutoClienteSaidaService>().To<ProdutoClienteSaidaService>();
                kernel.Bind<IProdutoClienteSaidaRepository>().To<ProdutoClienteSaidaRepository>();

                //ProdutoEstoque
                kernel.Bind<IProdutoEstoqueAppService>().To<ProdutoEstoqueAppService>();
                kernel.Bind<IProdutoEstoqueService>().To<ProdutoEstoqueService>();
                kernel.Bind<IProdutoEstoqueRepository>().To<ProdutoEstoqueRepository>();

                //ProdutoFormasDePagamento
                kernel.Bind<IProdutoFormasDePagamentoAppService>().To<ProdutoFormasDePagamentoAppService>();
                kernel.Bind<IProdutoFormasDePagamentoService>().To<ProdutoFormasDePagamentoService>();
                kernel.Bind<IProdutoFormasDePagamentoRepository>().To<ProdutoFormasDePagamentoRepository>();

                //ProdutoFornecedorEntrada
                kernel.Bind<IProdutoFornecedorEntradaAppService>().To<ProdutoFornecedorEntradaAppService>();
                kernel.Bind<IProdutoFornecedorEntradaService>().To<ProdutoFornecedorEntradaService>();
                kernel.Bind<IProdutoFornecedorEntradaRepository>().To<ProdutoFornecedorEntradaRepository>();

                //ProdutoTipo
                kernel.Bind<IProdutoTipoAppService>().To<ProdutoTipoAppService>();
                kernel.Bind<IProdutoTipoService>().To<ProdutoTipoService>();
                kernel.Bind<IProdutoTipoRepository>().To<ProdutoTipoRepository>();


                //Usuario
                kernel.Bind<IUsuarioAppService>().To<UsuarioAppService>();
                kernel.Bind<IUsuarioService>().To<UsuarioService>();
                kernel.Bind<IUsuarioRepository>().To<UsuarioRepository>();

                //UsuarioPerfil
                kernel.Bind<IUsuarioPerfilAppService>().To<UsuarioPerfilAppService>();
                kernel.Bind<IUsuarioPerfilService>().To<UsuarioPerfilService>();
                kernel.Bind<IUsuarioPerfilRepository>().To<UsuarioPerfilRepository>();


                //UsuarioPerfilMenu
                kernel.Bind<IUsuarioPerfilMenuAppService>().To<UsuarioPerfilMenuAppService>();
                kernel.Bind<IUsuarioPerfilMenuService>().To<UsuarioPerfilMenuService>();
                kernel.Bind<IUsuarioPerfilMenuRepository>().To<UsuarioPerfilMenuRepository>();

                //Servico
                kernel.Bind<IServicoAppService>().To<ServicoAppService>();
                kernel.Bind<IServicoService>().To<ServicoService>();
                kernel.Bind<IServicoRepository>().To<ServicoRepository>();

                //ServicoUsuarioPerfil
                kernel.Bind<IServicoUsuarioPerfilAppService>().To<ServicoUsuarioPerfilAppService>();
                kernel.Bind<IServicoUsuarioPerfilService>().To<ServicoUsuarioPerfilService>();
                kernel.Bind<IServicoUsuarioPerfilRepository>().To<ServicoUsuarioPerfilRepository>();


                //Email
                kernel.Bind<IEmailAppService>().To<EmailAppService>();
                kernel.Bind<IEmailService>().To<EmailService>();
                kernel.Bind<IEmailRepository>().To<EmailRepository>();



                //ProdutoClienteSaida
                kernel.Bind<IProdutoClienteSaidaItemAppService>().To<ProdutoClienteSaidaItemAppService>();
                kernel.Bind<IProdutoClienteSaidaItemService>().To<ProdutoClienteSaidaItemService>();
                kernel.Bind<IProdutoClienteSaidaItemRepository>().To<ProdutoClienteSaidaItemRepository>();


                return kernel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
