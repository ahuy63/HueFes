﻿namespace HueFes.Models
{
    public class Location
    {
        public int Id { get; set; }
        public int LocationCategoryId { get; set; }
        public LocationCategory Category { get; set; }

        public string Title { get; set; }
        public string Summary { get; set; }
        public string? Content { get; set; } = "Some HTML code....";
        public string Image { get; set; } = "Image URL...";
        public string Longtitude { get; set; }
        public string Latitude { get; set; }
    }
}
