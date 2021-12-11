using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Authorization;

using BAKERY_WEB_APPLICATION.Models;

namespace BAKERY_WEB_APPLICATION.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BakedGood> BakedGoods { get; set; }

        public DbSet<BakeryWorker> BakeryWorkers { get; set; }
    
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
    }
}
