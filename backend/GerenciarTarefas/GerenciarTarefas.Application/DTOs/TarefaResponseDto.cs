using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciarTarefas.Domain.Enums;

namespace GerenciarTarefas.Application.DTOs;

public class TarefaResponseDto
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string? Descricao { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataConclusao { get; set; }
    public StatusTarefa Status { get; set; }
}