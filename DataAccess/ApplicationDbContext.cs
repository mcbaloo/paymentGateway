using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {

        }
        public DbSet<Payment> payments { get; set; }
        public DbSet<PaymentState> paymentStates { get; set; }
    }
}
