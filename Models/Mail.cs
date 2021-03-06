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

        public void GenerateId(int mailNumber)
        {
            var stringFirstLetter = Mittente.Substring(0, 1);
            if (DataInvio != null)
            {
                var stringDate = DataInvio.ToString("ddMMyyyyHHmm");
                var stringId = mailNumber + "_" + stringDate + stringFirstLetter;
                ProtId = stringId;
            }
            else
            {
                var stringDate = DataRicezione?.ToString("ddMMyyyyHHmm");
                var stringId = mailNumber + "_" + stringDate + stringFirstLetter;
                ProtId = stringId;
            }
            //var stringDate = DataInvio.ToString("ddMMyyyyHHmm");
            //var stringId = mailNumber +"_"+ stringDate + stringFirstLetter;
            //ProtId = stringId;
        }
    }
    public enum Tipo
    {
        Entrata = 1,
        Uscita = 2,
        Interna = 3
    }



   


   

}