using System.Collections.Generic;

namespace API.DTOs
{
    public class MusteriSaticiDto
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public string CepTelefonNo { get; set; }
        public string Email { get; set; }
        public string EvTuru { get; set; }
        public ICollection<EmlakDto> EmlakIlanlari { get; set; }
    }       
}