namespace Tektonlabs.Ecommerce.Application.DTO
{
    public class ProductDto
    {
       public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Status { get; set; }=false;
        public int Stock { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
