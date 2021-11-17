using EstoqueClient2.EstoqueService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueClient2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press ENTER when the service has started");
            Console.ReadLine();
            ServicoEstoqueClient proxy = new ServicoEstoqueClient("WS2007HttpBinding_IServicoEstoque");

            // 1) Verificar o estoque atual do Produto 1
            Console.WriteLine("Test 1: Verificar o estoque atual do Produto 1");
            var resultadoVerificarProduto1 = proxy.ConsultarEstoque("1000");
            Console.WriteLine("Estoque Produto 1: {0}", resultadoVerificarProduto1);
            Console.WriteLine("\n---------------------\n");

            // 2) Remover 20 unidades para este produto
            Console.WriteLine("Test 2: Adicionar 20 unidades para este produto");
            var resultadoAdicionarEstoque = proxy.AdicionarEstoque("1000", 20);
            Console.WriteLine("Estoque Adicionado? {0}", resultadoAdicionarEstoque);
            Console.WriteLine("\n---------------------\n");

            // 3) Verificar o estoque do Produto 1 novamente
            Console.WriteLine("Test 3: Verificar o estoque do Produto 1 novamente");
            resultadoVerificarProduto1 = proxy.ConsultarEstoque("1000");
            Console.WriteLine("Estoque Produto 1: {0}", resultadoVerificarProduto1);
            Console.WriteLine("\n---------------------\n");


            // 4) Verificar o estoque atual do Produto 5
            Console.WriteLine("Test 4: Verificar o estoque atual do Produto 5");
            var resultadoVerificarProduto5 = proxy.ConsultarEstoque("5000");
            Console.WriteLine("Estoque Produto 5: {0}", resultadoVerificarProduto5);
            Console.WriteLine("\n---------------------\n");

            //5) Remover 10 unidades para este produto
            Console.WriteLine("Test 5: Remover 10 unidades para este produto");
            var resultadoRemoverEstoque = proxy.RemoverEstoque("5000", 10);
            Console.WriteLine("Estoque Removido? {0}", resultadoRemoverEstoque);
            Console.WriteLine("\n---------------------\n");

            // 6) Verificar o estoque do Produto 5 novamente
            Console.WriteLine("Test 4: Verificar o estoque atual do Produto 5");
            resultadoVerificarProduto5 = proxy.ConsultarEstoque("5000");
            Console.WriteLine("Estoque Produto 5: {0}", resultadoVerificarProduto5);
            Console.WriteLine("\n---------------------\n");

        }
    }
}
