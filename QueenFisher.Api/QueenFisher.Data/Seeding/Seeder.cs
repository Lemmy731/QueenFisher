using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QueenFisher.Data.Context;
using QueenFisher.Data.Domains;

namespace QueenFisher.Data.Seeding
{
    public class Seeder
    {
      
        public static async Task SeedData(IApplicationBuilder app)
        {
            //Get db context
            var dbContext = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<QueenFisherDbContext>();
            
            if (dbContext.Database.GetPendingMigrations().Any())
            {
                dbContext.Database.Migrate();
            }
            if (dbContext.Users.Any())
            {
                return;
            }
            else
            {
                var baseDir = Directory.GetCurrentDirectory();

                await dbContext.Database.EnsureCreatedAsync();
                //Get Usermanager and rolemanager from IoC container
                var userManager = app.ApplicationServices.CreateScope()
                                              .ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                var roleManager = app.ApplicationServices.CreateScope()
                                                .ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                List<string> roles = new() { "SuperAdmin", "Admin", "Customer" };

                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(new IdentityRole { Name = role });
                }

                var user = new AppUser
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Chidi",
                    LastName = "SuperAdmin",
                    UserName = "Michael",
                    Email = "super@queenfisher.com",
                    PhoneNumber = "08162292349",
                    PhoneNumberConfirmed = true,
                    Gender = Enums.Gender.Male,
                    IsActive = true,
                    PublicId = null,
                    Avatar = "http://placehold.it/32x32",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    EmailConfirmed = true
                    
                };
                await userManager.CreateAsync(user, "Password@123");
                await userManager.AddToRoleAsync(user, roles[0]);

            }

            await dbContext.SaveChangesAsync();
        }

        static string FilePath(string folderName, string fileName)
        {
            return Path.Combine(folderName, fileName);
        }
    }
}
