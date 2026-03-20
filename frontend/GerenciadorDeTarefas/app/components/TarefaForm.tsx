import { useState } from "react";
import { Tarefa, CreateTarefaDto, UpdateTarefaDto, StatusTarefa } from "../types/tarefa";

interface TarefaFormProps {
  tarefaParaEditar?: Tarefa;
  onSalvar: (dto: CreateTarefaDto | UpdateTarefaDto) => void;
  onCancelar: () => void;
}

export default function TarefaForm({ tarefaParaEditar, onSalvar, onCancelar }: TarefaFormProps) {
  const [titulo, setTitulo] = useState(tarefaParaEditar?.titulo || "");
  const [descricao, setDescricao] = useState(tarefaParaEditar?.descricao || "");
  const [status, setStatus] = useState(tarefaParaEditar?.status || StatusTarefa.Pendente);

  function handleSubmit(e: React.FormEvent) {
    e.preventDefault();

    if (tarefaParaEditar) {
      const dto: UpdateTarefaDto = { titulo, descricao, status };
      onSalvar(dto);
    } else {
      const dto: CreateTarefaDto = { titulo, descricao };
      onSalvar(dto);
    }
  }

  return (
    <form onSubmit={handleSubmit} className="form">
      <h2>{tarefaParaEditar ? "Editar Tarefa" : "Nova Tarefa"}</h2>

      <div className="form-group">
        <label>Título *</label>
        <input
          type="text"
          value={titulo}
          onChange={(e) => setTitulo(e.target.value)}
          maxLength={100}
          required
        />
      </div>

      <div className="form-group">
        <label>Descrição</label>
        <textarea
          value={descricao}
          onChange={(e) => setDescricao(e.target.value)}
          rows={3}
        />
      </div>

      {tarefaParaEditar && (
        <div className="form-group">
          <label>Status</label>
          <select value={status} onChange={(e) => setStatus(Number(e.target.value))}>
            <option value={StatusTarefa.Pendente}>Pendente</option>
            <option value={StatusTarefa.EmProgresso}>Em Progresso</option>
            <option value={StatusTarefa.Concluida}>Concluída</option>
          </select>
        </div>
      )}

      <div className="form-actions">
        <button type="submit">Salvar</button>
        <button type="button" onClick={onCancelar}>Cancelar</button>
      </div>
    </form>
  );
}