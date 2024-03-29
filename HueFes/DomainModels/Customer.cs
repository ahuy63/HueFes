﻿namespace HueFes.DomainModels
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Role { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

    }
}
