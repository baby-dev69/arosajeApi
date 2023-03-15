using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Arosaje_Api.Entities;

public partial class ArosajeContext : DbContext
{
    public ArosajeContext()
    {
    }

    public ArosajeContext(DbContextOptions<ArosajeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Annonce> Annonces { get; set; }

    public virtual DbSet<Botaniste> Botanistes { get; set; }

    public virtual DbSet<Concerner> Concerners { get; set; }

    public virtual DbSet<Gardien> Gardiens { get; set; }

    public virtual DbSet<Plante> Plantes { get; set; }

    public virtual DbSet<Proprietaire> Proprietaires { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Annonce>(entity =>
        {
            entity.HasKey(e => e.id_annonce).HasName("PRIMARY");

            entity.ToTable("annonce");

            entity.HasIndex(e => e.id_gardien, "Annonce_Gardien_FK");

            entity.Property(e => e.id_annonce)
                .HasColumnType("int(11)")
                .HasColumnName("id_annonce");
            entity.Property(e => e.accepter).HasColumnName("accepter");
            entity.Property(e => e.description_annonce)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("description_annonce");
            entity.Property(e => e.id_gardien)
                .HasColumnType("int(11)")
                .HasColumnName("id_gardien");
            entity.Property(e => e.titre_annonce)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("titre_annonce");

            entity.HasOne(d => d.IdGardienNavigation).WithMany(p => p.Annonces)
                .HasForeignKey(d => d.id_gardien)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Annonce_Gardien_FK");
        });

        modelBuilder.Entity<Botaniste>(entity =>
        {
            entity.HasKey(e => e.IdBotaniste).HasName("PRIMARY");

            entity.ToTable("botaniste");

            entity.Property(e => e.IdBotaniste)
                .HasColumnType("int(11)")
                .HasColumnName("id_botaniste");
            entity.Property(e => e.AdresseBotaniste)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("adresse_botaniste");
            entity.Property(e => e.AgeBotaniste)
                .HasColumnType("int(11)")
                .HasColumnName("age_botaniste");
            entity.Property(e => e.EmailBotaniste)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("email_botaniste");
            entity.Property(e => e.NomBotaniste)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("nom_botaniste");
            entity.Property(e => e.PrenomBotaniste)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("prenom_botaniste");
            entity.Property(e => e.TelephoneBotaniste)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("telephone_botaniste");
        });

        modelBuilder.Entity<Concerner>(entity =>
        {
            entity.HasKey(e => new { e.IdPlante, e.IdAnnonce, e.IdProprio }).HasName("PRIMARY");

            entity.ToTable("concerner");

            entity.HasIndex(e => e.IdAnnonce, "concerner_Annonce0_FK");

            entity.HasIndex(e => e.IdProprio, "concerner_Proprietaire1_FK");

            entity.Property(e => e.IdPlante)
                .HasColumnType("int(11)")
                .HasColumnName("id_plante");
            entity.Property(e => e.IdAnnonce)
                .HasColumnType("int(11)")
                .HasColumnName("id_annonce");
            entity.Property(e => e.IdProprio)
                .HasColumnType("int(11)")
                .HasColumnName("id_proprio");

            entity.HasOne(d => d.IdAnnonceNavigation).WithMany(p => p.Concerners)
                .HasForeignKey(d => d.IdAnnonce)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("concerner_Annonce0_FK");

            entity.HasOne(d => d.IdPlanteNavigation).WithMany(p => p.Concerners)
                .HasForeignKey(d => d.IdPlante)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("concerner_Plante_FK");

            entity.HasOne(d => d.IdProprioNavigation).WithMany(p => p.Concerners)
                .HasForeignKey(d => d.IdProprio)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("concerner_Proprietaire1_FK");
        });

        modelBuilder.Entity<Gardien>(entity =>
        {
            entity.HasKey(e => e.IdGardien).HasName("PRIMARY");

            entity.ToTable("gardien");

            entity.Property(e => e.IdGardien)
                .HasColumnType("int(11)")
                .HasColumnName("id_gardien");
            entity.Property(e => e.AdresseGardien)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("adresse_gardien");
            entity.Property(e => e.AgeGardien)
                .HasColumnType("int(11)")
                .HasColumnName("age_gardien");
            entity.Property(e => e.EmailGardien)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("email_gardien");
            entity.Property(e => e.NomGardien)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("nom_gardien");
            entity.Property(e => e.PrenomGardien)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("prenom_gardien");
            entity.Property(e => e.TelephoneGardien)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("telephone_gardien");

            entity.HasMany(d => d.IdPlantes).WithMany(p => p.IdGardiens)
                .UsingEntity<Dictionary<string, object>>(
                    "Garder",
                    r => r.HasOne<Plante>().WithMany()
                        .HasForeignKey("IdPlante")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("garder_Plante0_FK"),
                    l => l.HasOne<Gardien>().WithMany()
                        .HasForeignKey("IdGardien")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("garder_Gardien_FK"),
                    j =>
                    {
                        j.HasKey("IdGardien", "IdPlante").HasName("PRIMARY");
                        j.ToTable("garder");
                        j.HasIndex(new[] { "IdPlante" }, "garder_Plante0_FK");
                        j.IndexerProperty<int>("IdGardien")
                            .HasColumnType("int(11)")
                            .HasColumnName("id_gardien");
                        j.IndexerProperty<int>("IdPlante")
                            .HasColumnType("int(11)")
                            .HasColumnName("id_plante");
                    });
        });

        modelBuilder.Entity<Plante>(entity =>
        {
            entity.HasKey(e => e.id_plante).HasName("PRIMARY");

            entity.ToTable("plante");

            entity.Property(e => e.id_plante)
                .HasColumnType("int(11)")
                .HasColumnName("id_plante");
            entity.Property(e => e.adresse_plante)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("adresse_plante");
            entity.Property(e => e.espece_plante)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("espece_plante");
            entity.Property(e => e.nom_plante)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("nom_plante");

            entity.HasMany(d => d.IdBotanistes).WithMany(p => p.IdPlantes)
                .UsingEntity<Dictionary<string, object>>(
                    "Conseiller",
                    r => r.HasOne<Botaniste>().WithMany()
                        .HasForeignKey("IdBotaniste")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("conseiller_Botaniste0_FK"),
                    l => l.HasOne<Plante>().WithMany()
                        .HasForeignKey("IdPlante")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("conseiller_Plante_FK"),
                    j =>
                    {
                        j.HasKey("IdPlante", "IdBotaniste").HasName("PRIMARY");
                        j.ToTable("conseiller");
                        j.HasIndex(new[] { "IdBotaniste" }, "conseiller_Botaniste0_FK");
                        j.IndexerProperty<int>("IdPlante")
                            .HasColumnType("int(11)")
                            .HasColumnName("id_plante");
                        j.IndexerProperty<int>("IdBotaniste")
                            .HasColumnType("int(11)")
                            .HasColumnName("id_botaniste");
                    });
        });

        modelBuilder.Entity<Proprietaire>(entity =>
        {
            entity.HasKey(e => e.IdProprio).HasName("PRIMARY");

            entity.ToTable("proprietaire", tb => tb.HasComment("Hello"));

            entity.Property(e => e.IdProprio)
                .HasColumnType("int(11)")
                .HasColumnName("id_proprio");
            entity.Property(e => e.Absent).HasColumnName("absent");
            entity.Property(e => e.AdresseProprio)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("adresse_proprio");
            entity.Property(e => e.EmailProprio)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("email_proprio");
            entity.Property(e => e.NomProprio)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("nom_proprio");
            entity.Property(e => e.PrenomProprio)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("prenom_proprio");
            entity.Property(e => e.TelephoneProprio)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("telephone_proprio");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
