using Converters.Services;

namespace Converters.Views;

public partial class NotasAlunosView : ContentPage
{
    private readonly IAlunoService _alunoService;

    public NotasAlunosView()
    {
    }

    public NotasAlunosView(IAlunoService alunoService)
    {
        InitializeComponent();
        _alunoService = alunoService;
        listAlunos.ItemsSource = _alunoService.GetAlunos();
    }
}