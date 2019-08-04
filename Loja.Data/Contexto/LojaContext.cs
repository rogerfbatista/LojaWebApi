using System.Data.Entity;
using System.Data.Entity.SqlServer;
using Loja.Data.Models.Mapping;
using Loja.Domain.Entities;

namespace Loja.Data.Contexto
{
    public class LojaContext : DbContext
    {
        static LojaContext()
        {

            var ensureDllIsCopied = SqlProviderServices.Instance;

            Database.SetInitializer<LojaContext>(null);
        }

        public LojaContext()
            : base("Name=LojaContext")
        {
            
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<ClienteContato> ClienteContatos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<EmpresaCliente> EmpresaClientes { get; set; }
        public DbSet<EmpresaContato> EmpresaContatos { get; set; }
        public DbSet<EmpresaFornecedor> EmpresaFornecedor { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<FornecedorContato> FornecedorContatos { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuTipo> MenuTipoes { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<ProdutoClienteSaida> ProdutoClienteSaidas { get; set; }
        public DbSet<ProdutoClienteSaidaItem> ProdutoClienteSaidaItems { get; set; }
        public DbSet<ProdutoEstoque> ProdutoEstoques { get; set; }
        public DbSet<ProdutoFormasDePagamento> ProdutoFormasDePagamentoes { get; set; }
        public DbSet<ProdutoFornecedorEntrada> ProdutoFornecedorEntradas { get; set; }
        public DbSet<ProdutoTipo> ProdutoTipo { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioPerfil> UsuarioPerfils { get; set; }
        public DbSet<UsuarioPerfilMenu> UsuarioPerfilMenus { get; set; }
        public DbSet<Servico> Servico { get; set; }
        public DbSet<ServicoUsuarioPerfil> ServicoUsuarioPerfil { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new ClienteContatoMap());
            modelBuilder.Configurations.Add(new EmpresaMap());
            modelBuilder.Configurations.Add(new EmpresaClienteMap());
            modelBuilder.Configurations.Add(new EmpresaContatoMap());
            modelBuilder.Configurations.Add(new EmpresaFornecedorMap());
            modelBuilder.Configurations.Add(new FornecedorMap());
            modelBuilder.Configurations.Add(new FornecedorContatoMap());
            modelBuilder.Configurations.Add(new MenuMap());
            modelBuilder.Configurations.Add(new MenuTipoMap());
            modelBuilder.Configurations.Add(new ProdutoMap());
            modelBuilder.Configurations.Add(new ProdutoClienteSaidaMap());
            modelBuilder.Configurations.Add(new ProdutoClienteSaidaItemMap());
            modelBuilder.Configurations.Add(new ProdutoEstoqueMap());
            modelBuilder.Configurations.Add(new ProdutoFormasDePagamentoMap());
            modelBuilder.Configurations.Add(new ProdutoFornecedorEntradaMap());
            modelBuilder.Configurations.Add(new ProdutoTipoMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new UsuarioPerfilMap());
            modelBuilder.Configurations.Add(new UsuarioPerfilMenuMap());
            modelBuilder.Configurations.Add(new ServicoMap());
            modelBuilder.Configurations.Add(new ServicoUsuarioPerfilMap());
            //modelBuilder.Entity<ServicoUsuarioPerfil>().HasIndex("IX_ServicoUsuarioPerfil_name",
            //    configuration => configuration.Property(map => map.UsuarioPerfilId),configuration => configuration.Property(perfil => perfil));
        }
    }
}
