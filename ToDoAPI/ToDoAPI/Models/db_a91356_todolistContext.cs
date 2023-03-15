using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ToDoAPI.Models
{
    public partial class db_a91356_todolistContext : DbContext
    {
        public db_a91356_todolistContext()
        {
        }

        public db_a91356_todolistContext(DbContextOptions<db_a91356_todolistContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<ToDo> ToDos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=sql8004.site4now.net;Database=db_a91356_todolist;UID=db_a91356_todolist_admin;PWD=Todolistpass1!;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CatDesc).HasMaxLength(100);

                entity.Property(e => e.CatName).HasMaxLength(25);
            });

            modelBuilder.Entity<ToDo>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ToDos)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_ToDos_Categories");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
