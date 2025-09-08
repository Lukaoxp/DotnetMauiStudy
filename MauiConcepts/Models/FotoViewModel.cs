using System.Collections.ObjectModel;

namespace MauiConcepts.Models
{
    public class FotoViewModel
    {
        public ObservableCollection<Foto> fotos { get; private set; }
        public ObservableCollection<Foto> Fotos
        {
            get { return fotos; }
            set { fotos = value; }
        }

        public FotoViewModel()
        {
            Fotos = [
                new() { Nome = "Andromeda", ImagemUrl = "galaxia1.jpg" },
                new() { Nome = "Via Láctea", ImagemUrl = "galaxia2.jpg" },
                new() { Nome = "Universo", ImagemUrl = "galaxia3.jpg" },
                new() { Nome = "Galáxia", ImagemUrl = "galaxia4.jpg" },
                new() { Nome = "Sombrero", ImagemUrl = "galaxia5.jpg" }
            ];
        }
    }
}
