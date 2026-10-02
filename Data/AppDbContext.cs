using ControleTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleTarefas.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Tarefa> Tarefas => Set<Tarefa>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarefa>(entity =>
        {
            entity.ToTable("Tarefas");
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Titulo).IsRequired().HasMaxLength(100);
            entity.Property(t => t.Descricao).HasMaxLength(500);
            entity.Property(t => t.DataCriacao).IsRequired();
            entity.Property(t => t.DataVencimento).IsRequired();
            entity.Property(t => t.Concluida).IsRequired();
        });
    }
}
