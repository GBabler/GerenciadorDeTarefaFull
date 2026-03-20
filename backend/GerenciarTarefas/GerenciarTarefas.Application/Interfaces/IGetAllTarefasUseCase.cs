using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciarTarefas.Application.DTOs;

namespace GerenciarTarefas.Application.Interfaces;

public interface IGetAllTarefasUseCase
{
    Task<IEnumerable<TarefaResponseDto>> ExecuteAsync();
}