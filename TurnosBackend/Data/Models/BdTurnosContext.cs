using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Models;

public partial class BdTurnosContext : DbContext
{
    SqlConnection connection;

    public BdTurnosContext()
    {
        var configuration = GetConfiguration();
        connection = new SqlConnection(configuration.GetSection("ConnectionStrings").GetSection("ContactsApiConnectionString").Value);
    }

    public BdTurnosContext(DbContextOptions<BdTurnosContext> options)
        : base(options)
    {
    }

    public IConfigurationRoot GetConfiguration()
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        return builder.Build();
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientXTurnXUserXService> ClientsXTurnsXUsersXServices { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Turn> Turns { get; set; }

    public virtual DbSet<TypeDoc> TypeDocs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(connection);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_clients");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.IdTypeDoc).HasColumnName("id_type_doc");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.NumDoc)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("num_doc");
            entity.Property(e => e.NumPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("num_phone");

            entity.HasOne(d => d.TypeDoc).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdTypeDoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_clients_type_docs");
        });

        modelBuilder.Entity<ClientXTurnXUserXService>(entity =>
        {
            entity.HasKey(e => new { e.IdClient, e.IdTurn, e.IdUser, e.IdService }).HasName("pk_clients_x_turns_x_users_x_services");

            entity.ToTable("Clients_X_Turns_X_Users_X_Services");

            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IdTurn).HasColumnName("id_turn");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.IdService).HasColumnName("id_service");

            entity.HasOne(d => d.Client).WithMany(p => p.ClientsXTurnsXUsersXServices)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_clients_x_turns_x_users_clients");

            entity.HasOne(d => d.Turn).WithMany(p => p.ClientsXTurnsXUsersXServices)
                .HasForeignKey(d => d.IdTurn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_clients_x_turns_x_users_turns");

            entity.HasOne(d => d.User).WithMany(p => p.ClientsXTurnsXUsersXServices)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_clients_x_turns_x_users_users");


            entity.HasOne(d => d.Service).WithMany(p => p.ClientsXTurnsXUsersXServices)
                .HasForeignKey(d => d.IdService)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_clients_x_turns_x_users_services");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_profiles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_services");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Turn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_turns");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
        });

        modelBuilder.Entity<TypeDoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_type_docs");

            entity.ToTable("Type_Docs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.IdProfile).HasColumnName("id_profile");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.Profile).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdProfile)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_profiles");

            entity.HasMany(d => d.Services).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UsersXService",
                    r => r.HasOne<Service>().WithMany()
                        .HasForeignKey("IdService")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_users_x_services_services"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_users_x_services_users"),
                    j =>
                    {
                        j.HasKey("IdUser", "IdService").HasName("pk_users_x_services");
                        j.ToTable("Users_X_Services");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
