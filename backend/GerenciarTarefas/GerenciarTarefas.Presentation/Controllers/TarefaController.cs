using GerenciarTarefas.Application.DTOs;
using GerenciarTarefas.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciarTarefas.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TarefaController : ControllerBase
{
    private readonly ICreateTarefaUseCase _createTarefaUseCase;
    private readonly IGetAllTarefasUseCase _getAllTarefasUseCase;
    private readonly IGetTarefaByIdUseCase _getTarefaByIdUseCase;
    private readonly IUpdateTarefaUseCase _updateTarefaUseCase;
    private readonly IDeleteTarefaUseCase _deleteTarefaUseCase;

    public TarefaController(
        ICreateTarefaUseCase createTarefaUseCase,
        IGetAllTarefasUseCase getAllTarefasUseCase,
        IGetTarefaByIdUseCase getTarefaByIdUseCase,
        IUpdateTarefaUseCase updateTarefaUseCase,
        IDeleteTarefaUseCase deleteTarefaUseCase)
    {
        _createTarefaUseCase = createTarefaUseCase;
        _getAllTarefasUseCase = getAllTarefasUseCase;
        _getTarefaByIdUseCase = getTarefaByIdUseCase;
        _updateTarefaUseCase = updateTarefaUseCase;
        _deleteTarefaUseCase = deleteTarefaUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CreateTarefaDto dto)
    {
        var resultado = await _createTarefaUseCase.ExecuteAsync(dto);
        return CreatedAtAction(nameof(ObterPorId), new { id = resultado.Id }, resultado);
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        var resultado = await _getAllTarefasUseCase.ExecuteAsync();
        return Ok(resultado);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var resultado = await _getTarefaByIdUseCase.ExecuteAsync(id);
        return Ok(resultado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] UpdateTarefaDto dto)
    {
        await _updateTarefaUseCase.ExecuteAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        await _deleteTarefaUseCase.ExecuteAsync(id);
        return NoContent();
    }
}