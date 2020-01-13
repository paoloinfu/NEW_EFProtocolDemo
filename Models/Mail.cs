using System.ComponentModel.DataAnnotations;
using System;

namespace EFProtocolDemo
{
    public class Mail
    {
        [Key]
        public string ProtId { get; set; }
        public DateTime DataInvio { get; set; }
        public DateTime? DataRicezione { get; set; }
        public Tipo? Tipo { get; set; }
        public string Mittente { get; set; }
        public string Destinatario { get; set; }
        public string Oggetto { get; set; }
        public int Allegati { get; set; }
  
        
    }
    public enum Tipo
    {
        Entrata = 1,
        Uscita = 2,
        Interna = 3
    }

   


   

}