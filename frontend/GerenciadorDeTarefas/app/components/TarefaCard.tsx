import { Tarefa, StatusTarefa } from "../types/tarefa";

interface TarefaCardProps {
  tarefa: Tarefa;
  onEditar: (tarefa: Tarefa) => void;
  onDeletar: (id: number) => void;
}

function getStatusLabel(status: StatusTarefa): string {
  switch (status) {
    case StatusTarefa.Pendente:    return "Pendente";
    case StatusTarefa.EmProgresso: return "Em Progresso";
    case StatusTarefa.Concluida:   return "Concluída";
  }
}

function getStatusClass(status: StatusTarefa): string {
  switch (status) {
    case StatusTarefa.Pendente:    return "status-pendente";
    case StatusTarefa.EmProgresso: return "status-progresso";
    case StatusTarefa.Concluida:   return "status-concluida";
  }
}

export default function TarefaCard({ tarefa, onEditar, onDeletar }: TarefaCardProps) {
  return (
    <div className="card">
      <div className="card-header">
        <h3>{tarefa.titulo}</h3>
        <span className={`status ${getStatusClass(tarefa.status)}`}>
          {getStatusLabel(tarefa.status)}
        </span>
      </div>

      {tarefa.descricao && (
        <p className="card-descricao">{tarefa.descricao}</p>
      )}

      <div className="card-footer">
        <small>Criado em: {new Date(tarefa.dataCriacao).toLocaleDateString("pt-BR")}</small>
        {tarefa.dataConclusao && (
          <small>Concluído em: {new Date(tarefa.dataConclusao).toLocaleDateString("pt-BR")}</small>
        )}
      </div>

      <div className="card-actions">
        <button onClick={() => onEditar(tarefa)}>Editar</button>
        <button onClick={() => onDeletar(tarefa.id)} className="btn-deletar">Deletar</button>
      </div>
    </div>
  );
}