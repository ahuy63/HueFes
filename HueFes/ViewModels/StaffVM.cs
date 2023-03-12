using HueFes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace HueFes.ViewModels
{
    public class StaffVM
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
    }
    public class StaffVM_Login
    {
        public string Phone { get; set; }
        public string Password { get; set; }
    }
    public class StaffVM_Update
    {
        public string Phone { get; set; }
        public string Name { get; set; }
    }
    public class StaffVM_Activate
    {
        public string Phone { get; set; }
        public string Otp { get; set; }
    }

    public class StaffVM_Create
    {

        public string Phone { get; set; }
        public string Name { get; set; }
        public  string Password;
        public  string Role;
        public  bool Status;

        public StaffVM_Create(string phone, string name)
        {
            Phone = phone;
            Name = name;
            Password = GeneratePassword();
            Role = "Staff";
            Status = false;
        }
        private string GeneratePassword()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var pass = new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return pass;
        }
    }
    public class StaffVM_ChangePassword
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }

        public string? CheckInput(string oldPassword)
        {
            if (OldPassword != oldPassword)
            {
                return "Old Password does not match!!!";
            }
            if (NewPassword != ConfirmNewPassword)
            {
                return "New password and confirm new password does not match!!!";
            }
            if (NewPassword == OldPassword)
            {
                return "New Password must be different from old Password";
            }
            return null;
        }
    }

}
