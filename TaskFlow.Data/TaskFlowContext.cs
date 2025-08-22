using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Data;

public class TaskFlowContext : DbContext
{
    public DbSet<UserBase> Users { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<SubActivity> SubActivities { get; set; }
    public DbSet<Proyect> Proyects { get; set; }
    public DbSet<UserProyect> UserProyects { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<TeamMembership> TeamMemberships { get; set; }
    public TaskFlowContext(DbContextOptions<TaskFlowContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserBase>(ub =>
        {
            ub.ToTable("Users");
            ub.HasKey(u => u.Id);
            ub.Property(u => u.Name).IsRequired().HasMaxLength(100);
            ub.Property(u => u.LastName).IsRequired().HasMaxLength(100);
            ub.Property(u => u.Email).IsRequired().HasMaxLength(200);
            ub.Property(u => u.PhoneNumber).IsRequired();
            ub.Property(u => u.Username).IsRequired().HasMaxLength(50);
            ub.Property(u => u.Password).IsRequired().HasMaxLength(8);
            ub.Property(u => u.Role).IsRequired().HasMaxLength(20);
            ub.Property(u => u.IsActive).IsRequired();
            ub.Property(u => u.CreatedAt).IsRequired();
            ub.Property(u => u.UpdatedAt).IsRequired(false);
            ub.HasMany(u => u.Proyects).WithMany(p => p.Users).UsingEntity<UserProyect>(
                j => j.HasOne(up => up.Proyect).WithMany().HasForeignKey(up => up.ProyectId),
                j => j.HasOne(up => up.User).WithMany().HasForeignKey(up => up.UserId),
                j =>
                {
                    j.ToTable("UserProyects");
                    j.HasKey(t => t.Id);
                    j.Property(t => t.Role).IsRequired().HasMaxLength(50);
                    j.Property(t => t.CreatedAt).IsRequired();
                    j.Property(t => t.UpdatedAt).IsRequired(false);
                    j.Property(t => t.CanEdit).IsRequired();
                }
            );
        });
        modelBuilder.Entity<Activity>(a =>
        {
            a.ToTable("Activities");
            a.HasKey(act => act.Id);
            a.Property(act => act.Title).IsRequired().HasMaxLength(100);
            a.Property(act => act.Description).IsRequired(false).HasMaxLength(100);
            a.Property(act => act.Status).IsRequired().HasMaxLength(50);
            a.Property(act => act.Priority).IsRequired().HasMaxLength(50);
            a.Property(act => act.CreatedAt).IsRequired();
            a.Property(act => act.UpdateAt).IsRequired(false);
            a.HasOne<Proyect>().WithMany(act => act.Activities).HasForeignKey(act => act.ProyectId).OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<SubActivity>(sa =>
        {
            sa.ToTable("SubActivities");
            sa.HasKey(sub => sub.Id);
            sa.Property(sub => sub.Title).IsRequired().HasMaxLength(100);
            sa.Property(sub => sub.Description).IsRequired(false).HasMaxLength(100);
            sa.Property(sub => sub.CreatedAt).IsRequired();
            sa.Property(sub => sub.UpdateAt).IsRequired(false);
            sa.HasOne<Activity>().WithMany(sub => sub.SubActivities).HasForeignKey(sub => sub.ActivityId).OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<Proyect>(p =>
        {
            p.ToTable("Proyects");
            p.HasKey(pro => pro.Id);
            p.Property(pro => pro.Name).IsRequired().HasMaxLength(100);
            p.Property(pro => pro.CreatedAt).IsRequired();
            p.Property(pro => pro.UpdatedAt).IsRequired(false);
        });
        modelBuilder.Entity<Team>(Team =>
        {
            Team.ToTable("Teams");
            Team.HasKey(t => t.Id);
            Team.Property(t => t.Name).IsRequired().HasMaxLength(100);
            Team.Property(t => t.CreatedAt).IsRequired();
            Team.Property(t => t.UpdatedAt).IsRequired(false);
            Team.HasMany(t => t.Members).WithMany(tm => tm.Teams).UsingEntity<TeamMembership>(
                j => j.HasOne(tm => tm.User).WithMany().HasForeignKey(tm => tm.UserId),
                j => j.HasOne(tm => tm.Team).WithMany().HasForeignKey(tm => tm.TeamId),
                j =>
                {
                    j.ToTable("TeamMemberships");
                    j.HasKey(t => t.Id);
                    j.Property(t => t.Role).IsRequired().HasMaxLength(50);
                    j.Property(t => t.JoinedAt).IsRequired();
                    j.Property(t => t.UpdatedAt).IsRequired(false);
                    j.Property(t => t.CanEdit).IsRequired();
                }
            );
        });
    }
}
