﻿// <auto-generated />
using System;
using EFProtocolDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFProtocolDemo.Migrations
{
    [DbContext(typeof(EFProtocolDemoContext))]
    [Migration("20200110132507_AddDate")]
    partial class AddDate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFProtocolDemo.Mail", b =>
                {
                    b.Property<string>("ProtId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Allegati")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataInvio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataRicezione")
                        .HasColumnType("datetime2");

                    b.Property<string>("Destinatario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mittente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Oggetto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("ProtId");

                    b.ToTable("Mails");
                });
#pragma warning restore 612, 618
        }
    }
}
