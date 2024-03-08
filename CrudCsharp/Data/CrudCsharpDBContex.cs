using CrudCsharp.Data.Map;
using CrudCsharp.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudCsharp.Data
{
    public class CrudCsharpDBContex
        : DbContext
    {
        public CrudCsharpDBContex(DbContextOptions<CrudCsharpDBContex> options) 
            : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
