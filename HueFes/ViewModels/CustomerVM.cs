using HueFes.Models;

namespace HueFes.ViewModels
{
    public class CustomerVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
    public class CustomerVM_Login
    {
        public string Phone { get; set; }
        public string OTP { get; set; }
    }
    public class CustomerVM_Create
    {
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public class CustomerVM_Update
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
