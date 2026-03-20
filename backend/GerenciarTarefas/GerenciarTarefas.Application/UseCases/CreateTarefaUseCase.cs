using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciarTarefas.Application.DTOs;
using GerenciarTarefas.Domain.Entities;
using GerenciarTarefas.Domain.Interfaces;

namespace GerenciarTarefas.Application.UseCases;

public class CreateTarefaUseCase
{
    private readonly ITarefaRepository _repository;

    public CreateTarefaUseCase(ITarefaRepository repository)
    {
        _repository = repository;
    }

    public async Task<TarefaResponseDto> ExecuteAsync(CreateTarefaDto dto)
    {
        var tarefa = new Tarefa(dto.Titulo, dto.Descricao);

        await _repository.CriarAsync(tarefa);

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
