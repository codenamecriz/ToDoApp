using System.Data.SQLite;

namespace TodoAppMVVM.SQLite
{
    public interface IBuildConnection
    {
        SQLiteConnection DbConnection();
    }
}