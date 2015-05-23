using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PenStore.Domain.Entities;
using System.Data.Entity;
using PenStore.Domain.Abstract;

namespace PenStore.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Pen> Pens { get; set; }
    }
}
