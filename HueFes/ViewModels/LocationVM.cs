using HueFes.Models;
using System.ComponentModel.DataAnnotations;

namespace HueFes.ViewModels
{
    public class LocationVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Image { get; set; } = "Image URL...";
    }
    public class LocationVM_Input
    {
        [Required]
        public int LocationCategoryId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Summary is required")]
        public string Summary { get; set; }
        [Required(ErrorMessage = "Content is required")]
        public string? Content { get; set; }
        public string Image { get; set; }
        [Required]
        public string Longtitude { get; set; }
        [Required]
        public string Latitude { get; set; }
    }
}

