﻿// <auto-generated />
using System;
using AlexaIOTInfraredRemoteAPI.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlexaIOTInfraredRemoteAPI.Infrastructure.Migrations
{
    [DbContext(typeof(AiirContext))]
    partial class AiirContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AlexaIOTInfraredRemoteAPI.Domain.InfraredSignal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AssignedButton")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InfraredData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("InfraredSignals");
                });

            modelBuilder.Entity("AlexaIOTInfraredRemoteAPI.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AlexaIOTInfraredRemoteAPI.Domain.InfraredSignal", b =>
                {
                    b.HasOne("AlexaIOTInfraredRemoteAPI.Domain.User", null)
                        .WithMany("InfraredSignals")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AlexaIOTInfraredRemoteAPI.Domain.User", b =>
                {
                    b.Navigation("InfraredSignals");
                });
#pragma warning restore 612, 618
        }
    }
}
