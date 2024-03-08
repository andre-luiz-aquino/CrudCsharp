using CrudCsharp.Data;
using CrudCsharp.Models;
using CrudCsharp.Repositorios.Interface;
using Microsoft.EntityFrameworkCore;

namespace CrudCsharp.Repositorios
{

    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly CrudCsharpDBContex _dbcontext;

        public TarefaRepositorio(CrudCsharpDBContex crudCsharpDBContex) 
        { 
            _dbcontext = crudCsharpDBContex;
        }



        public async Task<TarefaModel> BuscarPorId(int id)
        {
            return await _dbcontext.Tarefa.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            return await _dbcontext.Tarefa.ToListAsync();

        }
        public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
        {
            await _dbcontext.Tarefa.AddAsync(tarefa);
            await _dbcontext.SaveChangesAsync();

            return tarefa;
        }
        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);

            if (tarefaPorId == null)
            {
                throw new Exception("Tarefa não encontrado.");
            }
            tarefaPorId.Nome = tarefa.Nome;
            tarefaPorId.Descricao = tarefa.Descricao;
            tarefaPorId.Status = tarefa.Status;
            tarefaPorId.UsuarioId = tarefa.UsuarioId;
           

            _dbcontext.Tarefa.Update(tarefaPorId);
            await _dbcontext.SaveChangesAsync();

            return tarefaPorId;
        }
        public async Task<bool> Apagar(int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);

            if (tarefaPorId == null)
            {
                throw new Exception("Tarefa não encontrado.");
            }

            _dbcontext.Tarefa.Remove(tarefaPorId);
            await _dbcontext.SaveChangesAsync();
            return true;

        }

     

    }
}
