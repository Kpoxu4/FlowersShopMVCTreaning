namespace FlowersShopMVCTraining.Models
{
    public class CatalogViewModel
    {
        public List<ShopCardViewModel> CatalogCards { get; set; }
        public Dictionary<int, string> CardImages { get; set; }
        public string CatalogName { get; set; } 
    }
}
