using Microsoft.EntityFrameworkCore;
using StudentDatabase.Models;

namespace StudentDatabase.Data;

public class StudentContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Файл базы данных будет создан в папке приложения
        optionsBuilder.UseSqlite("Data Source=students.db");
    }
}