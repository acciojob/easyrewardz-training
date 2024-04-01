using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCTestApp.Models;

    public class CustomerContext : IdentityDbContext
    {
        public CustomerContext (DbContextOptions<CustomerContext> options)
            : base(options)
        {
        }

        public DbSet<MVCTestApp.Models.Customer> Customer { get; set; } = default!;
    }
