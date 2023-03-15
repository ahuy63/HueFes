namespace HueFes.ViewModels
{
    public class BaoCaoVM
    {
        public List<BaoCaoDetailsVM> BaoCaoDetails { get; set; }
    }
    public class BaoCaoDetailsVM
    {
        public string EventName { get; set; }
        public int SoLuongVe { get; set; }
    }
}
