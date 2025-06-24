using MVVM_Demo.Mvvm.Models;

namespace MVVM_Demo.Mvvm.ViewModels
{
    public class TimesViewModel
    {
        public List<Time> Times { get; set; } = [];
        public TimesViewModel()
        {
            Times = [
                new (){Nome = "Real Madrid", Escudo = "real.png"},
                new (){Nome = "Manchester City", Escudo = "man_city.png"},
                new (){Nome = "Milan", Escudo = "milan.png"},
                new (){Nome = "Napoli", Escudo = "napoli.png"},
                new (){Nome = "Chelsea", Escudo = "chelsea.png"},
                new (){Nome = "Bayern de Munique", Escudo = "bayern.png"},
                new (){Nome = "Benfica", Escudo = "benfica.png"},
                new (){Nome = "Paris Saint-Germain", Escudo = "psg.png"},
                new (){Nome = "Barcelona", Escudo = "barca.png"}
                ];
        }
    }
}
