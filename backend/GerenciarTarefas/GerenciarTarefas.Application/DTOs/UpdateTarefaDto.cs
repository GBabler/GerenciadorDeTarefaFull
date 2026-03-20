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
    [Required(ErrorMessage = "Título é obrigatório")]
    [MaxLength(100, ErrorMessage = "Título deve ter no máximo 100 caracteres")]
    public string Titulo { get; set; }

    public string? Descricao { get; set; }

    [Required(ErrorMessage = "Status é obrigatório")]
    public StatusTarefa Status { get; set; }
}
