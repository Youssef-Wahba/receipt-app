﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using receipt_app;

#nullable disable

namespace receipt_app.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240609065611_updateReceiptItemObject")]
    partial class updateReceiptItemObject
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("receipt_app.Receipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("IssuedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("PaidAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("RemainingAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("receipt_app.models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Balance")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("receipt_app.models.ReceiptItem", b =>
                {
                    b.Property<int>("ReceiptId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ReceiptId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("ReceiptItems");
                });

            modelBuilder.Entity("receipt_app.models.ReceiptItem", b =>
                {
                    b.HasOne("receipt_app.models.Item", "Item")
                        .WithMany("ReceiptItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("receipt_app.Receipt", "Receipt")
                        .WithMany("ReceiptItems")
                        .HasForeignKey("ReceiptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Receipt");
                });

            modelBuilder.Entity("receipt_app.Receipt", b =>
                {
                    b.Navigation("ReceiptItems");
                });

            modelBuilder.Entity("receipt_app.models.Item", b =>
                {
                    b.Navigation("ReceiptItems");
                });
#pragma warning restore 612, 618
        }
    }
}
