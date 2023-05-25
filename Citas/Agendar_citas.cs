using System.ComponentModel.DataAnnotations;
namespace Citas
{
    public class Agendar_citas
    {
        [Key]
        public int id { get; set; }
        public string fecha { get; set; }


        public List <Cliente>? cliente { get; set; }
    }
}