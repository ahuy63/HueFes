using System.ComponentModel.DataAnnotations;

namespace HueFes.ViewModels
{
    public class ShowCategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ShowCategoryVM_Input
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }

    public class ShowCategoryVM_Detail
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
