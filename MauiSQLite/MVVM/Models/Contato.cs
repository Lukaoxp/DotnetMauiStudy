using SQLite;

namespace MauiSQLite.MVVM.Models
{
    [Table("Contatos")]
    public class Contato
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100), NotNull]
        public string Nome { get; set; }
        [MaxLength(200), Unique, NotNull]
        public string Email { get; set; }
    }
}
