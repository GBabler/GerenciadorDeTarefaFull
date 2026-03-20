using GerenciarTarefas.Application.DTOs;
using GerenciarTarefas.Application.Interfaces;
using GerenciarTarefas.Domain.Interfaces;

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
        ValidarDto(dto); // ← adiciona aqui

        var tarefa = await _repository.ObterPorIdAsync(id);

        if (tarefa is null)
            throw new KeyNotFoundException($"Tarefa com Id {id} não encontrada");

        tarefa.AtualizarDados(dto.Titulo, dto.Descricao);
        tarefa.AtualizarStatus(dto.Status);

        await _repository.AtualizarAsync(tarefa);
    }

    private void ValidarDto(UpdateTarefaDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Titulo))
            throw new ArgumentException("Título é obrigatório");

        if (dto.Titulo.Length > 100)
            throw new ArgumentException("Título deve ter no máximo 100 caracteres");

        if (dto.Descricao?.Length > 500)
            throw new ArgumentException("Descrição deve ter no máximo 500 caracteres");
    }
}