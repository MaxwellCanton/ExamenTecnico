using ExamenTecnico.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamenTecnico.Data
{
    public class NotasContext : DbContext
    {
        public NotasContext(DbContextOptions<NotasContext> options) : base(options)
        {
        }

        public DbSet<NotaModelo> Notas { get; set; }//Instanciamos identidad del modelo NotasModelo


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NotaModelo>().ToTable("tbl_Notas");
        }


    }
}
