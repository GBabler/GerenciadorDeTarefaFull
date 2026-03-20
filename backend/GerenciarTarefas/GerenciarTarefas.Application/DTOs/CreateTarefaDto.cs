using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GerenciarTarefas.Application.DTOs;

public class CreateTarefaDto
{
    [Required(ErrorMessage = "Título é obrigatório")]
    [MaxLength(100, ErrorMessage = "Título deve ter no máximo 100 caracteres")]
    public string Titulo { get; set; }

    public string? Descricao { get; set; }
}