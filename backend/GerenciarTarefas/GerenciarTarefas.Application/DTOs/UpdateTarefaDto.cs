using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using GerenciarTarefas.Domain.Enums;

namespace GerenciarTarefas.Application.DTOs;

public class UpdateTarefaDto
{
    public string Titulo { get; set; }
    public string? Descricao { get; set; }
    public StatusTarefa Status { get; set; }
}
