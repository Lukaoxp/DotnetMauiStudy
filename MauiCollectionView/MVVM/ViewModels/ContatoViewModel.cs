using MauiCollectionView.MVVM.Models;
using System.Collections.ObjectModel;

namespace MauiCollectionView.MVVM.ViewModels
{
    public class ContatoViewModel
    {
        public ObservableCollection<ContatoGroup> ContatosAgrupados { get; set; } = new();

        public ContatoViewModel()
        {
            var contatos = CriarContatos();

            //var gruposContato = from c in contatos
            //                    orderby c.Nome
            //                    group c by c.Nome[0].ToString()
            //                                            into grupos
            //                    select new ContatoGroup(grupos.Key, grupos.ToList());

            var gruposContato = contatos
                                                    .OrderBy(c => c.Nome)
                                                    .GroupBy(c => c.Nome[0].ToString())
                                                    .Select(grupos => new ContatoGroup(grupos.Key, grupos.ToList()));

            ContatosAgrupados = new ObservableCollection<ContatoGroup>(gruposContato.ToList());

            int id = 0;
            foreach (var grupo in gruposContato)
            {
                foreach (var contato in grupo)
                {
                    contato.Id = id;
                    id++;
                }
            }
        }

        private List<Contato> CriarContatos()
        {
            return new List<Contato>()
            {
                new Contato { Nome = "João Silva", Email = "joao.silva@email.com", Telefone = "(11) 98765-4321" },
                new Contato { Nome = "Maria Santos", Email = "maria.santos@email.com", Telefone = "(21) 97654-3210" },
                new Contato { Nome = "Pedro Oliveira", Email = "pedro.oliveira@email.com", Telefone = "(31) 96543-2109" },
                new Contato { Nome = "Ana Costa", Email = "ana.costa@email.com", Telefone = "(41) 95432-1098" },
                new Contato { Nome = "Carlos Souza", Email = "carlos.souza@email.com", Telefone = "(51) 94321-0987" },
                new Contato { Nome = "Bruno Lima", Email = "bruno.lima@email.com", Telefone = "(61) 93210-8765" },
                new Contato { Nome = "Fernanda Rocha", Email = "fernanda.rocha@email.com", Telefone = "(71) 92109-7654" },
                new Contato { Nome = "Lucas Martins", Email = "lucas.martins@email.com", Telefone = "(81) 91098-6543" },
                new Contato { Nome = "Patrícia Almeida", Email = "patricia.almeida@email.com", Telefone = "(91) 90987-5432" },
                new Contato { Nome = "Ricardo Pinto", Email = "ricardo.pinto@email.com", Telefone = "(12) 99876-4321" },
                new Contato { Nome = "Juliana Ramos", Email = "juliana.ramos@email.com", Telefone = "(22) 98765-3210" },
                new Contato { Nome = "Gabriel Fernandes", Email = "gabriel.fernandes@email.com", Telefone = "(32) 97654-2109" },
                new Contato { Nome = "Camila Barros", Email = "camila.barros@email.com", Telefone = "(42) 96543-1098" },
                new Contato { Nome = "Eduardo Teixeira", Email = "eduardo.teixeira@email.com", Telefone = "(52) 95432-0987" },
                new Contato { Nome = "Aline Carvalho", Email = "aline.carvalho@email.com", Telefone = "(62) 94321-9876" },
                new Contato { Nome = "Vinícius Gomes", Email = "vinicius.gomes@email.com", Telefone = "(72) 93210-8765" },
                new Contato { Nome = "Larissa Melo", Email = "larissa.melo@email.com", Telefone = "(82) 92109-7654" },
                new Contato { Nome = "Felipe Araújo", Email = "felipe.araujo@email.com", Telefone = "(92) 91098-6543" },
                new Contato { Nome = "Renata Figueiredo", Email = "renata.figueiredo@email.com", Telefone = "(13) 90987-5432" },
                new Contato { Nome = "Thiago Batista", Email = "thiago.batista@email.com", Telefone = "(23) 99876-4321" },
                new Contato { Nome = "Beatriz Nunes", Email = "beatriz.nunes@email.com", Telefone = "(33) 98765-3210" },
                new Contato { Nome = "André Cardoso", Email = "andre.cardoso@email.com", Telefone = "(43) 97654-2109" },
                new Contato { Nome = "Sabrina Pires", Email = "sabrina.pires@email.com", Telefone = "(53) 96543-1098" },
                new Contato { Nome = "Marcelo Dias", Email = "marcelo.dias@email.com", Telefone = "(63) 95432-0987" },
                new Contato { Nome = "Tatiane Moreira", Email = "tatiane.moreira@email.com", Telefone = "(73) 94321-9876" },
                new Contato { Nome = "Rafael Castro", Email = "rafael.castro@email.com", Telefone = "(83) 93210-8765" },
                new Contato { Nome = "Débora Freitas", Email = "debora.freitas@email.com", Telefone = "(93) 92109-7654" },
                new Contato { Nome = "Murilo Rezende", Email = "murilo.rezende@email.com", Telefone = "(14) 91098-6543" },
                new Contato { Nome = "Priscila Tavares", Email = "priscila.tavares@email.com", Telefone = "(24) 90987-5432" },
                new Contato { Nome = "Leandro Guimarães", Email = "leandro.guimaraes@email.com", Telefone = "(34) 99876-4321" },
                new Contato { Nome = "Simone Lopes", Email = "simone.lopes@email.com", Telefone = "(44) 98765-3210" },
                new Contato { Nome = "Otávio Cunha", Email = "otavio.cunha@email.com", Telefone = "(54) 97654-2109" },
                new Contato { Nome = "Isabela Ribeiro", Email = "isabela.ribeiro@email.com", Telefone = "(64) 96543-1098" },
                new Contato { Nome = "Fábio Peixoto", Email = "fabio.peixoto@email.com", Telefone = "(74) 95432-0987" },
                new Contato { Nome = "Natália Monteiro", Email = "natalia.monteiro@email.com", Telefone = "(84) 94321-9876" },
                new Contato { Nome = "Gustavo Vieira", Email = "gustavo.vieira@email.com", Telefone = "(94) 93210-8765" },
                new Contato { Nome = "Amanda Correia", Email = "amanda.correia@email.com", Telefone = "(15) 92109-7654" },
                new Contato { Nome = "Rodrigo Braga", Email = "rodrigo.braga@email.com", Telefone = "(25) 91098-6543" },
                new Contato { Nome = "Letícia Duarte", Email = "leticia.duarte@email.com", Telefone = "(35) 90987-5432" },
                new Contato { Nome = "Henrique Assis", Email = "henrique.assis@email.com", Telefone = "(45) 99876-4321" },
                new Contato { Nome = "Viviane Silveira", Email = "viviane.silveira@email.com", Telefone = "(55) 98765-3210" },
                new Contato { Nome = "César Macedo", Email = "cesar.macedo@email.com", Telefone = "(65) 97654-2109" },
                new Contato { Nome = "Elaine Sales", Email = "elaine.sales@email.com", Telefone = "(75) 96543-1098" },
                new Contato { Nome = "Danilo Borges", Email = "danilo.borges@email.com", Telefone = "(85) 95432-0987" },
                new Contato { Nome = "Mônica Leite", Email = "monica.leite@email.com", Telefone = "(95) 94321-9876" },
                new Contato { Nome = "Alexandre Prado", Email = "alexandre.prado@email.com", Telefone = "(16) 93210-8765" },
                new Contato { Nome = "Paula Siqueira", Email = "paula.siqueira@email.com", Telefone = "(26) 92109-7654" },
                new Contato { Nome = "Sandro Queiroz", Email = "sandro.queiroz@email.com", Telefone = "(36) 91098-6543" },
                new Contato { Nome = "Cristina Matos", Email = "cristina.matos@email.com", Telefone = "(46) 90987-5432" },
                new Contato { Nome = "Vitor Barreto", Email = "vitor.barreto@email.com", Telefone = "(56) 99876-4321" }
            };
        }
    }
}
