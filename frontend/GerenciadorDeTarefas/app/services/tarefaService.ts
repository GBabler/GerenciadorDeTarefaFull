import { Tarefa, CreateTarefaDto, UpdateTarefaDto } from "../types/tarefa";

const API_URL = `${process.env.NEXT_PUBLIC_API_URL}/Tarefa`;

export async function getTarefas(): Promise<Tarefa[]> {
  const response = await fetch(API_URL);
  return response.json();
}

export async function getTarefaById(id: number): Promise<Tarefa> {
  const response = await fetch(`${API_URL}/${id}`);
  return response.json();
}

export async function createTarefa(dto: CreateTarefaDto): Promise<Tarefa> {
  const response = await fetch(API_URL, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(dto),
  });
  return response.json();
}

export async function updateTarefa(id: number, dto: UpdateTarefaDto): Promise<void> {
  await fetch(`${API_URL}/${id}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(dto),
  });
}

export async function deleteTarefa(id: number): Promise<void> {
  await fetch(`${API_URL}/${id}`, { method: "DELETE" });
}