using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tektonlabs.Ecommerce.Common.Enums;

namespace Tektonlabs.Ecommerce.Common.Extensions
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