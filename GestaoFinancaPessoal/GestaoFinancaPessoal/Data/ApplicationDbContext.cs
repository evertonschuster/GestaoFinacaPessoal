﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GestaoFinancaPessoal.Models;
using System;
using System.Linq;
using GestaoFinancaPessoal.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoFinancaPessoal.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Core Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Core Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder
               .Entity<Lancamento>()
               .Property(e => e.TipoLancamento)
               .HasConversion(
                   v => v.ToString(),
                   v => (TipoLancamento)Enum.Parse(typeof(TipoLancamento), v));

            builder.Entity<Lancamento>().HasOne(l => l.ContaDestion).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Lancamento>().HasOne(l => l.Conta).WithMany().OnDelete(DeleteBehavior.Restrict);


            //builder.Entity<Categoria>().Ignore("HasLancamento");
            //builder.Entity<CategoriaViewModel>().Ignore("HasLancamento");

        }

        public DbSet<Contact> Contact { get; set; }

        public DbSet<Conta> Conta { get; set; }

        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Lancamento> Lancamento { get; set; }

        public DbSet<Recorrente> Recorrente { get; set; }
    
        public DbSet<CPFCNPJ> CPFCNPJ { get; set; }

        public DbSet<GestaoFinancaPessoal.ViewModels.RecorrenteViewModel> RecorrenteViewModel { get; set; }

        public DbSet<GestaoFinancaPessoal.Models.Notificacao> Notificacao { get; set; }


    }
}
