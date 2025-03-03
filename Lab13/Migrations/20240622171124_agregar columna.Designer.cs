﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab13.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240622171124_agregar columna")]
    partial class agregarcolumna
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lab13.Models.Customer", b =>
                {
                    b.Property<int>("IdCustomers")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCustomers"));

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCustomers");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Lab13.Models.Detail", b =>
                {
                    b.Property<int>("IdDetails")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetails"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("Invoices_IdInvoices")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Products_IdProducts")
                        .HasColumnType("int");

                    b.Property<float>("SubTotal")
                        .HasColumnType("real");

                    b.HasKey("IdDetails");

                    b.HasIndex("Invoices_IdInvoices");

                    b.HasIndex("Products_IdProducts");

                    b.ToTable("Details");
                });

            modelBuilder.Entity("Lab13.Models.Invoice", b =>
                {
                    b.Property<int>("IdInvoices")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInvoices"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCustomers")
                        .HasColumnType("int");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.HasKey("IdInvoices");

                    b.HasIndex("IdCustomers");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Lab13.Models.Product", b =>
                {
                    b.Property<int>("IdProducts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProducts"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("IdProducts");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Lab13.Models.Detail", b =>
                {
                    b.HasOne("Lab13.Models.Invoice", "Invoice")
                        .WithMany("Details")
                        .HasForeignKey("Invoices_IdInvoices")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab13.Models.Product", "Product")
                        .WithMany("Details")
                        .HasForeignKey("Products_IdProducts")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Lab13.Models.Invoice", b =>
                {
                    b.HasOne("Lab13.Models.Customer", "Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("IdCustomers")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Lab13.Models.Customer", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("Lab13.Models.Invoice", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("Lab13.Models.Product", b =>
                {
                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
}
