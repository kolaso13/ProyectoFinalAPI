﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WebApiTiempoProyecto.Migrations
{
    [DbContext(typeof(MVCpruebaContext))]
    [Migration("20220321083322_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("WebApiAnimeProyecto.Models.AnimeData", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Chapters")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Studio")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name");

                    b.ToTable("AnimeData");
                });

            modelBuilder.Entity("WebApiAnimeProyecto.Models.Anime_User", b =>
                {
                    b.Property<int>("FavoritoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AnimeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("FavoritoId");

                    b.HasIndex("AnimeName");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Anime_User");
                });

            modelBuilder.Entity("WebApiAnimeProyecto.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WebApiAnimeProyecto.Models.Anime_User", b =>
                {
                    b.HasOne("WebApiAnimeProyecto.Models.AnimeData", "AnimeData")
                        .WithMany()
                        .HasForeignKey("AnimeName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiAnimeProyecto.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnimeData");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}