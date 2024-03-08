using CrudCsharp.Data;
using CrudCsharp.Models;
using CrudCsharp.Repositorios.Interface;
using Microsoft.EntityFrameworkCore;

namespace CrudCsharp.Repositorios
{

    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly CrudCsharpDBContex _dbcontext;

        public UsuarioRepositorio(CrudCsharpDBContex crudCsharpDBContex) 
        { 
            _dbcontext = crudCsharpDBContex;
        }



        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbcontext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbcontext.Usuarios.ToListAsync();

        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbcontext.Usuarios.AddAsync(usuario);
            await _dbcontext.SaveChangesAsync();

            return usuario;
        }
        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception("Usuario não encontrado.");
            }
            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _dbcontext.Usuarios.Update(usuarioPorId);
            await _dbcontext.SaveChangesAsync();

            return usuarioPorId;
        }
        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception("Usuario não encontrado.");
            }

            _dbcontext.Usuarios.Remove(usuarioPorId);
            await _dbcontext.SaveChangesAsync();
            return true;

        }

     

    }
}
