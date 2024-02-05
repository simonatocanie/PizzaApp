namespace PizzaApp.BusinessLogic.Models.ProductSizes
{
    public class ProductSizeCreatedDto
    {
        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int Counter { get; set; }
    }
}