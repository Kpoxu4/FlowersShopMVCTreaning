using FlowersShopMVCTraining.Repository.Enum;
using FlowersShopMVCTraining.Repository.Model;
using FlowersShopMVCTraining.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace FlowersShopMVCTraining.Repository
{
    public class Seed
    {
        
        public void Fill(IServiceProvider serviceProvider, string webRootPath)
        {
            using var service = serviceProvider.CreateScope();

            FillUsers(service);
            FillShopCards(service, webRootPath);

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
        private void FillShopCards(IServiceScope service, string webRootPath)
        {
            var shopCardRepository = service.ServiceProvider.GetService<ShopCardRepository>()!;
            var productDescriptionRepository = service.ServiceProvider.GetService<ProductDescriptionRepository>()!;

            if (!shopCardRepository.Any())
            {
               CreateShopCard(
               shopCardRepository,
               productDescriptionRepository,
               webRootPath,
               "Весенний взгляд",
               "Bouquets1",
               "Bouquets",
               2000,
               30,
               ProductFeatures.DealOfDay | ProductFeatures.Bestseller | ProductFeatures.NewArrival,
               "Этот букет состоит из нежных розово-белых альстромерий, которые создают гармоничное " +
               "сочетание цветов. Зеленые листья и веточки добавляют свежести и живости." +
               " Букет аккуратно упакован в розовую бумагу, придавая ему элегантный вид.");

                CreateShopCard(
                shopCardRepository,
                productDescriptionRepository,
                webRootPath,
                "Букет Нежной Гармонии",
                "Bouquets2",
                "Bouquets",
                1500,
                0,
                ProductFeatures.DealOfDay | ProductFeatures.NewArrival,
                "Букет “Нежной Гармонии” — это воплощение нежности и умиротворения. " +
                "В нем сочетаются пушистые хлопковые шарики, нежные маргаритки и" +
                " лавандовые цветы, создавая атмосферу спокойствия и уюта. Этот букет " +
                "идеально подходит для подарка или для украшения вашего дома. " +
                "Позвольте ему принести в вашу жизнь немного мягкости и радости.");

            }
        }
        private void CreateShopCard(
        ShopCardRepository shopCardRepository,
        ProductDescriptionRepository productDescriptionRepository,
        string webRootPath,
        string name,
        string imageName,
        string catalog,
        decimal price,
        int discount,
        ProductFeatures features,
        string descriptionText)
        {
            var productDescription = new ProductDescription
            {
                Text = descriptionText
            };
            productDescriptionRepository.Create(productDescription);

            var shopCard = new ShopCard
            {
                Name = name,
                ImageName = imageName,
                Catalog = catalog,
                Price = price,
                Discount = discount,
                Features = features,
                ProductDescription = productDescription
            };

            shopCardRepository.Create(shopCard);
            CreateShopCardImage(webRootPath, shopCard);
            shopCardRepository.UpdateNameImage(shopCard);
        }

        private void CreateShopCardImage(string webRootPath, ShopCard shopCard)
        {

            var sourceImagePath = Path.Combine(webRootPath, "img", "forCatalogsSeed", $"{shopCard.ImageName}.jpg");
            var extension = Path.GetExtension(sourceImagePath);
            shopCard.ImageName = shopCard.Catalog + shopCard.Id.ToString();
            var destinationImagePath = Path.Combine(webRootPath, "img", "watch", $"{shopCard.ImageName}{extension}");

            if (File.Exists(sourceImagePath))
            {
                
                File.Copy(sourceImagePath, destinationImagePath, true);
            }
            else
            {
                throw new FileNotFoundException($"Файл изображения '{sourceImagePath}' не найден.");
            }   
        }
    }
}

