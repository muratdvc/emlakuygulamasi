using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Emlak> EmlakKayitlari { get; set; }
        public DbSet<IsletmeSahibi> EmlakIsletmesi { get; set; }
        public DbSet<MusteriSatici> SaticiMusteriler { get; set; }
        public DbSet<MusteriAlici> AliciMusteriler { get; set; }
    }
}