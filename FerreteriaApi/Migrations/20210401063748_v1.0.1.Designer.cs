﻿// <auto-generated />
using System;
using FerreteriaApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FerreteriaApi.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20210401063748_v1.0.1")]
    partial class v101
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FerreteriaApi.Models.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCategoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("FerreteriaApi.Models.Cliente", b =>
                {
                    b.Property<string>("Cedula")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Cedula");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("FerreteriaApi.Models.Color", b =>
                {
                    b.Property<int>("IdColor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdColor");

                    b.ToTable("Colores");
                });

            modelBuilder.Entity("FerreteriaApi.Models.Empleado", b =>
                {
                    b.Property<string>("IdEmpleado")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cedula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEmpleado");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("FerreteriaApi.Models.Marca", b =>
                {
                    b.Property<int>("IdMarca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMarca");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("FerreteriaApi.Models.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<int>("IdColor")
                        .HasColumnType("int");

                    b.Property<int>("IdMarca")
                        .HasColumnType("int");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Medida")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("IdProducto");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdColor");

                    b.HasIndex("IdMarca");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("FerreteriaApi.Models.Ventas", b =>
                {
                    b.Property<long>("IdVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdEmpleado")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.Property<string>("codigo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdVenta");

                    b.HasIndex("Cedula");

                    b.HasIndex("IdEmpleado");

                    b.HasIndex("IdProducto");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("FerreteriaApi.Models.Producto", b =>
                {
                    b.HasOne("FerreteriaApi.Models.Categoria", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FerreteriaApi.Models.Color", "Color")
                        .WithMany("Productos")
                        .HasForeignKey("IdColor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FerreteriaApi.Models.Marca", "Marca")
                        .WithMany("Productos")
                        .HasForeignKey("IdMarca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Color");

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("FerreteriaApi.Models.Ventas", b =>
                {
                    b.HasOne("FerreteriaApi.Models.Cliente", "Cliente")
                        .WithMany("Ventas")
                        .HasForeignKey("Cedula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FerreteriaApi.Models.Empleado", "Empleado")
                        .WithMany("Ventas")
                        .HasForeignKey("IdEmpleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FerreteriaApi.Models.Producto", "Producto")
                        .WithMany("Ventas")
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Empleado");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("FerreteriaApi.Models.Categoria", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("FerreteriaApi.Models.Cliente", b =>
                {
                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("FerreteriaApi.Models.Color", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("FerreteriaApi.Models.Empleado", b =>
                {
                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("FerreteriaApi.Models.Marca", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("FerreteriaApi.Models.Producto", b =>
                {
                    b.Navigation("Ventas");
                });
#pragma warning restore 612, 618
        }
    }
}