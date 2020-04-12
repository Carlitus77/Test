using Microsoft.EntityFrameworkCore;

namespace SQLiteTest
{
    public class SQLiteDBContext : DbContext
    {
        public DbSet<Equipment> Equipment { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=sqliteTest.db");
    }
}
