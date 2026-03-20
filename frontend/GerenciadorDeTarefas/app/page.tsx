"use client";

import { useEffect, useState } from "react";
import { Tarefa, CreateTarefaDto, UpdateTarefaDto, StatusTarefa } from "./types/tarefa";
import { getTarefas, createTarefa, updateTarefa, deleteTarefa } from "./services/tarefaService";
import TarefaCard from "./components/TarefaCard";
import TarefaForm from "./components/TarefaForm";
import FiltroStatus from "./components/FiltroStatus";

export default function Home() {
  const [tarefas, setTarefas] = useState<Tarefa[]>([]);
  const [filtro, setFiltro] = useState<StatusTarefa | null>(null);
  const [tarefaParaEditar, setTarefaParaEditar] = useState<Tarefa | undefined>(undefined);
  const [mostrarForm, setMostrarForm] = useState(false);
  const [carregando, setCarregando] = useState(true);

  useEffect(() => {
    carregarTarefas();
  }, []);

  async function carregarTarefas() {
    setCarregando(true);
    const dados = await getTarefas();
    setTarefas(dados);
    setCarregando(false);
  }

  async function handleSalvar(dto: CreateTarefaDto | UpdateTarefaDto) {
    if (tarefaParaEditar) {
      await updateTarefa(tarefaParaEditar.id, dto as UpdateTarefaDto);
    } else {
      await createTarefa(dto as CreateTarefaDto);
    }
    setMostrarForm(false);
    setTarefaParaEditar(undefined);
    await carregarTarefas();
  }

  async function handleDeletar(id: number) {
    if (confirm("Deseja realmente deletar esta tarefa?")) {
      await deleteTarefa(id);
      await carregarTarefas();
    }
  }

  function handleEditar(tarefa: Tarefa) {
    setTarefaParaEditar(tarefa);
    setMostrarForm(true);
  }

  function handleNovaTarefa() {
    setTarefaParaEditar(undefined);
    setMostrarForm(true);
  }

  function handleCancelar() {
    setTarefaParaEditar(undefined);
    setMostrarForm(false);
  }

  const tarefasFiltradas = filtro === null
    ? tarefas
    : tarefas.filter(t => t.status === filtro);

  return (
    <main className="container">
      <h1>Gerenciador de Tarefas</h1>

      <div className="toolbar">
        <FiltroStatus filtroAtivo={filtro} onChange={setFiltro} />
        <button className="btn-nova" onClick={handleNovaTarefa}>+ Nova Tarefa</button>
      </div>

      {mostrarForm && (
        <TarefaForm
          tarefaParaEditar={tarefaParaEditar}
          onSalvar={handleSalvar}
          onCancelar={handleCancelar}
        />
      )}

      {carregando ? (
        <p className="mensagem">Carregando tarefas...</p>
      ) : tarefasFiltradas.length === 0 ? (
        <p className="mensagem">Nenhuma tarefa encontrada.</p>
      ) : (
        <div className="lista">
          {tarefasFiltradas.map(tarefa => (
            <TarefaCard
              key={tarefa.id}
              tarefa={tarefa}
              onEditar={handleEditar}
              onDeletar={handleDeletar}
            />
          ))}
        </div>
      )}
    </main>
  );
}