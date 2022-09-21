using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCoopkrodus.Models;

namespace MVCoopkrodus.Data
{
    public class MVCoopkrodusContext : DbContext
    {
        public MVCoopkrodusContext (DbContextOptions<MVCoopkrodusContext> options)
            : base(options)
        {
        }

        public DbSet<MVCoopkrodus.Models.GDP> GDP { get; set; }
    }
}
