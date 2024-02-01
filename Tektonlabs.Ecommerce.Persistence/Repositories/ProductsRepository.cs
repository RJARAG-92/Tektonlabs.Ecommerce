using Dapper; 
using Tektonlabs.Ecommerce.Application.Interface.Persistence;
using Tektonlabs.Ecommerce.Domain.Entities;
using Tektonlabs.Ecommerce.Persistence.Contexts;

namespace Tektonlabs.Ecommerce.Persistence.Repositories
{
    public class ProductsRepository: IProductsRepository
    {
        private readonly DapperContext _context;

        public  ProductsRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetAsync(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "SELECT   ProductId,Name,Stock,StatusId,Description,Price,FechaCreacion,FechaActualizacion  FROM Products";
                var product = await connection.QuerySingleAsync<Product>(query);
                return product;
            }
        }

        public async Task<bool> InsertAsync(Product product)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    //using var connection = new SqlConnection("Data Source=RICARDOJG;Initial Catalog=db_ecommerce;Integrated Security=True;");

                    var query = "INSERT INTO DBO.Products([Name],[Stock],[StatusId],[Description],[Price],[FechaCreacion]) VALUES (@Name,@Stock,@StatusId,@Description,@Price,@FechaCreacion)";
                    //var parameters = new DynamicParameters();
                    //parameters.Add("Name", product.Name);
                    //parameters.Add("Stock", product.Stock);
                    //parameters.Add("StatusId", product.StatusId);
                    //parameters.Add("Description", product.Description);
                    //parameters.Add("Price", product.Price);
                    //parameters.Add("FechaCreacion", DateTime.Now);

                    //var result = await connection.ExecuteAsync(query, param: parameters);
                    product = new Product() { Name = "Test2", Stock = 10, StatusId = 3, Description = "tesss", Price = 50 };

                    var result = await connection.ExecuteAsync(query, new
                    {
                        product.Name,
                        product.Stock,
                        product.StatusId,
                        product.Description,
                        product.Price,
                        FechaCreacion = DateTime.Now
                    });

                    return result > 0;
                }
            }
            catch (Exception eex)
            {
                Console.WriteLine(eex.Message);
                return false;
            }
            
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
