using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjetoWebMvc.Models
{
    public class ProjetoWebMvcContext : DbContext
    {
        public ProjetoWebMvcContext (DbContextOptions<ProjetoWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<ProjetoWebMvc.Models.Department> Department { get; set; } = default!;
    }
}
