using EstoqueEntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel.Activation;

namespace Products
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements( RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServicoEstoque : IServicoEstoque
    {
        public bool AdicionarEstoque(string NumeroProduto, int Quantidade)
        {
            try
            {
                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Find the first product that matches the specified product code
                    ProdutoEstoque produtoEstoque = database.ProdutosEstoque.First(
                     p => String.Compare(p.NumeroProduto, NumeroProduto) == 0);

                    produtoEstoque.EstoqueProduto += Quantidade;

                    database.Entry(produtoEstoque).State = EntityState.Modified;
                    // Save the change back to the database
                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public int ConsultarEstoque(string NumeroProduto)
        {
            try
            {

                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Find the first product that matches the specified product code
                    ProdutoEstoque produtoEstoque = database.ProdutosEstoque.First(
                     p => String.Compare(p.NumeroProduto, NumeroProduto) == 0);
                    return produtoEstoque.EstoqueProduto;
                }
            }
            catch
            {
                return 0;
            }
        }

        public bool incluirProduto(Produto Produto)
        {
            try
            {
                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoque = new ProdutoEstoque()
                    {
                        NumeroProduto = Produto.NumeroProduto,
                        NomeProduto = Produto.NomeProduto,
                        DescricaoProduto = Produto.DescricaoProduto,
                        EstoqueProduto = Produto.EstoqueProduto
                    };
                    database.ProdutosEstoque.Add(produtoEstoque);

                    // Save the change back to the database
                    database.SaveChanges();
                }
            }
            catch
            {
                // If an exception occurs, return false to indicate failure
                return false;
            }
            // Return true to indicate success
            return true;
        }

        public List<string> ListarProdutos() 
        { 
            // Create a list of products
            List<String> productsList = new List<String>();
            try
            {
                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Fetch the products in the database
                    List<ProdutoEstoque> products = (from product in database.ProdutosEstoque
                                                     select product).ToList();
                    foreach (ProdutoEstoque product in products)
                    {
                        productsList.Add(product.NomeProduto);
                    }
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }
            // Return the list of products
            return productsList;
        }

        public bool RemoverEstoque(string NumeroProduto, int Quantidade)
        {
            try
            {
                // Connect to the ProvedorEstoque database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Find the first product that matches the specified product code
                    ProdutoEstoque produtoEstoque = database.ProdutosEstoque.First(
                     p => String.Compare(p.NumeroProduto, NumeroProduto) == 0);

                    produtoEstoque.EstoqueProduto -= Quantidade;

                    database.Entry(produtoEstoque).State = EntityState.Modified;
                    // Save the change back to the database
                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool RemoverProduto(string NumeroProduto)
        {
            try
            {

                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Find the first product that matches the specified product code
                    ProdutoEstoque produtoEstoque = database.ProdutosEstoque.First(
                     p => String.Compare(p.NumeroProduto, NumeroProduto) == 0);

                    //database.Entry(produtoEstoque).State = EntityState.Modified;
                    database.ProdutosEstoque.Remove(produtoEstoque);
                    // Save the change back to the database
                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public Produto VerProduto(string NumeroProduto)
        {
            try
            {
                // Connect to the ProvedorEstoque database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Find the first product that matches the specified product code
                    ProdutoEstoque produtoEstoque = database.ProdutosEstoque.First(
                     p => String.Compare(p.NumeroProduto, NumeroProduto) == 0);

                    Produto produto = new Produto()
                    {
                        NumeroProduto = produtoEstoque.NumeroProduto,
                        NomeProduto = produtoEstoque.NomeProduto,
                        DescricaoProduto = produtoEstoque.DescricaoProduto,
                        EstoqueProduto = produtoEstoque.EstoqueProduto
                    };

                    return produto;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
