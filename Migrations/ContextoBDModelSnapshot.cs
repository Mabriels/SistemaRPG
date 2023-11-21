﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaRPG.Data;

#nullable disable

namespace SistemaRPG.Migrations
{
    [DbContext(typeof(ContextoBD))]
    partial class ContextoBDModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SistemaRPG.Models.Classe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Atributo")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<string>("DataCriacao")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("SistemaRPG.Models.Equipamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Atributo")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<int>("ClasseId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClasseId");

                    b.ToTable("Equipamentos");
                });

            modelBuilder.Entity("SistemaRPG.Models.Personagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Atributo")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<int>("ClasseId")
                        .HasColumnType("int");

                    b.Property<string>("DataCriacao")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<decimal>("Dinheiro")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<int>("RacaId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClasseId");

                    b.HasIndex("RacaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Personagens");
                });

            modelBuilder.Entity("SistemaRPG.Models.Raca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Atributo")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<string>("DataCriacao")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Racas");
                });

            modelBuilder.Entity("SistemaRPG.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SistemaRPG.Models.Equipamento", b =>
                {
                    b.HasOne("SistemaRPG.Models.Classe", "Classe")
                        .WithMany("Equipamentos")
                        .HasForeignKey("ClasseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classe");
                });

            modelBuilder.Entity("SistemaRPG.Models.Personagem", b =>
                {
                    b.HasOne("SistemaRPG.Models.Classe", "Classe")
                        .WithMany("Personagens")
                        .HasForeignKey("ClasseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaRPG.Models.Raca", "Raca")
                        .WithMany("Personagens")
                        .HasForeignKey("RacaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaRPG.Models.Usuario", "Usuario")
                        .WithMany("Personagens")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classe");

                    b.Navigation("Raca");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SistemaRPG.Models.Classe", b =>
                {
                    b.Navigation("Equipamentos");

                    b.Navigation("Personagens");
                });

            modelBuilder.Entity("SistemaRPG.Models.Raca", b =>
                {
                    b.Navigation("Personagens");
                });

            modelBuilder.Entity("SistemaRPG.Models.Usuario", b =>
                {
                    b.Navigation("Personagens");
                });
#pragma warning restore 612, 618
        }
    }
}
