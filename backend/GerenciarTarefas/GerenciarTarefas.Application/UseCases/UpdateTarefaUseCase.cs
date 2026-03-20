using GerenciarTarefas.Application.DTOs;
using GerenciarTarefas.Application.Interfaces;
using GerenciarTarefas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciarTarefas.Application.UseCases;

public class UpdateTarefaUseCase : IUpdateTarefaUseCase
{
    private readonly ITarefaRepository _repository;

    public UpdateTarefaUseCase(ITarefaRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id, UpdateTarefaDto dto)
    {
        var tarefa = await _repository.ObterPorIdAsync(id);

        if (tarefa is null)
            throw new KeyNotFoundException($"Tarefa com Id {id} não encontrada");

        tarefa.AtualizarDados(dto.Titulo, dto.Descricao);
        tarefa.AtualizarStatus(dto.Status);

        await _repository.AtualizarAsync(tarefa);
    }
}
