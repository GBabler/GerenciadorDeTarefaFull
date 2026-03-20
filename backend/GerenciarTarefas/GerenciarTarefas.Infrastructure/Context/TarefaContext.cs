using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciarTarefas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciarTarefas.Infrastructure.Context;

public class TarefaContext : DbContext
{
    public TarefaContext(DbContextOptions<TarefaContext> options) : base(options)
    {
    }

    public DbSet<Tarefa> Tarefas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarefa>(entity =>
        {
            entity.HasKey(t => t.Id);

            entity.Property(t => t.Titulo)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(t => t.Descricao)
                .HasMaxLength(500);

            entity.Property(t => t.Status)
                .IsRequired();

            entity.Property(t => t.DataCriacao)
                .IsRequired();
        });
    }
}
