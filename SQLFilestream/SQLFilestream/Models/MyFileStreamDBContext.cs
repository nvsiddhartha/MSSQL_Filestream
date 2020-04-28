using Microsoft.EntityFrameworkCore;

namespace SQLFilestream.Models
{
    public partial class MyFileStreamDBContext : DbContext
    {
        public MyFileStreamDBContext()
        {
        }

        public MyFileStreamDBContext(DbContextOptions<MyFileStreamDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MyFileStreamTable> MyFileStreamTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-B979080\\SQLEXPRESS;Database=MyFileStreamDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<MyFileStreamTable>(entity =>
            {
                entity.HasKey(e => e.Fsid);

                entity.HasIndex(e => e.Fsid)
                    .HasName("UQ__MyFileSt__9C4B07379C366A08")
                    .IsUnique();

                entity.Property(e => e.Fsid)
                    .HasColumnName("FSID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fsblob).HasColumnName("FSBLOB");

                entity.Property(e => e.Fsdescription)
                    .HasColumnName("FSDescription")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
