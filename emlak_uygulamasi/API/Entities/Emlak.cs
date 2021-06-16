using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Emlak")]
    public class Emlak
    {
        public int Id { get; set; }
        public string EmlakTuru { get; set; }
        public int Alan { get; set; }
        public int OdaSayisi { get; set; }
        public string Kat { get; set; }
        public int BinaKati { get; set; }
        public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;
        public MusteriSatici MusteriSatici { get; set; }
        public int MusteriSaticiId { get; set; }

    }
}