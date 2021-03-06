﻿// <auto-generated />
using System;
using GestaoFinancaPessoal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GestaoFinancaPessoal.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190505213825_forPost")]
    partial class forPost
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("GestaoFinancaPessoal.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("GestaoFinancaPessoal.Models.CPFCNPJ", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Complemento")
                        .HasMaxLength(256);

                    b.Property<string>("CpfCnpj")
                        .IsRequired()
                        .HasMaxLength(18);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("NomeContato")
                        .HasMaxLength(100);

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Observacao")
                        .HasMaxLength(256);

                    b.Property<string>("RG")
                        .HasMaxLength(13);

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Telefones")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int>("TipoPessoa");

                    b.HasKey("Id");

                    b.ToTable("CPFCNPJ");
                });

            modelBuilder.Entity("GestaoFinancaPessoal.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("HierarquiaId");

                    b.Property<bool>("IsSuspenco");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("HierarquiaId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("GestaoFinancaPessoal.Models.Conta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataAtualizacao");

                    b.Property<string>("Descricao")
                        .HasMaxLength(256);

                    b.Property<bool>("IsSuspensa");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<double>("Saldo");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Conta");
                });

            modelBuilder.Entity("GestaoFinancaPessoal.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("OwnerID");

                    b.Property<string>("State");

                    b.Property<int>("Status");

                    b.Property<string>("Zip");

                    b.HasKey("ContactId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("GestaoFinancaPessoal.Models.Lancamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoriaId");

                    b.Property<int?>("ContaDestionId");

                    b.Property<int>("ContaId");

                    b.Property<DateTime>("DataInclusao");

                    b.Property<DateTime>("DataNotificacao")
                        .HasColumnName("Notificacao");

                    b.Property<DateTime?>("DataPagamento");

                    b.Property<DateTime>("DataVencimento");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<bool>("IsAutomatico");

                    b.Property<bool>("IsPago");

                    b.Property<int>("PeriodicidadeNotificacao")
                        .HasColumnName("Periodicidade");

                    b.Property<int?>("RecorrenteId");

                    b.Property<int>("Tempo");

                    b.Property<string>("TipoLancamento")
                        .IsRequired();

                    b.Property<decimal>("Valor");

                    b.Property<decimal>("ValorPago");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("ContaDestionId");

                    b.HasIndex("ContaId");

                    b.HasIndex("RecorrenteId");

                    b.ToTable("Lancamento");
                });

            modelBuilder.Entity("GestaoFinancaPessoal.Models.Notificacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Periodicidade");

                    b.Property<int>("Tempo");

                    b.HasKey("Id");

                    b.ToTable("Notificacao");
                });

            modelBuilder.Entity("GestaoFinancaPessoal.Models.Recorrente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataInicial");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<bool>("IsMensal");

                    b.Property<int>("ParcelaInicial");

                    b.Property<int>("Periodo");

                    b.Property<int>("Quantidade");

                    b.HasKey("Id");

                    b.ToTable("Recorrente");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Recorrente");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("GestaoFinancaPessoal.ViewModels.RecorrenteViewModel", b =>
                {
                    b.HasBaseType("GestaoFinancaPessoal.Models.Recorrente");

                    b.Property<DateTime?>("DataFinal");

                    b.Property<bool?>("IsAvancado");

                    b.Property<int>("Periodicidade");

                    b.Property<int>("Repetir");

                    b.Property<decimal?>("ValorTotal");

                    b.HasDiscriminator().HasValue("RecorrenteViewModel");
                });

            modelBuilder.Entity("GestaoFinancaPessoal.Models.Categoria", b =>
                {
                    b.HasOne("GestaoFinancaPessoal.Models.Categoria", "Hierarquia")
                        .WithMany()
                        .HasForeignKey("HierarquiaId");
                });

            modelBuilder.Entity("GestaoFinancaPessoal.Models.Lancamento", b =>
                {
                    b.HasOne("GestaoFinancaPessoal.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GestaoFinancaPessoal.Models.Conta", "ContaDestion")
                        .WithMany()
                        .HasForeignKey("ContaDestionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GestaoFinancaPessoal.Models.Conta", "Conta")
                        .WithMany()
                        .HasForeignKey("ContaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GestaoFinancaPessoal.Models.Recorrente", "Recorrente")
                        .WithMany()
                        .HasForeignKey("RecorrenteId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("GestaoFinancaPessoal.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GestaoFinancaPessoal.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GestaoFinancaPessoal.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("GestaoFinancaPessoal.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
