namespace HueFes.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }    
        public string? Role { get; set; }
        public bool Status { get; set; }
    }
}
