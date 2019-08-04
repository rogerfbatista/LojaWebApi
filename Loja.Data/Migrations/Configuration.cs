using System;
using System.Data.Entity.Migrations;
using Loja.Common;
using Loja.Data.Contexto;
using Loja.Domain.Entities;

namespace Loja.Data.Migrations
{


    internal sealed class Configuration : DbMigrationsConfiguration<LojaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LojaContext context)
        {
            // This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //to avoid creating duplicate seed data. E.g.



            //context.MenuTipoes.AddOrUpdate(
            //    new MenuTipo[]
            //       {
            //           new MenuTipo("Menu"), 
            //           new MenuTipo("SubMenu" ), 
            //       });

            //context.ProdutoFormasDePagamentoes.AddOrUpdate(new ProdutoFormasDePagamento[]
            // {
            //     new ProdutoFormasDePagamento("Boleto"),
            //     new ProdutoFormasDePagamento("Cartão de Credito"), 
            //     new ProdutoFormasDePagamento("Debito Automatico"), 
            //     new ProdutoFormasDePagamento("Dinheiro")
            // });


            //context.Empresas.AddOrUpdate(new Empresa("Loja Teste", "Loja Cosmolop", "Rogerio Batista", "834.290.453.517",
            //    "735.507.550-07", "Rua Cavalo Marinho", "1455", "SP", "São Paulo", DateTime.Now,
            //    Util<Empresa>.CopyImageToByteArray(System.Drawing.Image.FromFile(@"C:\Users\Bianca\Downloads\minhaloja.png")),
            //       true, 0, new Collection<EmpresaContato>()
            //       {
            //           new EmpresaContato("rogerfbatista@gmail.com","391875545")
                   
            //       }));

           // context.UsuarioPerfils.AddOrUpdate(new UsuarioPerfil("AdministradorSistema",
           //  Util<UsuarioPerfil>.CopyImageToByteArray(System.Drawing.Image.FromFile(@"C:\Users\Bianca\Downloads\administrador.png"))));

            var user = new Usuario(1, 2, "Rogerio Ferreira Batista", "rogerfbatista@gmail.com", DateTime.Now,
              Util<Usuario>.CopyImageToByteArray(System.Drawing.Image.FromFile(@"C:\Users\Bianca\Downloads\Rogerio.jpg")));
            user.SetSenha("bianca", "bianca");
            context.Usuarios.AddOrUpdate(user);

            //context.Servico.AddOrUpdate(new Servico("Cliente", true, 0));
            //context.Servico.AddOrUpdate(new Servico("ClienteContato", true, 0));
            //context.Servico.AddOrUpdate(new Servico("Empresa", true, 0));
            //context.Servico.AddOrUpdate(new Servico("EmpresaCliente", true, 0));
            //context.Servico.AddOrUpdate(new Servico("EmpresaContato", true, 0));
            //context.Servico.AddOrUpdate(new Servico("EmpresaFornecedor", true, 0));
            //context.Servico.AddOrUpdate(new Servico("Fornecedor", true, 0));
            //context.Servico.AddOrUpdate(new Servico("FornecedorContato", true, 0));
            //context.Servico.AddOrUpdate(new Servico("Menu", true, 0));
            //context.Servico.AddOrUpdate(new Servico("MenuTipo", true, 0));
            //context.Servico.AddOrUpdate(new Servico("Produto", true, 0));
            //context.Servico.AddOrUpdate(new Servico("ProdutoClienteSaida", true, 0));
            //context.Servico.AddOrUpdate(new Servico("ProdutoEstoque", true, 0));
            //context.Servico.AddOrUpdate(new Servico("ProdutoFormasDePagamento", true, 0));
            //context.Servico.AddOrUpdate(new Servico("ProdutoFornecedorEntrada", true, 0));
            //context.Servico.AddOrUpdate(new Servico("ProdutoTipo", true, 0));
            //context.Servico.AddOrUpdate(new Servico("Servico", true, 0));
            //context.Servico.AddOrUpdate(new Servico("ServicoUsuarioPerfil", true, 0));
            //context.Servico.AddOrUpdate(new Servico("Usuario", true, 0));
            //context.Servico.AddOrUpdate(new Servico("UsuarioPerfil", true, 0));
            //context.Servico.AddOrUpdate(new Servico("UsuarioPerfilMenu", true, 0));


            context.SaveChanges();



        }
    }
}
