using BasarsoftFirst.congrate;
using BasarsoftFirst.data;
using Microsoft.EntityFrameworkCore;


namespace BasarsoftFirst.data
{
    public class ItemDb : DbContext
    {
        public ItemDb(DbContextOptions<ItemDb> options) : base(options) { }
        public DbSet<Item>Items { get; set; }
        public DbSet<WktModels> WktModels { get; set; } // WktModels DbSet'i



    }
}
