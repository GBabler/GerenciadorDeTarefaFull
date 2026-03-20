export enum StatusTarefa {
  Pendente = 1,
  EmProgresso = 2,
  Concluida = 3
}

export interface Tarefa {
  id: number;
  titulo: string;
  descricao?: string;
  dataCriacao: string;
  dataConclusao?: string;
  status: StatusTarefa;
}

export interface CreateTarefaDto {
  titulo: string;
  descricao?: string;
}

export interface UpdateTarefaDto {
  titulo: string;
  descricao?: string;
  status: StatusTarefa;
}