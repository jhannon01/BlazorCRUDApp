using System.ComponentModel.DataAnnotations;

namespace BlazorCRUDApp.Core.Entities
{
    public class Song
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Artist is required")]
        public string Artist { get; set; } = string.Empty;
    }

}
