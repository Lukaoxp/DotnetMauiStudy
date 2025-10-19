using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApiRest.Models;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json;

namespace MauiApiRest.ViewModels
{
    public partial class CategoriaViewModel : ObservableObject
    {
        HttpClient client;
        JsonSerializerOptions _serializerOptions;
        string baseUrl = "https://catalogo.macoratti.net/api/1";

        [ObservableProperty]
        public string _categoriaInfoId;

        [ObservableProperty]
        public string _categoriaInfoNome;

        [ObservableProperty]
        public Categoria _categoria;

        [ObservableProperty]
        public ObservableCollection<Categoria> _categorias;

        [ObservableProperty]
        private string _nome;

        [ObservableProperty]
        private string _imagemUrl;

        public CategoriaViewModel()
        {
            client = new HttpClient();
            Categorias = [];
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }
        [RelayCommand]
        private async Task GetCategorias()
        {
            var url = $"{baseUrl}/categorias";
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer.DeserializeAsync<ObservableCollection<Categoria>>(responseStream, _serializerOptions);
                    Categorias = data;
                }
            }
        }

        [RelayCommand]
        private async Task GetCategoria()
        {
            if (CategoriaInfoId is not null)
            {
                var categoriaId = Convert.ToInt32(CategoriaInfoId);
                if (categoriaId > 0)
                {
                    var url = $"{baseUrl}/categorias/{categoriaId}";

                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        using (var responseStream = await response.Content.ReadAsStreamAsync())
                        {
                            var data = await JsonSerializer.DeserializeAsync<Categoria>(responseStream, _serializerOptions);
                            Categoria = data;
                        }
                    }
                }
            }
        }

        [RelayCommand]
        private async Task AddCategoria()
        {
            if (CategoriaInfoNome is not null)
            {
                var url = $"{baseUrl}/categorias";

                Categoria novacategoria = new()
                {
                    Nome = CategoriaInfoNome,
                    ImagemUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRLp5NI7Oq5ew_4pI5Q-YkGR4KLx01LZ8trCASP_-dMd7WAD3s603iU5XkyqV9hA0oJVm8&usqp=CAU"
                };

                string json = JsonSerializer.Serialize<Categoria>(novacategoria, _serializerOptions);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);

                await GetCategorias();
            }
        }

        [RelayCommand]
        private async Task UpdateCategoria()
        {
            if (CategoriaInfoNome is not null && CategoriaInfoId is not null)
            {
                var categoriaId = Convert.ToInt32(CategoriaInfoId);

                var categoriaAtualizar = Categorias.FirstOrDefault(x => x.CategoriaId == categoriaId);
                var url = $"{baseUrl}/categorias/{categoriaId}";

                categoriaAtualizar.Nome = CategoriaInfoNome;

                string json = JsonSerializer.Serialize<Categoria>(categoriaAtualizar, _serializerOptions);

                StringContent content = new(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(url, content);

                await GetCategorias();
            }
        }

        [RelayCommand]
        private async Task DeleteCategoria()
        {
            if (CategoriaInfoId is not null)
            {
                var categoriaId = Convert.ToInt32(CategoriaInfoId);
                if (categoriaId > 0)
                {
                    var url = $"{baseUrl}/categorias/{categoriaId}";
                    var response = await client.DeleteAsync(url);
                    await GetCategorias();
                }
            }
        }
    }
}
