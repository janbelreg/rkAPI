using System.ComponentModel.DataAnnotations.Schema;

namespace rkprodAPIx.Model
{
    public class Zaznam
    {
        //trieda pre Zaznam
        public int Id { get; set; }

        [ForeignKey("User")]
        public string Username { get; set; } = "";
        public string Adresa { get; set; } = "";
        public string Adresat { get; set; } = "";
        public DateTime DatumCreate { get; set; } = DateTime.Now; 
        
        public DateTime DatumDue { get; set; }
        public int Stav { get; set; }

        [ForeignKey("Spis")]
        public int SpisId { get; set; }
    }
}
