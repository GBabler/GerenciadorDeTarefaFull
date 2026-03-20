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

public class GetAllTarefasUseCase : IGetAllTarefasUseCase
{
    private readonly ITarefaRepository _repository;

    public GetAllTarefasUseCase(ITarefaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TarefaResponseDto>> ExecuteAsync()
    {
        var tarefas = await _repository.ObterTodosAsync();

        return tarefas.Select(tarefa => MapToResponseDto(tarefa));
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
