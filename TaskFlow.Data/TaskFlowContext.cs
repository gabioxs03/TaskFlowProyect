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
    public DbSet<TaskItem> TaskItems { get; set; }
    public DbSet<UserBase> Users { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public TaskFlowContext(DbContextOptions<TaskFlowContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<TaskItem>(eb =>
        {
            eb.HasKey(t => t.Id);
            eb.Property(t => t.Title).IsRequired().HasMaxLength(100);
            eb.Property(t => t.Description).HasMaxLength(200);
            eb.Property(t => t.Priority).IsRequired();
            eb.Property(t => t.Status).IsRequired();
            eb.Property(t => t.CreatedAt).IsRequired();
            eb.Property(t => t.UpdateAt).IsRequired();
            eb.HasOne<UserBase>().WithMany().HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<UserBase>(eb =>
        {
            eb.HasKey(u => u.Id);
            eb.Property(u => u.Name).IsRequired().HasMaxLength(50);
            eb.Property(u => u.LastName).IsRequired().HasMaxLength(50);
            eb.Property(u => u.Email).IsRequired().HasMaxLength(50);
            eb.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(10);
            eb.Property(u => u.Username).IsRequired().HasMaxLength(20);
            eb.Property(u => u.Password).IsRequired().HasMaxLength(20);
            eb.Property(u => u.Role).IsRequired().HasMaxLength(10);
            eb.Property(u => u.IsActive).IsRequired();
            eb.Property(u => u.CreatedAt).IsRequired();

        });
        modelBuilder.Entity<Notification>(eb =>
        {
            eb.HasKey(n => n.Id);
            eb.Property(n => n.Title).IsRequired().HasMaxLength(100);
            eb.Property(n => n.Message).IsRequired().HasMaxLength(200);
            eb.Property(n => n.IsRead).IsRequired();
            eb.Property(n => n.NotificationType).IsRequired();
            eb.Property(n => n.CreatedAt).IsRequired();
            eb.HasOne<TaskItem>().WithMany().HasForeignKey(n => n.TaskItemId).OnDelete(DeleteBehavior.Cascade);
        });
    }
}
