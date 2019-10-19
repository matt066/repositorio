using Contas.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contas.Repositories
{
    public class PersisteContext : DbContext
    {
        public PersisteContext() { }

        public PersisteContext(DbContextOptions<PersisteContext> ctx)
            : base(ctx)
        { }

        public DbSet<CreditosEntity> Creditos {get; set;}
        public DbSet<DebitosEntity> Debitos { get; set; }
        public DbSet<InvestimentoEntity> Investimentos { get; set; }
        public DbSet<ResultadoMesEntity> Resultados { get; set; }

        private void ConfiguraCreditos (ModelBuilder construtorDeModelos)
        {
            construtorDeModelos.Entity<CreditosEntity>(etd =>
            {
                etd.ToTable("tbCreditos");
                etd.HasKey(c => c.idCredito).HasName("id");
                etd.Property(c => c.idCredito).HasColumnName("id").ValueGeneratedOnAdd();
                etd.Property(c => c.nomeCredito).HasColumnName("nome").HasMaxLength(250);
                etd.Property(c => c.dataCredito).HasColumnName("data");
                etd.Property(c => c.valorCredito).HasColumnName("valor");
            });
        }

        private void ConfiguraDebitos(ModelBuilder construtorDeModelos)
        {
            construtorDeModelos.Entity<DebitosEntity>(etd =>
            {
                etd.ToTable("tbDebitos");
                etd.HasKey(c => c.idDebito).HasName("id");
                etd.Property(c => c.idDebito).HasColumnName("id").ValueGeneratedOnAdd();
                etd.Property(c => c.nomeDebito).HasColumnName("nome").HasMaxLength(250);
                etd.Property(c => c.dataDebito).HasColumnName("data");
                etd.Property(c => c.valorDebito).HasColumnName("valor");
            });
        }

        private void ConfiguraInvestimento(ModelBuilder construtorDeModelos)
        {
            construtorDeModelos.Entity<InvestimentoEntity>(etd =>
            {
                etd.ToTable("tbInvestimento");
                etd.HasKey(c => c.idInvestimento).HasName("id");
                etd.Property(c => c.idInvestimento).HasColumnName("id").ValueGeneratedOnAdd();
                etd.Property(c => c.nomeInvestimento).HasColumnName("nome").HasMaxLength(250);
                etd.Property(c => c.dataInvestimento).HasColumnName("data");
                etd.Property(c => c.valorInvestimento).HasColumnName("valor");
            });
        }

        private void ConfiguraResultadoMes(ModelBuilder construtorDeModelos)
        {
            construtorDeModelos.Entity<ResultadoMesEntity>(etd =>
            {
                etd.ToTable("tbResultadoMes");
                etd.HasKey(c => c.idResultadoMes).HasName("id");
                etd.Property(c => c.idResultadoMes).HasColumnName("id").ValueGeneratedOnAdd();
                etd.Property(c => c.debitos).HasColumnName("debito");
                etd.Property(c => c.saldo).HasColumnName("saldo");
            });
        }

        protected override void OnModelCreating(ModelBuilder construtorDeModelos)
        {
            construtorDeModelos.ForSqlServerUseIdentityColumns();
            construtorDeModelos.HasDefaultSchema("ControleContas");

            ConfiguraCreditos(construtorDeModelos);
            ConfiguraDebitos(construtorDeModelos);
            ConfiguraInvestimento(construtorDeModelos);
            ConfiguraResultadoMes(construtorDeModelos);
        }
    }

}
