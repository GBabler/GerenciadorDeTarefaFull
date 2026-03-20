using GerenciarTarefas.Application.DTOs;
using GerenciarTarefas.Application.Interfaces;
using GerenciarTarefas.Domain.Entities;
using GerenciarTarefas.Domain.Interfaces;

namespace GerenciarTarefas.Application.UseCases;

public class CreateTarefaUseCase : ICreateTarefaUseCase
{
    private readonly ITarefaRepository _repository;

    public CreateTarefaUseCase(ITarefaRepository repository)
    {
        _repository = repository;
    }

    public async Task<TarefaResponseDto> ExecuteAsync(CreateTarefaDto dto)
    {
        ValidarDto(dto); // ← adiciona aqui

        var tarefa = new Tarefa(dto.Titulo, dto.Descricao);
        await _repository.CriarAsync(tarefa);
        return MapToResponseDto(tarefa);
    }

    private void ValidarDto(CreateTarefaDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Titulo))
            throw new ArgumentException("Título é obrigatório");

        if (dto.Titulo.Length > 100)
            throw new ArgumentException("Título deve ter no máximo 100 caracteres");

        if (dto.Descricao?.Length > 500)
            throw new ArgumentException("Descrição deve ter no máximo 500 caracteres");
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