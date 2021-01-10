using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mehno_Gavril_Volunteers.Models;

namespace Mehno_Gavril_Volunteers.Data
{
    public class Mehno_Gavril_VolunteersContext : DbContext
    {
        public Mehno_Gavril_VolunteersContext (DbContextOptions<Mehno_Gavril_VolunteersContext> options)
            : base(options)
        {
        }

        public DbSet<Mehno_Gavril_Volunteers.Models.Volunteer> Volunteer { get; set; }

        public DbSet<Mehno_Gavril_Volunteers.Models.Publisher> Publisher { get; set; }

        public DbSet<Mehno_Gavril_Volunteers.Models.Category> Category { get; set; }
    }
}
