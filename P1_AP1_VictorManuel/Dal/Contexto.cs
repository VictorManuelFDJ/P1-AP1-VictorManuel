using Microsoft.EntityFrameworkCore;
using P1_AP1_VictorManuel.Models;

namespace P1_AP1_VictorManuel.Dal;

    public class Contexto : DbContext 
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
     
        public DbSet<EntradaHuacales> Registros { get; set; }
    }

