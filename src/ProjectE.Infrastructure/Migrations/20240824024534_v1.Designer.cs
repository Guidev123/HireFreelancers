﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectE.Infrastructure;

#nullable disable

namespace ProjectE.Infrastructure.Migrations
{
    [DbContext(typeof(ProjectEDbContext))]
    [Migration("20240824024534_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjectE.Core.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(180)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(180)");

                    b.HasKey("Id");

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("ProjectE.Core.Entities.CustomerSkill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("SkillId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SkillId");

                    b.ToTable("CustomerSkills", (string)null);
                });

            modelBuilder.Entity("ProjectE.Core.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CompletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(180)");

                    b.Property<Guid>("FreelancerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ProjectStatus")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(180)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("FreelancerId");

                    b.ToTable("Projects", (string)null);
                });

            modelBuilder.Entity("ProjectE.Core.Entities.ProjectComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("varchar(180)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectComments", (string)null);
                });

            modelBuilder.Entity("ProjectE.Core.Entities.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(180)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Skills", (string)null);
                });

            modelBuilder.Entity("ProjectE.Core.Entities.CustomerSkill", b =>
                {
                    b.HasOne("ProjectE.Core.Entities.Customer", "Customer")
                        .WithMany("Skills")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProjectE.Core.Entities.Skill", "Skill")
                        .WithMany("CustomerSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("ProjectE.Core.Entities.Project", b =>
                {
                    b.HasOne("ProjectE.Core.Entities.Customer", "Customer")
                        .WithMany("OwnedProjects")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProjectE.Core.Entities.Customer", "Freelancer")
                        .WithMany("FreelanceProjects")
                        .HasForeignKey("FreelancerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Freelancer");
                });

            modelBuilder.Entity("ProjectE.Core.Entities.ProjectComment", b =>
                {
                    b.HasOne("ProjectE.Core.Entities.Customer", "Customer")
                        .WithMany("ProjectComments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProjectE.Core.Entities.Project", "Project")
                        .WithMany("Comments")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ProjectE.Core.Entities.Customer", b =>
                {
                    b.Navigation("FreelanceProjects");

                    b.Navigation("OwnedProjects");

                    b.Navigation("ProjectComments");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("ProjectE.Core.Entities.Project", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("ProjectE.Core.Entities.Skill", b =>
                {
                    b.Navigation("CustomerSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
