using HueFes.Models;
using System.ComponentModel.DataAnnotations;

namespace HueFes.ViewModels
{
    public class LocationCategoryVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; } = "Image URL...";
    }

    public class LocationCategoryVM_Input
    {
        [Required]
        public string Title { get; set; }
        public string Image { get; set; }
    }

    public class LocationCategoryVM_Detail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; } = "Image URL...";
        public ICollection<LocationVM> Locations { get; set; }
    }
}
