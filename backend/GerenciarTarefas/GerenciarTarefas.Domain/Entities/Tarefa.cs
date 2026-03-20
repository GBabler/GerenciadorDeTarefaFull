using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciarTarefas.Domain.Enums;

namespace GerenciarTarefas.Domain.Entities;

public class Tarefa
{
    public int Id { get; private set; }
    public string Titulo { get; private set; }
    public string? Descricao { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public DateTime? DataConclusao { get; private set; }
    public StatusTarefa Status { get; private set; }

    public Tarefa(string titulo, string? descricao)
    {
        Titulo = titulo;
        Descricao = descricao;
        DataCriacao = DateTime.UtcNow;
        Status = StatusTarefa.Pendente;
    }

    public void AtualizarDados(string titulo, string? descricao)
    {
        Titulo = titulo;
        Descricao = descricao;
    }

    public void AtualizarStatus(StatusTarefa status)
    {
        if (status == StatusTarefa.Concluida)
        {
            var dataConclusao = DateTime.UtcNow;

            if (dataConclusao < DataCriacao)
                throw new ArgumentException(
                    "Data de conclusão não pode ser anterior à data de criação");

            DataConclusao = dataConclusao;
        }

        Status = status;
    }
}