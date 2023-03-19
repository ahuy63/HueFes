namespace HueFes.DomainModels
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int Type_Inoff { get; set; }     // 1: khong ban ve, 2: ban ve
        public int Type_Program { get; set; }   // 1: Tieu diem, 3: Cong dong
        public double Price { get; set; }
        public int Type { get; set; } = 1;                    //1: Event, 2: Location, 3: News
        public ICollection<Show> Shows { get; set; }    
        public ICollection<EventImage> EventImages { get; set; }
    }
}
