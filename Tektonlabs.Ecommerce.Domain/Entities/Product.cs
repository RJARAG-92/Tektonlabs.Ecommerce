namespace Tektonlabs.Ecommerce.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int StatusId { get; set; } =0;
        public int Stock { get; set; }
        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set;}
        public DateTime FechaActualizacion { get; set; }

    }
}
