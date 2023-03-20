using System.ComponentModel.DataAnnotations;

namespace HueFes.ViewModels
{
    public class HelpMenuVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
    public class HelpMenuVM_Input
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; }
    }
    public class HelpMenuVM_Detail {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
