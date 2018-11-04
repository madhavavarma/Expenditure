﻿// <auto-generated />
using System;
using Maddy.Apps.Expenditure.DataProvider.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Maddy.Apps.Expenditure.DataProvider.Migrations
{
    [DbContext(typeof(ExpenditureContext))]
    partial class ExpenditureContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Maddy.Apps.Expenditure.Entities.Expenditure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("date");

                    b.Property<string>("Description");

                    b.Property<int>("ExpenditureTypeId");

                    b.Property<int>("TransactionTypeId");

                    b.HasKey("Id");

                    b.HasIndex("ExpenditureTypeId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("Expenditures");
                });

            modelBuilder.Entity("Maddy.Apps.Expenditure.Entities.ExpenditureFilter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExpenditureId");

                    b.Property<int>("FilterId");

                    b.HasKey("Id");

                    b.HasIndex("ExpenditureId");

                    b.HasIndex("FilterId");

                    b.ToTable("ExpenditureFilter");
                });

            modelBuilder.Entity("Maddy.Apps.Expenditure.Entities.ExpenditureType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ExpenditureTypes");
                });

            modelBuilder.Entity("Maddy.Apps.Expenditure.Entities.Filter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Filters");
                });

            modelBuilder.Entity("Maddy.Apps.Expenditure.Entities.TransactionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("TransactionTypes");
                });

            modelBuilder.Entity("Maddy.Apps.Expenditure.Entities.Expenditure", b =>
                {
                    b.HasOne("Maddy.Apps.Expenditure.Entities.ExpenditureType")
                        .WithMany("Expenditures")
                        .HasForeignKey("ExpenditureTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Maddy.Apps.Expenditure.Entities.TransactionType")
                        .WithMany("Expenditures")
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Maddy.Apps.Expenditure.Entities.ExpenditureFilter", b =>
                {
                    b.HasOne("Maddy.Apps.Expenditure.Entities.Expenditure")
                        .WithMany("ExpenditureFilters")
                        .HasForeignKey("ExpenditureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Maddy.Apps.Expenditure.Entities.Filter")
                        .WithMany("ExpenditureFilters")
                        .HasForeignKey("FilterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
