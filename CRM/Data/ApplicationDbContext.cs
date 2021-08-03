using CRM.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<CRMDATA> CRMDATA { get; set; }
        public DbSet<CRMDATAChild> CRMDATAChild { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
