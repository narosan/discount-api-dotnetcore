using ingressocom_promocodeAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace ingressocom_promocodeAPI.Repositories
{
    public class CheckoutContext : DbContext
    {
        public CheckoutContext(DbContextOptions<CheckoutContext> options)
            : base(options)
        { }

        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Promocode> Promocodes { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Theatre> Theatres { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }
    }
}