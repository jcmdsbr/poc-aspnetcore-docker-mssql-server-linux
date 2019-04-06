using DAO.Models;
using Microsoft.EntityFrameworkCore;

namespace DAO {
    public class Context : DbContext {
        public Context (DbContextOptions<Context> options) : base (options) { }
        public DbSet<Todo> Todos { get; set; }
        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<Todo> ().HasData (
                new Todo ("buy a car"),
                new Todo ("go to the market"),
                new Todo ("write a magazine"),
                new Todo ("pay netflix")
            );

            base.OnModelCreating (modelBuilder);
        }
    }
}