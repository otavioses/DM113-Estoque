using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace EstoqueLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicoEstoque" in both code and config file together.
    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/01", Name = "IServicoEstoque")]

    public interface IServicoEstoque
    {
        // Get all products
        [OperationContract]
        List<String> ListarProdutos();
        [OperationContract]
        Boolean incluirProduto(Produto Produto);
        [OperationContract]
        Boolean RemoverProduto(String NumeroProduto);
        [OperationContract]
        int ConsultarEstoque(String NumeroProduto);
        [OperationContract]
        Boolean AdicionarEstoque(String NumeroProduto, int Quantidade);
        [OperationContract]
        Boolean RemoverEstoque(String NumeroProduto, int Quantidade);
        [OperationContract]
        Produto VerProduto(String NumeroProduto);
    }

    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/02", Name = "IServicoEstoque")]
    public interface IServicoEstoqueV2
    {
        [OperationContract]
        int ConsultarEstoque(String NumeroProduto);
        [OperationContract]
        Boolean AdicionarEstoque(String NumeroProduto, int Quantidade);
        [OperationContract]
        Boolean RemoverEstoque(String NumeroProduto, int Quantidade);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Produto
    {
        [DataMember]
        public string NumeroProduto;

        [DataMember]
        public string NomeProduto;

        [DataMember]
        public string DescricaoProduto;

        [DataMember]
        public int EstoqueProduto;
    }
}
