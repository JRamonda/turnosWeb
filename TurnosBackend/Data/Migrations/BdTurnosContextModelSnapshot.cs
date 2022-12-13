﻿// <auto-generated />
using System;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(BdTurnosContext))]
    partial class BdTurnosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Data.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("first_name");

                    b.Property<int>("IdTypeDoc")
                        .HasColumnType("int")
                        .HasColumnName("id_type_doc");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("NumDoc")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("num_doc");

                    b.Property<string>("NumPhone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("num_phone");

                    b.HasKey("Id")
                        .HasName("pk_clients");

                    b.HasIndex("IdTypeDoc");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Data.Models.ClientsXTurnsXUser", b =>
                {
                    b.Property<int>("IdClient")
                        .HasColumnType("int")
                        .HasColumnName("id_client");

                    b.Property<int>("IdTurn")
                        .HasColumnType("int")
                        .HasColumnName("id_turn");

                    b.Property<int>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("id_user");

                    b.HasKey("IdClient", "IdTurn", "IdUser")
                        .HasName("pk_clients_x_turns_x_users");

                    b.HasIndex("IdTurn");

                    b.HasIndex("IdUser");

                    b.ToTable("Clients_X_Turns_X_Users", (string)null);
                });

            modelBuilder.Entity("Data.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_profiles");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Data.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(400)
                        .IsUnicode(false)
                        .HasColumnType("varchar(400)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_services");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Data.Models.Turn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime")
                        .HasColumnName("date");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time")
                        .HasColumnName("end_time");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time")
                        .HasColumnName("start_time");

                    b.HasKey("Id")
                        .HasName("pk_turns");

                    b.ToTable("Turns");
                });

            modelBuilder.Entity("Data.Models.TypeDoc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_type_docs");

                    b.ToTable("Type_Docs", (string)null);
                });

            modelBuilder.Entity("Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("first_name");

                    b.Property<int>("IdProfile")
                        .HasColumnType("int")
                        .HasColumnName("id_profile");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(16)
                        .IsUnicode(false)
                        .HasColumnType("varchar(16)")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("IdProfile");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UsersXService", b =>
                {
                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<int>("IdService")
                        .HasColumnType("int");

                    b.HasKey("IdUser", "IdService")
                        .HasName("pk_users_x_services");

                    b.HasIndex("IdService");

                    b.ToTable("Users_X_Services", (string)null);
                });

            modelBuilder.Entity("Data.Models.Client", b =>
                {
                    b.HasOne("Data.Models.TypeDoc", "TypeDoc")
                        .WithMany("Clients")
                        .HasForeignKey("IdTypeDoc")
                        .IsRequired()
                        .HasConstraintName("fk_clients_type_docs");

                    b.Navigation("TypeDoc");
                });

            modelBuilder.Entity("Data.Models.ClientsXTurnsXUser", b =>
                {
                    b.HasOne("Data.Models.Client", "Client")
                        .WithMany("ClientsXTurnsXUsers")
                        .HasForeignKey("IdClient")
                        .IsRequired()
                        .HasConstraintName("fk_clients_x_turns_x_users_clients");

                    b.HasOne("Data.Models.Turn", "Turn")
                        .WithMany("ClientsXTurnsXUsers")
                        .HasForeignKey("IdTurn")
                        .IsRequired()
                        .HasConstraintName("fk_clients_x_turns_x_users_turns");

                    b.HasOne("Data.Models.User", "User")
                        .WithMany("ClientsXTurnsXUsers")
                        .HasForeignKey("IdUser")
                        .IsRequired()
                        .HasConstraintName("fk_clients_x_turns_x_users_users");

                    b.Navigation("Client");

                    b.Navigation("Turn");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Models.User", b =>
                {
                    b.HasOne("Data.Models.Profile", "Profile")
                        .WithMany("Users")
                        .HasForeignKey("IdProfile")
                        .IsRequired()
                        .HasConstraintName("fk_users_profiles");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("UsersXService", b =>
                {
                    b.HasOne("Data.Models.Service", null)
                        .WithMany()
                        .HasForeignKey("IdService")
                        .IsRequired()
                        .HasConstraintName("fk_users_x_services_services");

                    b.HasOne("Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .IsRequired()
                        .HasConstraintName("fk_users_x_services_users");
                });

            modelBuilder.Entity("Data.Models.Client", b =>
                {
                    b.Navigation("ClientsXTurnsXUsers");
                });

            modelBuilder.Entity("Data.Models.Profile", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Data.Models.Turn", b =>
                {
                    b.Navigation("ClientsXTurnsXUsers");
                });

            modelBuilder.Entity("Data.Models.TypeDoc", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("Data.Models.User", b =>
                {
                    b.Navigation("ClientsXTurnsXUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
