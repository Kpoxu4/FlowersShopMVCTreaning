namespace FlowersShopMVCTraining.Models
{
    public class MainIndexViewModel
    {
        public List<ShopCardViewModel> SliderCards { get; set; }
        public string? MessageForUser { get; set; }
        public Dictionary<int, string> CardImages { get; set; }
    }
}

