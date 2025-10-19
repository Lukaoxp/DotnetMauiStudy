namespace MauiCollectionView.MVVM.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }

    public class ContatoGroup : List<Contato>
    {
        public string Nome { get; private set; }
        public ContatoGroup(string nome, List<Contato> contatos) : base(contatos)
        {
            Nome = nome;
        }
    }
}
