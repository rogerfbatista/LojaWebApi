using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Loja.DataUpdate.Models.Mapping;

namespace Loja.DataUpdate.Models
{
    public partial class LojaContext : DbContext
    {
        static LojaContext()
        {
            Database.SetInitializer<LojaContext>(null);
        }

        public LojaContext()
            : base("Name=LojaContext")
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ClienteContato> ClienteContatoes { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<EmpresaCliente> EmpresaClientes { get; set; }
        public DbSet<EmpresaContato> EmpresaContatoes { get; set; }
        public DbSet<EmpresaFornecedor> EmpresaFornecedors { get; set; }
        public DbSet<Fornecedor> Fornecedors { get; set; }
        public DbSet<FornecedorContato> FornecedorContatoes { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuTipo> MenuTipoes { get; set; }
        public DbSet<Produto> Produtoes { get; set; }
        public DbSet<ProdutoClienteSaida> ProdutoClienteSaidas { get; set; }
        public DbSet<ProdutoClienteSaidaItem> ProdutoClienteSaidaItems { get; set; }
        public DbSet<ProdutoEstoque> ProdutoEstoques { get; set; }
        public DbSet<ProdutoFormasDePagamento> ProdutoFormasDePagamentoes { get; set; }
        public DbSet<ProdutoFornecedorEntrada> ProdutoFornecedorEntradas { get; set; }
        public DbSet<ProdutoTipo> ProdutoTipoes { get; set; }
        public DbSet<Servico> Servicoes { get; set; }
        public DbSet<ServicoUsuarioPerfil> ServicoUsuarioPerfils { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioPerfil> UsuarioPerfils { get; set; }
        public DbSet<UsuarioPerfilMenu> UsuarioPerfilMenus { get; set; }

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
            modelBuilder.Configurations.Add(new ServicoMap());
            modelBuilder.Configurations.Add(new ServicoUsuarioPerfilMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new UsuarioPerfilMap());
            modelBuilder.Configurations.Add(new UsuarioPerfilMenuMap());
        }
    }
}
