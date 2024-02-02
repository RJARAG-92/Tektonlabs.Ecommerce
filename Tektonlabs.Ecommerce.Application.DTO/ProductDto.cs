using Tektonlabs.Ecommerce.Domain.Enums;

namespace Tektonlabs.Ecommerce.Application.DTO
{
    public class ProductDto
    {
       public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public TipoUnidadMedida UnidadMedida { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; } = string.Empty;
        public TipoMoneda Moneda { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; } = 0;
        public decimal DiscountAmount { get { return Price * Discount / 100; } }
        public decimal FinalPrice { get { return Price * (100 - Discount) / 100; } }
    }
}
