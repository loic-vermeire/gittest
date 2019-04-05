using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using SC.BL.Domain;

namespace SC.DAL.EF
{
    public class SupportCenterDbContext : DbContext
    {
       
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketResponse> TicketResponses { get; set; }
        public DbSet<HardwareTicket> HardwareTickets { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=127.0.0.1,3306;database=testDb;user=root;password=welcome");
            optionsBuilder.UseLoggerFactory(new LoggerFactory(new[]
            {
                new DebugLoggerProvider((category, level) => category == DbLoggerCategory.Database.Command.Name
                                                             && level == LogLevel.Information)
            }));
            //optionsBuilder.UseLazyLoadingProxies();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 'Ticket.State' as index
            modelBuilder.Entity<Ticket>().HasIndex(t => t.State);
            modelBuilder.Entity<TicketResponse>().HasOne(r => r.Ticket).WithMany(t => t.Responses)
                .HasForeignKey("TicketFK");
        }
    }
}