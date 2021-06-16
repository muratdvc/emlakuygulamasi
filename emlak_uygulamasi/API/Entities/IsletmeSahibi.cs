namespace API.Entities
{
    public class IsletmeSahibi
    {
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string IsletmeAdi { get; set; }
        public string Yetkili { get; set; }
        public int TelefonNo { get; set; }
        public int Fax { get; set; }
        
    }
}