using AppLanches.Models;
using SQLite;

namespace AppLanches.Services
{
    public class FavoritosService
    {
        private readonly SQLiteAsyncConnection _connection;

        public FavoritosService()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "favoritos.db");
            _connection = new SQLiteAsyncConnection(dbPath);
            _connection.CreateTableAsync<ProdutoFavorito>().Wait();
        }

        public async Task<ProdutoFavorito> ReadAsync(int id)
        {
            return await _connection.Table<ProdutoFavorito>().Where(p => p.ProdutoId == id).FirstOrDefaultAsync();
        }

        public async Task<List<ProdutoFavorito>> ReadAllAsync()
        {
            return await _connection.Table<ProdutoFavorito>().ToListAsync();
        }

        public async Task CreateAsync(ProdutoFavorito produtoFavorito)
        {
            await _connection.InsertAsync(produtoFavorito);
        }

        public async Task DeleteAsync(ProdutoFavorito produtoFavorito)
        {
            await _connection.DeleteAsync(produtoFavorito);
        }
    }
}
