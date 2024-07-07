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
                #region Catalog Bouquets
                
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
                "Букет Летней Радости",
                "Bouquets2",
                "Bouquets",
                1500,
                0,
                ProductFeatures.DealOfDay,
                "Описание продукта: Букет “Летней Радости” — это яркое и теплое сочетание оранжевых гербер и желтых роз. " +
                "Он напоминает о летнем солнечном дне, когда цветы расцветают во всей своей красе. " +
                "Этот букет подарит радость и тепло вашим близким.");

                CreateShopCard(
                shopCardRepository,
                productDescriptionRepository,
                webRootPath,
                "Букет Нежной Гармонии",
                "Bouquets3",
                "Bouquets",
                2500,
                50,
                ProductFeatures.DealOfDay | ProductFeatures.Bestseller | ProductFeatures.NewArrival,
                "Букет “Нежной Гармонии” — это воплощение нежности и умиротворения. " +
                "В нем сочетаются пушистые хлопковые шарики, нежные маргаритки и лавандовые цветы, " +
                "создавая атмосферу спокойствия и уюта. Этот букет идеально подходит для подарка или для украшения вашего дома. " +
                "Позвольте ему принести в вашу жизнь немного мягкости и радости.");

                CreateShopCard(
                shopCardRepository,
                productDescriptionRepository,
                webRootPath,
                "Букет Летней Россыпи",
                "Bouquets4",
                "Bouquets",
                2200,
                10,
                ProductFeatures.NewArrival,
                "Букет “Летней Россыпи” — это яркое и вдохновляющее сочетание желтых тюльпанов, " +
                "белых декоративных цветов и веточек с нежными бутонами. " +
                "Он упакован в бумагу сине-белого цвета и завязан белой атласной лентой. " +
                "Этот букет приносит радость и свежесть, идеально подходит для подарка или для украшения вашего дома.");

                CreateShopCard(
                shopCardRepository,
                productDescriptionRepository,
                webRootPath,
                "Букет Летнего Заката",
                "Bouquets5",
                "Bouquets",
                2200,
                10,
                ProductFeatures.DealOfDay | ProductFeatures.Bestseller | ProductFeatures.NewArrival,
                "Букет “Летнего Заката” — это воплощение тепла и ярких эмоций. " +
                "В нем сочетаются оранжевые розы, желтые герберы и зелень, " +
                "создавая атмосферу летнего вечера. Этот букет идеально подходит для подарка или для украшения вашего дома. " +
                "Позвольте ему принести в вашу жизнь краски и радость.");

                #endregion

                #region ForWhom

                CreateShopCard(
                shopCardRepository,
                productDescriptionRepository,
                webRootPath,
                "Цветочная симфония",
                "ForWhom6",
                "Bouquets",
                2000,
                0,
                ProductFeatures.DealOfDay | ProductFeatures.Bestseller | ProductFeatures.NewArrival,
                "Этот букет состоит из нежных розово-белых альстромерий, " +
                "которые создают гармоничное сочетание цветов. " +
                "Зеленые листья и веточки добавляют свежести и живости. " +
                "Букет аккуратно упакован в розовую бумагу, придавая ему элегантный вид. " +
                "Такой букет станет отличным подарком для любого торжества или просто чтобы поднять настроение любимому человеку.");

                CreateShopCard(
                shopCardRepository,
                productDescriptionRepository,
                webRootPath,
                "Сердце страсти",
                "ForWhom7",
                "Bouquets",
                1500,
                0,
                ProductFeatures.DealOfDay,
                "В этом букете красные розы собраны в форме сердца, " +
                "что делает его идеальным подарком для выражения самых теплых и страстных чувств. " +
                "Цветы аккуратно упакованы в двухцветную бумагу и перевязаны лентой, " +
                "подчеркивающей яркость и романтичность композиции. " +
                "«Сердце страсти» станет великолепным подарком на День святого Валентина, юбилей или любое другое важное событие.");

                CreateShopCard(
                shopCardRepository,
                productDescriptionRepository,
                webRootPath,
                "Страстное Признание",
                "ForWhom8",
                "Bouquets",
                2500,
                10,
                ProductFeatures.DealOfDay | ProductFeatures.Bestseller | ProductFeatures.NewArrival,
                "Великолепная композиция из ярко-красных роз, элегантно завернутая в красно-белую бумагу. " +
                "Этот букет излучает любовь и страсть, " +
                "делая его идеальным подарком для выражения глубоких чувств.");

                CreateShopCard(
                shopCardRepository,
                productDescriptionRepository,
                webRootPath,
                "Романтические Объятия",
                "ForWhom9",
                "Bouquets",
                2200,
                20,
                ProductFeatures.NewArrival,
                "Очаровательный букет в форме сердца из красных роз, " +
                "дополненный натуральной зеленью и мешковиной. " +
                "Эта очаровательная композиция символизирует любовь и романтику, " +
                "идеально подходящая для особого человека.");

                CreateShopCard(
                shopCardRepository,
                productDescriptionRepository,
                webRootPath,
                "Весенняя Гармония",
                "ForWhom10",
                "Bouquets",
                2200,
                30,
                ProductFeatures.DealOfDay | ProductFeatures.Bestseller | ProductFeatures.NewArrival,
                "Этот изысканный букет сочетает в себе нежные розовые гортензии и разноцветные гипсофилы. " +
                "Упакованный в элегантную розовую бумагу, он приносит ощущение свежести и жизненной силы, " +
                "идеально подходя для любого случая.");

                #endregion 

                #region HolidayCollection // TODO НАЗВАНИЕ и Описание дял следуших обьектов


                CreateShopCard(
                shopCardRepository,
                productDescriptionRepository,
                webRootPath,
                "Цветочная симфония",
                "HolidayCollection11",
                "HolidayCollection",
                2200,
                10,
                ProductFeatures.DealOfDay | ProductFeatures.Bestseller | ProductFeatures.NewArrival,
                "Этот букет состоит из нежных розово-белых альстромерий, " +
                "которые создают гармоничное сочетание цветов. " +
                "Зеленые листья и веточки добавляют свежести и живости. " +
                "Букет аккуратно упакован в розовую бумагу, придавая ему элегантный вид. " +
                "Такой букет станет отличным подарком для любого торжества или просто чтобы поднять настроение любимому человеку.");

                CreateShopCard(
                shopCardRepository,
                productDescriptionRepository,
                webRootPath,
                "Сердце страсти",
                "HolidayCollection12",
                "HolidayCollection",
                1900,
                20,
                ProductFeatures.DealOfDay,
                "В этом букете красные розы собраны в форме сердца, " +
                "что делает его идеальным подарком для выражения самых теплых и страстных чувств. " +
                "Цветы аккуратно упакованы в двухцветную бумагу и перевязаны лентой, " +
                "подчеркивающей яркость и романтичность композиции. " +
                "«Сердце страсти» станет великолепным подарком на День святого Валентина, юбилей или любое другое важное событие.");

                CreateShopCard(
                shopCardRepository,
                productDescriptionRepository,
                webRootPath,
                "Страстное Признание",
                "HolidayCollection13",
                "HolidayCollection",
                2600,
                30,
                ProductFeatures.DealOfDay | ProductFeatures.Bestseller | ProductFeatures.NewArrival,
                "Великолепная композиция из ярко-красных роз, элегантно завернутая в красно-белую бумагу. " +
                "Этот букет излучает любовь и страсть, " +
                "делая его идеальным подарком для выражения глубоких чувств.");

                CreateShopCard(
                shopCardRepository,
                productDescriptionRepository,
                webRootPath,
                "Романтические Объятия",
                "HolidayCollection14",
                "HolidayCollection",
                1700,
                0,
                ProductFeatures.NewArrival,
                "Очаровательный букет в форме сердца из красных роз, " +
                "дополненный натуральной зеленью и мешковиной. " +
                "Эта очаровательная композиция символизирует любовь и романтику, " +
                "идеально подходящая для особого человека.");

                CreateShopCard(
                shopCardRepository,
                productDescriptionRepository,
                webRootPath,
                "Весенняя Гармония",
                "HolidayCollection15",
                "HolidayCollection",
                1100,
                5,
                ProductFeatures.DealOfDay | ProductFeatures.Bestseller | ProductFeatures.NewArrival,
                "Этот изысканный букет сочетает в себе нежные розовые гортензии и разноцветные гипсофилы. " +
                "Упакованный в элегантную розовую бумагу, он приносит ощущение свежести и жизненной силы, " +
                "идеально подходя для любого случая.");

                #endregion
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

