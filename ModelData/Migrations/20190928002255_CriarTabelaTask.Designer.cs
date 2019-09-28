﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ModelData.Context;
using System;

namespace ModelData.Migrations
{
    [DbContext(typeof(TaskContext))]
    [Migration("20190928002255_CriarTabelaTask")]
    partial class CriarTabelaTask
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ModelData.Model.Tarefa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataDeConclusao");

                    b.Property<DateTime>("DataDeCriacao");

                    b.Property<DateTime?>("DataDeEdicao");

                    b.Property<DateTime?>("DataDeRemocao");

                    b.Property<string>("Descricao");

                    b.Property<int>("Status");

                    b.Property<string>("Titulo");

                    b.HasKey("Id");

                    b.ToTable("Tarefas");
                });
#pragma warning restore 612, 618
        }
    }
}