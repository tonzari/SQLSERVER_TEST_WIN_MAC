using GC_MVC_SQL_WIN_MAC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GC_MVC_SQL_WIN_MAC.Data
{
    public class PantsContext : DbContext
    {
        public PantsContext(DbContextOptions<PantsContext> options) : base(options)
        {

        }

        public DbSet<Pants> Pants { get; set; }
    }
}
