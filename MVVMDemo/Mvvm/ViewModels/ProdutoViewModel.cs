using MVVM_Demo.Mvvm.Models;

namespace MVVM_Demo.Mvvm.ViewModels
{
    public class ProdutoViewModel
    {
        public Produto Produto { get; set; }

        public ProdutoViewModel()
        {
            Produto = new()
            {
                Nome = "Produto Exemplo",
                Preco = 19.99m,
                Estoque = 33,
                Ativo = true,
                DataCompra = DateTime.Now,
                Peso = 1.5d
            };
        }
    }
}
