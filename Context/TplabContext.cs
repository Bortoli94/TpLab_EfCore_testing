using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TPLabIV.Models;

namespace TPLabIV.Context;

public partial class TplabContext : DbContext
{
    public TplabContext()
    {
    }

    public TplabContext(DbContextOptions<TplabContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Actor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("actor");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ActorBirthdate).HasColumnName("actor_birthdate");
            entity.Property(e => e.ActorName)
                .HasMaxLength(100)
                .HasColumnName("actor_name");
            entity.Property(e => e.ActorPicture)
                .HasMaxLength(100)
                .HasColumnName("actor_picture");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("movie");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.MovieBudget)
                .HasPrecision(10, 2)
                .HasColumnName("movie_budget");
            entity.Property(e => e.MovieDuration)
                .HasColumnType("int(11)")
                .HasColumnName("movie_duration");
            entity.Property(e => e.MovieGenre)
                .HasMaxLength(100)
                .HasColumnName("movie_genre");
            entity.Property(e => e.MovieName)
                .HasMaxLength(100)
                .HasColumnName("movie_name");

            entity.HasMany(d => d.Actors).WithMany(p => p.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "Movieactor",
                    r => r.HasOne<Actor>().WithMany()
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("movieactor_ibfk_2"),
                    l => l.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("movieactor_ibfk_1"),
                    j =>
                    {
                        j.HasKey("MovieId", "ActorId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("movieactor");
                        j.HasIndex(new[] { "ActorId" }, "ActorId");
                        j.IndexerProperty<int>("MovieId").HasColumnType("int(11)");
                        j.IndexerProperty<int>("ActorId").HasColumnType("int(11)");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
