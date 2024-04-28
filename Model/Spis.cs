using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rkprodAPIx.Model
{   //trieda pre Spis
    public class Spis
    {
        [Key]
        public int Id { get; set; }
        public string NazovSpisu { get; set; } = "";    
        public DateTime DatumVytvorenia { get; set; } =DateTime.Now;
        public string MiestoNarodenia { get; set; } = "";

        [ForeignKey("User")]
        public string Username { get; set; } = "";  

    }
}
