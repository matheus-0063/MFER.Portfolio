using MFER.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MFER.Data.Context;

public class MferDbContext : DbContext
{
    public MferDbContext(DbContextOptions options) : base(options)
    {
    }
    
    /*
     * Esse método é chamado quando o Entity Framework Core está construindo o modelo
     * do banco de dados baseado nas classes da sua aplicação.
     */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*
         * Este comando diz ao Entity Framework para procurar todas as classes de configuração (IEntityTypeConfiguration<T>)
         * que estão dentro do mesmo assembly onde MferDbContext está definido.
         *
         * Ou seja, se você tem classes que implementam IEntityTypeConfiguration<T> para configurar entidades,
         * elas serão aplicadas automaticamente.
         */
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MferDbContext).Assembly);
        /*
         * Chama o método da classe base (DbContext) para garantir que qualquer
         * configuração padrão do EF Core ainda seja aplicada.
         */
        base.OnModelCreating(modelBuilder);
        
        /*
         * Desabilita o Delete Cascade
         */
        foreach(var relatioship in modelBuilder.Model.GetEntityTypes()
                    .SelectMany(e => e.GetForeignKeys()))
            relatioship.DeleteBehavior = DeleteBehavior.ClientSetNull;
        /*
         * Defino que qualquer coluna que nao tiver o HasColumnType no mapping,
         * ficara com tamanho de varchar(100) 
         */
        foreach(var property in modelBuilder.Model.GetEntityTypes()
                    .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
            property.SetColumnType("varchar(100)");
    }
    
    public DbSet<Contato> Contatos { get; set; }
    
    public class MferDbContextFactory : IDesignTimeDbContextFactory<MferDbContext>  
    {  
        public MferDbContext CreateDbContext(string[] args)  
        {        var optionsBuilder = new DbContextOptionsBuilder<MferDbContext>();  
            optionsBuilder.UseSqlServer("Server=localhost,1433;Initial Catalog=MFERDB;User ID=sa;Password=127564620mA.;TrustServerCertificate=True;MultipleActiveResultSets=True");  
  
            return new MferDbContext(optionsBuilder.Options);  
        }
    
    }
}