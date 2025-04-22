

using Microsoft.AspNetCore.Identity;

namespace Presistance.Data.DataSeed
{
    public class DbInitialize : IDbInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _user;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitialize(ApplicationDbContext dbContext , RoleManager<IdentityRole> roleManager , UserManager<User> user )
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _user = user;
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

        public async Task InitializeIdentityAsync()
        {
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
            }

            if (!_user.Users.Any())
            {
                var UserAdmin = new User() 
                {
                    DisplayName = "Admin",
                    UserName = "Admin",
                    Email="Admin@gmail.com",
                    PhoneNumber= "0123456789",
                };

                var UserSuperAdmin = new User()
                {
                    DisplayName = "SuperAdmin",
                    UserName = "SuperAdmin",
                    Email = "SuperAdmin@gmail.com",
                    PhoneNumber = "0123456789",
                };

                await _user.CreateAsync(UserAdmin, "P@ssw0rd!");
                await _user.CreateAsync(UserSuperAdmin, "P@ssw0rd!");

                await _user.AddToRoleAsync(UserAdmin, "Admin");
                await _user.AddToRoleAsync(UserSuperAdmin, "SuperAdmin");
            }
        }
    }
}
