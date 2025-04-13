

namespace Presistance.Data.DataSeed
{
    public class DbInitialize : IDbInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public DbInitialize(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task InitializeAsync()
        {
            try
            {


                if (_dbContext.Database.GetPendingMigrations().Any())
                {

                    await _dbContext.Database.MigrateAsync();

                    if (!_dbContext.ProductBrands.Any())
                    {
                        // E:\Asp.net route\My Tasks\E - CommerceApi\Presistance\Data\DataSeed\brands.json
                        var ProductBrandFile = await File.ReadAllTextAsync(@"..\Presistance\Data\DataSeed\brands.json");
                        var types = JsonSerializer.Deserialize<List<ProductBrand>>(ProductBrandFile);
                        if (types is not null && types.Any())
                        {
                            await _dbContext.AddRangeAsync(types);
                            await _dbContext.SaveChangesAsync();
                        }
                    }


                    if (!_dbContext.ProductTypes.Any())
                    {
                        //E:\Asp.net route\My Tasks\E-Commerce\infrastruction\Presistance\Data\DataSeed\types.json

                        var ProductTypesFile = await File.ReadAllTextAsync(@"..\Presistance\Data\DataSeed\types.json");
                        var types = JsonSerializer.Deserialize<List<ProductType>>(ProductTypesFile);
                        if (types is not null && types.Any())
                        {
                            await _dbContext.AddRangeAsync(types);
                            await _dbContext.SaveChangesAsync();
                        }
                    }

                    if (!_dbContext.Products.Any())
                    {
                        //E:\Asp.net route\My Tasks\E-Commerce\infrastruction\Presistance\Data\DataSeed\types.json
                        var ProductFile = await File.ReadAllTextAsync(@"..\Presistance\Data\DataSeed\products.json");
                        var types = JsonSerializer.Deserialize<List<Product>>(ProductFile);
                        if (types is not null && types.Any())
                        {
                            await _dbContext.AddRangeAsync(types);
                            await _dbContext.SaveChangesAsync();
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
