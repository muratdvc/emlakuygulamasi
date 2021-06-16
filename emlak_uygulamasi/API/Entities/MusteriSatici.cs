using System.Collections.Generic;

namespace API.Entities
{
    public class MusteriSatici
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public string CepTelefonNo { get; set; }
        public string Email { get; set; }
        public string EvTuru { get; set; }
        public ICollection<Emlak> EmlakIlanlari { get; set; }
    }
}