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

                #region HolidayCollection 


                CreateShopCard(
                shopCardRepository,
                productDescriptionRepository,
                webRootPath,
                "Объятия зимы",
                "HolidayCollection11",
                "HolidayCollection",
                2200,
                10,
                ProductFeatures.DealOfDay | ProductFeatures.Bestseller | ProductFeatures.NewArrival,
                "Название: “Объятия зимы” Описание: Этот очаровательный букет захватывает суть зимней природы. " +
                "Пушистые хлопковые шарики символизируют первый снегопад, " +
                "яркие красные ягоды и зеленые веточки ели вызывают вечный дух праздничного сезона. " +
                "Нежные золотые веточки добавляют нотку блеска, напоминая о морозном утреннем рассвете.");

                CreateShopCard(
                shopCardRepository,
                productDescriptionRepository,
                webRootPath,
                "Мамины объятия",
                "HolidayCollection12",
                "HolidayCollection",
                1900,
                20,
                ProductFeatures.DealOfDay,
                "“Мамины объятия” Описание: Этот нежный букет из красных роз, " +
                "светло-розовых гвоздик и белых цветов создан с любовью. " +
                "В его центре расположены маленькие квадратные плитки с буквами, " +
                "образующими слово “МАМА”. Этот букет идеально подходит для поздравления мамы с днем рождения, " +
                "8 марта или просто для того, чтобы сказать ей, как она важна для вас. " +
                "Он упакован в рыболовную сетку, добавляя нотку оригинальности и теплоты.");

                CreateShopCard(
                shopCardRepository,
                productDescriptionRepository,
                webRootPath,
                "Радужные объятия",
                "HolidayCollection13",
                "HolidayCollection",
                2600,
                30,
                ProductFeatures.DealOfDay | ProductFeatures.Bestseller | ProductFeatures.NewArrival,
                "“Радужные объятия” Описание: Этот великолепный букет – настоящее цветочное путешествие. " +
                "В нем собраны яркие розы, нежные гвоздики, белые цветы и солнечные оттенки. " +
                "Букет представлен в круглой светло-розовой коробке с розовой лентой. " +
                "Он словно переполнен радугой, наполняя пространство вокруг яркими красками. " +
                "Это идеальный подарок для тех, кто ценит красоту и эмоции, которые цветы могут подарить. ");

                CreateShopCard(
                shopCardRepository,
                productDescriptionRepository,
                webRootPath,
                "Весенняя Рапсодия",
                "HolidayCollection14",
                "HolidayCollection",
                1700,
                0,
                ProductFeatures.NewArrival,
                "Букет из красных и белых тюльпанов Весенняя Рапсодия - это воплощение свежести и нежности. " +
                "Этот букет объединяет в себе сочные оттенки красного и белого, символизируя радость и чистоту. " +
                "Зеленые листья тюльпанов добавляют букету природную свежесть и делают его ярким акцентом любого праздника или события. " +
                "Этот букет прекрасно подойдет для поздравлений с праздником, днем рождения или просто чтобы выразить свою заботу и внимание.");

                CreateShopCard(
                shopCardRepository,
                productDescriptionRepository,
                webRootPath,
                "Магия Пионов",
                "HolidayCollection15",
                "HolidayCollection",
                1100,
                5,
                ProductFeatures.DealOfDay | ProductFeatures.Bestseller | ProductFeatures.NewArrival,
                " Этот великолепный букет состоит из нежных пионов, окруженных мелкими, но яркими цветами гипсофилы, создающими волшебное сочетание. " +
                "Розовый и фиолетовый цвета придают композиции особую утонченность, " +
                "делая его идеальным подарком для любого случая.");

                #endregion

                #region Presents 


                CreateShopCard(
                shopCardRepository,
                productDescriptionRepository,
                webRootPath,
                "Сладкая Радость",
                "Presents16",
                "Presents",
                2200,
                10,
                ProductFeatures.DealOfDay | ProductFeatures.Bestseller | ProductFeatures.NewArrival,
                "Этот уникальный букет представляет собой сочетание нежных белых тюльпанов и разнообразных сладостей, " +
                "красиво упакованных в пурпурную бумагу и украшенных разноцветными лентами. Восхитительный подарок, " +
                "который удивит и порадует любого сладкоежку, добавив нотку праздника в любой день. " +
                "Букет Сладкая Радость идеально подходит для особых случаев или просто для того, " +
                "чтобы порадовать любимого человека неожиданным сюрпризом");

                CreateShopCard(
                shopCardRepository,
                productDescriptionRepository,
                webRootPath,
                "Радужные объятия”",
                "Presents17",
                "Presents",
                1900,
                20,
                ProductFeatures.DealOfDay,
                "Этот великолепный букет – настоящее цветочное путешествие. " +
                "В нем собраны яркие розы, нежные гвоздики, " +
                "белые цветы и солнечные оттенки. Букет представлен в круглой светло-розовой коробке с розовой лентой. " +
                "Он словно переполнен радугой, наполняя пространство вокруг яркими красками. " +
                "Это идеальный подарок для тех, кто ценит красоту и эмоции, которые цветы могут подарить.");

                CreateShopCard(
                shopCardRepository,
                productDescriptionRepository,
                webRootPath,
                "Цветочное вдохновение",
                "Presents18",
                "Presents",
                2600,
                30,
                ProductFeatures.DealOfDay | ProductFeatures.Bestseller | ProductFeatures.NewArrival,
                "Этот букет – источник вдохновения и радости. В нем собраны яркие розы, нежные гвоздики, " +
                "белые цветы и солнечные оттенки. Букет представлен в круглой светло-розовой коробке с розовой лентой. " +
                "Он словно переполнен радугой ароматов, наполняя пространство вокруг неповторимыми формами, оттенками и ароматом. " +
                "Это идеальный подарок для тех, кто ценит красоту и эмоции, которые цветы могут подарить");

                CreateShopCard(
                shopCardRepository,
                productDescriptionRepository,
                webRootPath,
                "Фруктово-цветочная нежность",
                "Presents19",
                "Presents",
                1700,
                0,
                ProductFeatures.NewArrival,
                "Этот уникальный букет сочетает в себе яркость свежих ягод и изящество нежных цветов, " +
                "создавая гармоничное сочетание вкусов и ароматов. " +
                "Красные клубники и голубика добавляют сочные нотки," +
                " которые прекрасно контрастируют с изысканными розами и элегантными лилиями. " +
                "Зеленая листва и нежные веточки создают завершенный и свежий вид композиции. " +
                "Этот букет идеально подойдет для романтических свиданий, юбилеев и особых моментов, " +
                "которые хочется сделать незабываемыми. Позвольте этому букету подарить радость и удивление вашим близким!");

                CreateShopCard(
                shopCardRepository,
                productDescriptionRepository,
                webRootPath,
                "Сладкий рай",
                "Presents20",
                "Presents",
                1100,
                5,
                ProductFeatures.DealOfDay | ProductFeatures.Bestseller | ProductFeatures.NewArrival,
                "Этот оригинальный букет из сладостей покорит сердце любого сладкоежки! " +
                "Внутри вы найдете разнообразие любимых лакомств: шоколадные конфеты, " +
                "батончики и вафли, которые создают настоящий фейерверк вкусов. " +
                "Упакованный в яркую и праздничную обертку, букет выглядит аппетитно и празднично, " +
                "делая его идеальным подарком для дня рождения, юбилея или просто как знак внимания. " +
                "Этот букет — отличный способ поднять настроение и сделать любой день особенным. " +
                "Позвольте себе или своим близким насладиться моментом сладкого блаженства!");

                #endregion

                #region Roses 


                CreateShopCard(
                shopCardRepository,
                productDescriptionRepository,
                webRootPath,
                "Вечная страсть",
                "Roses21",
                "Roses",
                2200,
                10,
                ProductFeatures.DealOfDay | ProductFeatures.Bestseller | ProductFeatures.NewArrival,
                "Букет Вечная страсть представляет собой роскошное собрание красных роз, " +
                "символизирующих глубину чувств и страсти. Красные розы, идеально подобранные по размеру и свежести, " +
                "создают потрясающий визуальный эффект и насыщенный аромат. " +
                "Этот букет — идеальный подарок для выражения любви, признания в чувствах или празднования особенного события. " +
                "Упакованные в элегантную обертку, эти розы добавят нотку романтики и изысканности в любой момент. " +
                "Подарите Вечную страсть и позвольте этому букету рассказать о самых сокровенных чувствах!");

                CreateShopCard(
                shopCardRepository,
                productDescriptionRepository,
                webRootPath,
                "Нежная мечта",
                "Roses22",
                "Roses",
                1900,
                20,
                ProductFeatures.DealOfDay,
                "Букет Нежная мечта — это воплощение утонченной элегантности и романтики. " +
                "Собранный из восхитительных розовых роз, этот букет привлекает внимание своим мягким цветом и нежным ароматом. " +
                "Розовые розы символизируют грацию, благодарность и восхищение, " +
                "делая этот букет идеальным выбором для выражения самых искренних чувств. " +
                "Упакованные в стильную обертку, эти цветы подарят радость и умиротворение своему получателю. " +
                "Нежная мечта станет прекрасным подарком для любого случая, будь то день рождения, годовщина или просто знак внимания. " +
                "Подарите этот букет и позвольте ему рассказать о вашей заботе и нежности.");

                CreateShopCard(
                shopCardRepository,
                productDescriptionRepository,
                webRootPath,
                "Золотое очарование",
                "Roses23",
                "Roses",
                2600,
                30,
                ProductFeatures.DealOfDay | ProductFeatures.Bestseller | ProductFeatures.NewArrival,
                "Букет Золотое очарование — это воплощение солнечного света и радости. " +
                "Составленный из прекрасных желтоватых роз, он символизирует дружбу, счастье и новые начинания. " +
                "Этот букет будет идеальным подарком для того, чтобы выразить восхищение и благодарность, " +
                "добавить ярких красок в особый день или просто поднять настроение. " +
                "Желтоватые розы в сочетании с зелеными листьями создают гармоничный и живой образ, " +
                "который наполняет сердце теплом и позитивом. Упакованный в изысканную обертку, " +
                "букет Золотое очарование станет великолепным украшением любого праздника и принесет радость своему получателю.");

                CreateShopCard(
                shopCardRepository,
                productDescriptionRepository,
                webRootPath,
                "Розы амурские",
                "Roses24",
                "Roses",
                1700,
                0,
                ProductFeatures.NewArrival,
                "Белые и красные розы в этом букете символизируют страсть и чистоту, создавая изысканное сочетание красок и эмоций.");

                CreateShopCard(
                shopCardRepository,
                productDescriptionRepository,
                webRootPath,
                "Розовый рассвет",
                "Presents25",
                "Presents",
                1100,
                5,
                ProductFeatures.DealOfDay | ProductFeatures.Bestseller | ProductFeatures.NewArrival,
                "Этот нежный и изящный букет представляет собой воплощение утреннего рассвета, " +
                "где белые и красные розы переплетаются в прекрасном танце света и тени. " +
                "Белые розы символизируют чистоту и нежность, в то время как красные розы воплощают страсть и силу чувств. " +
                "Вместе они создают атмосферу гармонии и любви, напоминая о важности каждого момента в нашей жизни.");

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

