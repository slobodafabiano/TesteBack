using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteBack.Model;

namespace TesteBack.Data
{
    public class TesteBackContext : DbContext
    {
        public TesteBackContext (DbContextOptions<TesteBackContext> options)
            : base(options)
        {
        }

        public DbSet<TesteBack.Model.Endereco> Endereco { get; set; } = default!;

        public DbSet<TesteBack.Model.Fornecedor> Fornecedor { get; set; }
    }
}
