using GerenciarTarefas.Application.DTOs;
using GerenciarTarefas.Application.Interfaces;
using GerenciarTarefas.Domain.Entities;
using GerenciarTarefas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciarTarefas.Application.UseCases;

public class GetTarefaByIdUseCase : IGetTarefaByIdUseCase
{
    private readonly ITarefaRepository _repository;

    public GetTarefaByIdUseCase(ITarefaRepository repository)
    {
        _repository = repository;
    }

    public async Task<TarefaResponseDto> ExecuteAsync(int id)
    {
        var tarefa = await _repository.ObterPorIdAsync(id);

        if (tarefa is null)
            throw new KeyNotFoundException($"Tarefa com Id {id} não encontrada");

        return MapToResponseDto(tarefa);
    }

    private TarefaResponseDto MapToResponseDto(Tarefa tarefa)
    {
        return new TarefaResponseDto
        {
            Id = tarefa.Id,
            Titulo = tarefa.Titulo,
            Descricao = tarefa.Descricao,
            DataCriacao = tarefa.DataCriacao,
            DataConclusao = tarefa.DataConclusao,
            Status = tarefa.Status
        };
    }
}