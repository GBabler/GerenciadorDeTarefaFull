using GerenciarTarefas.Application.Interfaces;
using GerenciarTarefas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciarTarefas.Application.UseCases;

public class DeleteTarefaUseCase : IDeleteTarefaUseCase
{
    private readonly ITarefaRepository _repository;

    public DeleteTarefaUseCase(ITarefaRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var tarefa = await _repository.ObterPorIdAsync(id);

        if (tarefa is null)
            throw new KeyNotFoundException($"Tarefa com Id {id} não encontrada");

        await _repository.DeletarAsync(id);
    }
}