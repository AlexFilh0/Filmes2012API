using Microsoft.EntityFrameworkCore;
using Filmes2012API.Models;

namespace Filmes2012API.Data;

public class Filmes2012APIContext : DbContext
{
    public Filmes2012APIContext(DbContextOptions<Filmes2012APIContext> options)
     : base(options)
     {        
     }

    public DbSet<Filme> Filmes {get; set;} = null!;
}

