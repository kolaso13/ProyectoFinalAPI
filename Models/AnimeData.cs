using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiAnimeProyecto.Models
{
    public class AnimeData
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Provincia { get; set; }
        public string Chapters { get; set; }
        public string Image { get; set; }
        public string Studio { get; set; }
        public string Date { get; set; }
        public string Genre { get; set; }
    }

}