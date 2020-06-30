using System;
using ASPNetCoreMySqlEntityFrameWork.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASPNetCoreMySqlEntityFrameWork.Models
{
    public partial class MusicStoreContext : DbContext
    {
        public MusicStoreContext(){}

        public MusicStoreContext(DbContextOptions<MusicStoreContext> options)
            : base(options){}

        public virtual DbSet<Album> Albums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;database=library;user=root;password=P@ssw0rd;old guids=true;SslMode=None");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasKey("Id");
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArtistName).IsRequired();

                entity.Property(e => e.Genre).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
