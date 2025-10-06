using MauiCollectionView.MVVM.Models;

namespace MauiCollectionView.Selectors
{
    public class ProdutoDataTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var produto = item as Produto;
            if (!produto.EmOferta)
            {
                Application.Current.Resources.TryGetValue("ProdutosStyle", out var produtoStyle);
                return produtoStyle as DataTemplate;
            }
            else
            {
                Application.Current.Resources.TryGetValue("EmOfertaStyle", out var emOfertaStyle);
                return emOfertaStyle as DataTemplate;
            }
        }
    }
}
