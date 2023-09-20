using Stocks.Models;
using Microsoft.EntityFrameworkCore;

namespace Stocks.Data;
public class StockContext : DbContext
{
    public StockContext(DbContextOptions<StockContext> opts)
        : base(opts) 
    {
            
    }
    public DbSet<Stock> Stocks { get; set; }
}
