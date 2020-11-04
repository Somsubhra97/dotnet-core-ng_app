using dotnet_core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dotnet_core.Data
{
    public class DataContext : DbContext
    {
    	public DbSet<Post> Posts { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        	
        } 

 /*     protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.content)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.content)
                    .HasColumnName("content")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
            
        }
*/        
              
     }
}