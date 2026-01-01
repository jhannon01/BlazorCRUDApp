using System.ComponentModel.DataAnnotations;

namespace BlazorCRUDApp.Entities
{
    public class LibrarySong
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Artist is required")]
        public string Artist { get; set; } = string.Empty;
    }

}
