using System.ComponentModel.DataAnnotations;

namespace HueFes.ViewModels
{
    public class NewsVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }

    }
    public class NewsVM_Input
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; }
        public string ImageURL { get; set; }
    }
    public class NewsVM_Details
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public string ImageURL { get; set; }
    }
}
