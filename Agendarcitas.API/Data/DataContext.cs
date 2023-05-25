using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Citas;

    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Citas.Agendar_citas> Agendar_citas { get; set; } = default!;

        public DbSet<Citas.Cliente>? Clientes { get; set; }
    }
