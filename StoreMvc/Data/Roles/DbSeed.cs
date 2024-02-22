using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace StoreMvc.Data.Roles
{
    public class DbSeed
    {


        public static async Task seedDefault(IServiceProvider serv)
        {
            var usrMgr = serv.GetService<UserManager<IdentityUser>>();
            var roleMgr = serv.GetService<RoleManager<IdentityRole>>();

            //adaugare roluri

            await roleMgr.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleMgr.CreateAsync(new IdentityRole(Roles.User.ToString()));

            //administrator 
            var admin = new IdentityUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                

            };

            var isUserExists = await usrMgr.FindByEmailAsync(admin.Email);
            if (isUserExists is null)
            {//daca nu exista user

                await usrMgr.CreateAsync(admin, "Admin!2");
                await usrMgr.AddToRoleAsync(admin, Roles.Admin.ToString());

            }
        }
    }
}
