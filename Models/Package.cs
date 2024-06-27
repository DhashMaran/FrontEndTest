namespace FrontEndTest.Models
{
    public class Package
    {

        public List<Item> Items { get; set; }
        public int TotalWeight { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal CourierPrice { get; set; }
    }
}
