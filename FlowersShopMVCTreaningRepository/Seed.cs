using FlowersShopMVCTraining.Repository.Enum;
using FlowersShopMVCTraining.Repository.Model;
using FlowersShopMVCTraining.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowersShopMVCTraining.Repository
{
    public class Seed
    {
        public void Fill(IServiceProvider serviceProvider)
        {
            using var service = serviceProvider.CreateScope();

            FillUsers(service);

        }

        private void FillUsers(IServiceScope service)
        {
            var userRepository = service.ServiceProvider.GetService<UserRepository>()!;

            if (!userRepository.Any()) 
            {
                var admin = new User
                {
                    UserName = "admin",
                    Password = "$2a$10$LV.a2yacBvzVY8ZEwG/4XeppQMlYLOvSx6uqEA35ppYVAyl5dN9Ra",
                    Phone = "+380663088726",
                    UserRole = UserRole.Admin,
                };
                userRepository.Create(admin);
            }
        }
    }
}
