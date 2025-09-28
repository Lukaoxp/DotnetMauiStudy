using Converters.Entities;
using System.Collections.ObjectModel;

namespace Converters.Services
{
    public interface IAlunoService
    {
        ObservableCollection<Aluno> GetAlunos();
    }
}
