using System;
using API.Entities;

namespace API.DTOs
{
    public class EmlakDto
    {
        public int Id { get; set; }
        public string EmlakTuru { get; set; }
        public int Alan { get; set; }
        public int OdaSayisi { get; set; }
        public string Kat { get; set; }
        public int BinaKati { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
    }
}