using BillingAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BillingAPI.Data
{

    public class BillingContext : DbContext
    {
        public BillingContext(DbContextOptions<BillingContext> options) : base(options) { }  
        
        public DbSet<Customer> Customers { get; set; }  
        public DbSet<Product> Products{ get; set; }  
        public DbSet<Billing> Billings { get; set; }  
        public DbSet<BillingLine> BillingLines { get; set; }

    }
}
