using Tektonlabs.Ecommerce.Domain.Enums;


namespace Tektonlabs.Ecommerce.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ProductStatus StatusId { get; set; } = ProductStatus.Active;
        public TipoUnidadMedida UnidadMedida { get; set; } = TipoUnidadMedida.UNIDAD;
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public TipoMoneda Moneda {  get; set; } = TipoMoneda.USD;

        public string Description { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set;}
        public DateTime FechaActualizacion { get; set; }

    }
}
