using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using EstoqueClient1.EstoqueService;

namespace EstoqueClient1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press ENTER when the service has started");
            Console.ReadLine();
            ServicoEstoqueClient proxy = new ServicoEstoqueClient("BasicHttpBinding_IServicoEstoque");


            // 1) Adicionar um produto(por exemplo, Produto 11)
            Console.WriteLine("Test 1: Adicionar um produto");
            var produto = new Produto()
            {
                NumeroProduto = "11000",
                NomeProduto = "Produto 11",
                DescricaoProduto = "Este é o produto 11",
                EstoqueProduto = 20
            };
            var resultadoAdicionar = proxy.incluirProduto(produto);
            Console.WriteLine("{0} Adicionado? {1}", produto.NomeProduto, resultadoAdicionar);
            Console.WriteLine("\n---------------------\n");


            // 2) Remover o produto 10
            Console.WriteLine("Test 2: Remover o produto 10");
            var resultadoRemover = proxy.RemoverProduto("10000");
            Console.WriteLine("Removido? {0}", resultadoRemover);
            Console.WriteLine("\n---------------------\n");


            // 3) Listar todos os produtos
            Console.WriteLine("Test 3: Listar todos os produtos");
            var products = proxy.ListarProdutos().ToList();
            foreach (String p in products)
            {
                Console.WriteLine("Name: {0}", p);
            }
            Console.WriteLine("\n---------------------\n");

            // 4) Verificar todas as informações do Produto 2
            Console.WriteLine("Test 4: Verificar todas as informações do Produto 2");
            var produto2 = proxy.VerProduto("2000");
            Console.WriteLine("NumeroProduto: {0}", produto2.NumeroProduto);
            Console.WriteLine("NomeProduto: {0}", produto2.NomeProduto);
            Console.WriteLine("DescricaoProduto: {0}", produto2.DescricaoProduto);
            Console.WriteLine("EstoqueProduto: {0}", produto2.EstoqueProduto);
            Console.WriteLine("\n---------------------\n");

            // 5) Adicionar 10 unidades para este produto
            Console.WriteLine("Test 5: Adicionar 10 unidades para este produto");
            var resultadoAdicionarEstoque = proxy.AdicionarEstoque(produto2.NumeroProduto, 10);
            Console.WriteLine("Estoque adicinado? {0}", resultadoAdicionarEstoque);
            Console.WriteLine("\n---------------------\n");

            // 6) Verificar o estoque do Produto 2
            Console.WriteLine("Test 6: Verificar o estoque do Produto 2");
            var resultadoVerificarProduto2 = proxy.ConsultarEstoque(produto2.NumeroProduto);
            Console.WriteLine("Estoque Produto 2: {0}", resultadoVerificarProduto2);
            Console.WriteLine("\n---------------------\n");

            // 7) Verificar o estoque atual do Produto 1
            Console.WriteLine("Test 7: Verificar o estoque atual do Produto 1");
            var resultadoVerificarProduto1 = proxy.ConsultarEstoque("1000");
            Console.WriteLine("Estoque Produto 1: {0}", resultadoVerificarProduto1);
            Console.WriteLine("\n---------------------\n");

            //8) Remover 20 unidades para este produto
            Console.WriteLine("Test 8: Remover 20 unidades para este produto");
            var resultadoRemoverEstoque = proxy.RemoverEstoque("1000", 20);
            Console.WriteLine("Estoque Removido? {0}", resultadoRemoverEstoque);
            Console.WriteLine("\n---------------------\n");

            // 7) Verificar o estoque atual do Produto 1
            Console.WriteLine("Test 9: Verificar o estoque do Produto 1 novamente");
            resultadoVerificarProduto1 = proxy.ConsultarEstoque("1000");
            Console.WriteLine("Estoque Produto 1: {0}", resultadoVerificarProduto1);
            Console.WriteLine("\n---------------------\n");

            Console.WriteLine("Test 10: Verificar todas as informações do Produto 1");
            var produto1 = proxy.VerProduto("1000");
            Console.WriteLine("NumeroProduto: {0}", produto1.NumeroProduto);
            Console.WriteLine("NomeProduto: {0}", produto1.NomeProduto);
            Console.WriteLine("DescricaoProduto: {0}", produto1.DescricaoProduto);
            Console.WriteLine("EstoqueProduto: {0}", produto1.EstoqueProduto);
            Console.WriteLine("\n---------------------\n");
        }
    }
}
