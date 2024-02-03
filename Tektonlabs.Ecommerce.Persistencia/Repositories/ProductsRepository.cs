using Dapper;
using Tektonlabs.Ecommerce.Application.Interface.Persistence;
using Tektonlabs.Ecommerce.Domain.Entities;
using Tektonlabs.Ecommerce.Domain.Enums;
using Tektonlabs.Ecommerce.Persistencia.Contexts;

namespace Tektonlabs.Ecommerce.Persistencia.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly DapperContext _context;
        public ProductsRepository(DapperContext context)
        {
            _context = context;
        }


        #region Métodos Asíncronos

        public async Task<Product> InsertAsync(Product product)
        {
            using var connection = _context.CreateConnection();
            var query = @"INSERT INTO dbo.Products([Name],[Stock],[StatusId],[Description],[Price],[FechaCreacion],[UnidadMedida],[Moneda]) 
                                OUTPUT INSERTED.*
                                VALUES (@Name,@Stock,@StatusId,@Description,@Price,@FechaCreacion,@UnidadMedida,@Moneda);
                              ";
            var parameters = new DynamicParameters();
            parameters.Add("Name", product.Name);
            parameters.Add("Stock", product.Stock);
            parameters.Add("StatusId", (int)product.StatusId);
            parameters.Add("Description", product.Description);
            parameters.Add("Price", product.Price);
            parameters.Add("FechaCreacion", DateTime.Now);
            parameters.Add("UnidadMedida", Enum.GetName(typeof(TipoUnidadMedida), product.UnidadMedida));
            parameters.Add("Moneda", Enum.GetName(typeof(TipoMoneda), product.Moneda));

            return await connection.QuerySingleOrDefaultAsync<Product>(query, param: parameters);
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            using var connection = _context.CreateConnection();
            var query = @"UPDATE dbo.Products
                              SET [Name]=@Name,
                                  [Stock]=@Stock,
                                  [StatusId]=@StatusId,
                                  [Description]=@Description,
                                  [Price]=@Price,
                                  [FechaActualizacion]=@FechaActualizacion
                                WHERE ProductId=@ProductId";
            var parameters = new DynamicParameters();
            parameters.Add("ProductId", product.ProductId);
            parameters.Add("Name", product.Name);
            parameters.Add("Stock", product.Stock);
            parameters.Add("StatusId", product.StatusId);
            parameters.Add("Description", product.Description);
            parameters.Add("Price", product.Price);
            parameters.Add("FechaActualizacion", DateTime.Now);

            var result = await connection.ExecuteAsync(query, param: parameters);
            return result > 0;
        }



        public async Task<Product> GetAsync(int id)
        {
            using var connection = _context.CreateConnection();
            var query = "SELECT   ProductId,Name,Stock,StatusId,Description,Price,FechaCreacion,FechaActualizacion,Moneda,UnidadMedida  FROM dbo.Products where ProductId=@ProductId";
            var parameters = new DynamicParameters();
            parameters.Add("ProductId", id);

            return await connection.QuerySingleOrDefaultAsync<Product>(query, param: parameters);
        }
        #endregion
    }
}
