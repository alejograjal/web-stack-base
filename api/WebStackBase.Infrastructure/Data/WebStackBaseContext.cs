using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WebStackBase.Infrastructure.Data;

public partial class WebStackBaseContext(DbContextOptions<WebStackBaseContext> options) : DbContext(options)
{
    const string CREATEDNAME = "Created";
    const string UPDATEDNAME = "Updated";

    public virtual DbSet<CustomerFeedback> CustomerFeedbacks { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<ReservationDetail> ReservationDetails { get; set; }

    public virtual DbSet<Resource> Resources { get; set; }

    public virtual DbSet<ResourceType> ResourceTypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceResource> ServiceResources { get; set; }

    public virtual DbSet<TokenMaster> TokenMasters { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public IDbConnection Connection => Database.GetDbConnection();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.Property(e => e.Status).IsFixedLength();
        });

        modelBuilder.Entity<ReservationDetail>(entity =>
        {
            entity.HasOne(d => d.Reservation).WithMany(p => p.ReservationDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservationDetail_Reservation");

            entity.HasOne(d => d.Service).WithMany(p => p.ReservationDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservationDetail_Service");
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasOne(d => d.ResourceType).WithMany(p => p.Resources)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resource_ResourceType");
        });

        modelBuilder.Entity<ServiceResource>(entity =>
        {
            entity.HasOne(d => d.Resource).WithMany(p => p.ServiceResources)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceResource_Resource");

            entity.HasOne(d => d.Service).WithMany(p => p.ServiceResources)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceResource_Service");
        });

        modelBuilder.Entity<TokenMaster>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.TokenMasters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TokenMaster_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        OnBeforeSaving();

        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        OnBeforeSaving();

        return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void OnBeforeSaving()
    {
        DefaultProperties();
    }

    private void DefaultProperties()
    {
        string createdByName = "CreatedBy";
        string updatedByName = "UpdatedBy";

        DateTime created = DateTime.Now;
        DateTime updated = DateTime.Now;

        foreach (var entry in ChangeTracker.Entries())
        {
            string createdBy = string.Empty;
            string updatedBy = null!;
            if (entry.Entity.GetType().GetProperty(createdByName) != null) createdBy = entry.Property(createdByName).CurrentValue!.ToString()!;
            if (entry.Entity.GetType().GetProperty(updatedByName) != null)
            {
                var modification = entry.Property(updatedByName).CurrentValue;
                if (modification != null) updatedBy = modification.ToString()!;
            }

            if (entry.State == EntityState.Added)
            {
                GenerateAdded(entry, createdByName, createdBy, updatedByName, created);
            }
            else
            {
                GenerateModified(entry, createdByName, updatedByName, updatedBy, updated);
            }
        }
    }

    private static void GenerateAdded(EntityEntry entry, string createdByName, string createdBy, string updatedByName, DateTime created)
    {
        string activeName = "IsActive";

        if (entry.Entity.GetType().GetProperty(CREATEDNAME) != null && entry.Property(CREATEDNAME).CurrentValue != null) entry.Property(CREATEDNAME).CurrentValue = created;
        if (entry.Entity.GetType().GetProperty(activeName) != null && !(bool)entry.Property(activeName).CurrentValue!) entry.Property(activeName).CurrentValue = true;

        if (entry.Entity.GetType().GetProperty(createdByName) != null && entry.Property(updatedByName).CurrentValue != null)
        {
            entry.Property(createdByName).CurrentValue = entry.Property(updatedByName).CurrentValue;
            entry.Property(updatedByName).CurrentValue = null;
        }

        if (entry.Entity.GetType().GetProperty(createdByName) != null) entry.Property(createdByName).CurrentValue = createdBy;
        if (entry.Entity.GetType().GetProperty(UPDATEDNAME) != null) entry.Property(UPDATEDNAME).IsModified = false;
        if (entry.Entity.GetType().GetProperty(updatedByName) != null) entry.Property(updatedByName).IsModified = false;
    }

    private static void GenerateModified(EntityEntry entry, string createdByName, string updatedByName, string updatedBy, DateTime updated)
    {
        if (entry.State == EntityState.Modified)
        {
            if (entry.Entity.GetType().GetProperty(UPDATEDNAME) != null) entry.Property(UPDATEDNAME).CurrentValue = updated;

            if (entry.Entity.GetType().GetProperty(updatedByName) != null) entry.Property(updatedByName).CurrentValue = updatedBy;
            if (entry.Entity.GetType().GetProperty(CREATEDNAME) != null) entry.Property(CREATEDNAME).IsModified = false;
            if (entry.Entity.GetType().GetProperty(createdByName) != null) entry.Property(createdByName).IsModified = false;
        }
    }
}
