using HRE.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRE.Infrastructure.Persistence
{
    internal class AppDbContext:DbContext
    {
        internal DbSet<Robot> Robots { get; set; }
        internal DbSet<Gift> Gifts { get; set; }
    }
}
