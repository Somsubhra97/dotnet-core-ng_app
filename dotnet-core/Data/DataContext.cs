using dotnet_core.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_core.Data
{
    public class DataContext : DbContext
    {
    	public DbSet<Post> Posts { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        	//Database.EnsureCreated();
        }         
              
     }
}