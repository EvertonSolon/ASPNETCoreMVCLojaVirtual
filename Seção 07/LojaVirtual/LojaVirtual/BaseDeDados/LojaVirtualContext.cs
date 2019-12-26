using LojaVirtual.Modelos;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.BaseDeDados
{
    /// <summary>
    /// LojaVirtualContext é o nome do banco de dados LojaVirtual no SQL no C#.
    /// </summary>
    public class LojaVirtualContext : DbContext
    {
        public LojaVirtualContext(DbContextOptions<LojaVirtualContext> options) : base(options) { }

        //Para encontrar um erro do Entity Framework Core que ocorria ao persistir a atualização do objeto no banco.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.EnableSensitiveDataLogging();

        // A comunicação entre as tabelas do banco de dados e os objetos da pasta Models se dará pelas linhas abaixo.
        // O nome das tabelas será criado pela nome das propriedades abaixo.
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<NewsLetterEmail> NewsLetterEmails { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

    }
}
