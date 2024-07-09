using Core_Bookcase.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_Bookcase.Data
{
	public class AppDbContext: DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
		{
		}


		public DbSet<Book> Books {  get; set; }
		public DbSet<Reader> Readers { get; set; }
		public DbSet<Admin> Admins { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Reader>()
				.HasKey(r => r.ReadId);
			modelBuilder.Entity<Book>()
				.HasOne(x => x.Reader)
				.WithMany(r => r.Books)
				.HasForeignKey(x => x.ReadId);
        }
    }
}
