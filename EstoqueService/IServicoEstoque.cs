using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Products
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicoEstoque" in both code and config file together.
    [ServiceContract]
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
