using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciarTarefas.Domain.Entities;
using GerenciarTarefas.Domain.Interfaces;
using GerenciarTarefas.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GerenciarTarefas.Infrastructure.Repositories;

public class TarefaRepository : ITarefaRepository
{
    private readonly TarefaContext _context;

    public TarefaRepository(TarefaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tarefa>> ObterTodosAsync()
    {
        return await _context.Tarefas.ToListAsync();
    }

    public async Task<Tarefa?> ObterPorIdAsync(int id)
    {
        return await _context.Tarefas.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task CriarAsync(Tarefa tarefa)
    {
        await _context.Tarefas.AddAsync(tarefa);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Tarefa tarefa)
    {
        _context.Tarefas.Update(tarefa);
        await _context.SaveChangesAsync();
    }

    public async Task DeletarAsync(int id)
    {
        var tarefa = await ObterPorIdAsync(id);
        _context.Tarefas.Remove(tarefa!);
        await _context.SaveChangesAsync();
    }
}
