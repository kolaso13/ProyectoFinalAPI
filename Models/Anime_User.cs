using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiAnimeProyecto.Models
{
    public class Anime_User
    {
        [Key]
        public int FavoritoId { get; set; }
        [Required]
        [ForeignKey("AnimeData")]
        public string AnimeName { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UsuarioId { get; set; }

        //PROPIEDADES DE NAVEGACIÓN
        [System.Text.Json.Serialization.JsonIgnore]
        public AnimeData AnimeData { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public User User { get; set; }
    }


}