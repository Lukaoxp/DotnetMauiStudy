﻿namespace AppLanches.Models
{
    public class PedidoDetalhe
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public decimal Subtotal { get; set; }
        public string? ProdutoNome { get; set; }
        public string? ProdutoImagem { get; set; }
        public decimal ProdutoPreco { get; set; }
        public string CaminhoImagem => AppConfig.BaseUrl + ProdutoImagem;
    }
}
