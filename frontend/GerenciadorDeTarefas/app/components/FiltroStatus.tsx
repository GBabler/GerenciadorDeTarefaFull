import { StatusTarefa } from "../types/tarefa";

interface FiltroStatusProps {
  filtroAtivo: StatusTarefa | null;
  onChange: (status: StatusTarefa | null) => void;
}

export default function FiltroStatus({ filtroAtivo, onChange }: FiltroStatusProps) {
  return (
    <div className="filtro">
      <button
        className={filtroAtivo === null ? "ativo" : ""}
        onClick={() => onChange(null)}
      >
        Todos
      </button>
      <button
        className={filtroAtivo === StatusTarefa.Pendente ? "ativo" : ""}
        onClick={() => onChange(StatusTarefa.Pendente)}
      >
        Pendente
      </button>
      <button
        className={filtroAtivo === StatusTarefa.EmProgresso ? "ativo" : ""}
        onClick={() => onChange(StatusTarefa.EmProgresso)}
      >
        Em Progresso
      </button>
      <button
        className={filtroAtivo === StatusTarefa.Concluida ? "ativo" : ""}
        onClick={() => onChange(StatusTarefa.Concluida)}
      >
        Concluída
      </button>
    </div>
  );
}