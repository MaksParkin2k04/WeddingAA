using System.Net;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Wedding.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Wedding.Data.Initialization {
    public class DatabaseInitializer {
        public static async Task Initialize(ApplicationContext context) {

            await context.Database.EnsureDeletedAsync();

            if (await context.Database.EnsureCreatedAsync()) {

                Models.Wedding wedding = new Models.Wedding {
                    Id = Guid.Parse("AA30CD6F-A134-4613-B6DF-F358A550A280"),
                    Alias = "andrey-amina",
                    Groom = "Андрей",
                    Bride = "Амина",
                    WeddingDate = new DateTime(2025, 07, 18, 16, 00, 0),
                    Data = "18.07.2025 в 16:00",
                    Menu = "Меню разнообразно, поэтому сообщите нам заранее, если у вас есть какие-либо предпочтения или диетические ограничения. После подтверждения вы сможете пройти опрос о своих вкусовых предпочтениях и напитках.",
                    Wishes = "Дорогие гости! Мы создаем вечер, где детали становятся частью большой любви. Просим Вас оставить детей дома и присоединиться к нам, чтобы вместе написать новую страничку нашей истории.",
                    WishesSec = "Мы просим вас не дарить нам цветы, так как мы не успеем насладиться их красотой на все 100%. Мы будем признательны, если вы поможете нам осуществить мечту о путешествии, подарив ваши пожелания в конверте.",
                    Gifts = "Ваше присутствие в день нашей свадьбы - самый значимый подарок для нас! Мы понимаем, что дарить цветы на свадьбу - это традиция, но мы не сможем насладиться их красотой в полной мере...\r\nБудем рады любой другой альтернативе (вино или в денежном эквиваленте).",
                    Info = "Будем благодарны, если вы воздержитесь от криков 'Горько' на празднике, ведь поцелуй — это знак выражения чувств, он не может быть по заказу.",
                    Confirmation = "Пожалуйста, подтвердите свое присутсвие, в анкете ниже, до 01.03.2025",
                    PhotoPeople = "Опубликуйте фото дня нашей свадьбы в соц.сетях с # ",
                    Photo = "images/wedding/photo_5368568198284306315_y.jpg",
                    Description = "Мы рады сообщить Вам, что 18.07.2025 состоится самое главное торжество в нашей жизни - день нашей свадьбы! Приглашаем Вас разделить с нами радость этого незабываемого дня!",
                    Details = "Уважаемые гости! Очень просим вас не покупать букеты цветов, так как забрать цветы домой для нас очень проблематично. Вместо цветов мы предпочли бы бутылочку вина или игристого! А лучшим подарком станут Ваши пожелания в конвертах, с помощью которых мы сможем осуществить свои мечты!",
                    Template = "Default",
                    Planner = new WeddingPlanner() { Name = "Варвара", Surname = "Перегудова", Phone = "+7(964)648-88-41" },

                    WeddingEvents = new List<WeddingEvent>(new WeddingEvent[] {

                        new WeddingEvent{ Title = "Фуршет",Location = "Банкетный зал,  Маленькая Швейцария", Description = "Приглашаем вас угоститься и познакомиться со всеми гостями перед началом торжественного мероприятия", Time = new DateTime(2025, 07, 18, 16, 00, 0), Address = "Гайское ш., 1, Орск", MapData = "https://yandex.ru/map-widget/v1/?um=constructor%3Aa9fd7a52a48482064082cca5c82f07e7f4771fc16a212844bf89c70e474ae196&amp;source=constructor" },
                       
                        new WeddingEvent{ Title = "Выездная регистрация",Location = "Свадебная площадка,  Маленькая Швейцария" , Description = "Приглашаем вас разделить вместе с нами радость создания новой семьи", Time = new DateTime(2025, 07, 18, 16, 30, 0), Address = "Гайское ш., 1, Орск", MapData = "https://yandex.ru/map-widget/v1/?um=constructor%3Aa9fd7a52a48482064082cca5c82f07e7f4771fc16a212844bf89c70e474ae196&amp;source=constructor" },

                        new WeddingEvent{ Title = "Банкет",Location = "Банкетный зал,  Маленькая Швейцария" , Description = "Приглашаем вас отменить наш праздник вместе за столом", Time = new DateTime(2025, 07, 18, 17, 00, 0), Address = "Гайское ш., 1, Орск", MapData = "https://yandex.ru/map-widget/v1/?um=constructor%3Aa9fd7a52a48482064082cca5c82f07e7f4771fc16a212844bf89c70e474ae196&amp;source=constructor" },

                        new WeddingEvent{ Title = "Завершение вечера, праздничный салют",Location = "Уличная площадка,  Маленькая Швейцария" , Description = "Приглашаем вас отменить наш праздник вместе за столом", Time = new DateTime(2025, 07, 18, 22, 30, 0), Address = "Гайское ш., 1, Орск", MapData = "https://yandex.ru/map-widget/v1/?um=constructor%3Aa9fd7a52a48482064082cca5c82f07e7f4771fc16a212844bf89c70e474ae196&amp;source=constructor" },

                    })
                };

                context.Weddings.Add(wedding);
                await context.SaveChangesAsync();
            }
        }
    }
}