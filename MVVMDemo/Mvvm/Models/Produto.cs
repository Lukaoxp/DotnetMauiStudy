namespace MVVM_Demo.Mvvm.Models
{
    public class Produto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; } = 0;
        public bool Ativo { get; set; }
        public DateTime DataCompra { get; set; }
        public double Peso { get; set; }
    }
}
