using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciarTarefas.Domain.Entities;

namespace GerenciarTarefas.Domain.Interfaces;

public interface ITarefaRepository
{
    Task<IEnumerable<Tarefa>> ObterTodosAsync();
    Task<Tarefa?> ObterPorIdAsync(int id);
    Task CriarAsync(Tarefa tarefa);
    Task AtualizarAsync(Tarefa tarefa);
    Task DeletarAsync(int id);
}
