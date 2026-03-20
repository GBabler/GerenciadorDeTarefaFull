using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GerenciarTarefas.Application.Interfaces;

public interface IDeleteTarefaUseCase
{
    Task ExecuteAsync(int id);
}