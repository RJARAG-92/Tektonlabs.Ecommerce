using Tektonlabs.Ecommerce.Domain.Enums;


namespace Tektonlabs.Ecommerce.Domain.Common
{
    public static class EnumExtensions
    {
        public static async Task<Dictionary<string, string>> ProductStatusToList()
        {
            var lista = Enum.GetValues(typeof(ProductStatus))
                       .Cast<ProductStatus>()
                       .Select(d => (id: Convert.ToString((int)d), name: d.ToString()))
                       .ToList();

            return lista.ToDictionary(keySelector: s => s.id, elementSelector: s => s.name);
        }
    }
}