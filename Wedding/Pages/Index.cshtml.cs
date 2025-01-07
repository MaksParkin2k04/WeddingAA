using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Wedding.Models;
using Wedding.Services;
using Wedding.ViewModels;

namespace Wedding.Pages {
    public class IndexModel : PageModel {

        public IndexModel(IWeddingRepository repository, ISendMail sendMail) {
            this.repository = repository;
            this.sendMail = sendMail;
        }

        private readonly IWeddingRepository repository;
        private readonly ISendMail sendMail;

        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid WeddingId { get; set; }

        /// <summary>
        /// Алиас страницы
        /// </summary>
        public string Alias { get; private set; }

        /// <summary>
        /// Имя жениха
        /// </summary>
        public string Groom { get; private set; }

        /// <summary>
        /// Имя невесты
        /// </summary>
        public string Bride { get; private set; }

        /// <summary>
        /// Дата свадьбы
        /// </summary>
        
   

  

        /// <summary>
        /// Дата свадьбы
        /// </summary>
        public WeddingDate WeddingDate { get; private set; }

        /// <summary>
        /// Фотография
        /// </summary>
        public string Photo { get; private set; }

        /// <summary>
        /// Ссылка на фотографии со свадьбы
        /// </summary>
        public string? LinkPhotos { get; private set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Детали
        /// </summary>
        public string Details { get; private set; }

        /// <summary>
        /// Шаблон
        /// </summary>
        public string Template { get; private set; }

        /// <summary>
        /// Организатор свадьбы
        /// </summary>
        public WeddingPlanner Planner { get; private set; }

        /// <summary>
        /// Свадебные мероприятия
        /// </summary>
        public IReadOnlyList<WeddingEvent> WeddingEvents { get; private set; }


        public string Menu { get; private set; }

        public string Data { get; private set; }

        public string Gifts { get; private set; }

        public string Info { get; private set; }

        public string Confirmation { get; private set; }

        public string PhotoPeople { get; private set; }

        public string Wishes { get; private set; }

        public string WishesSec {  get; private set; }

        public async Task OnGetAsync(string alias) {
            Models.Wedding? wending = await repository.GetByAlias(alias);

            if (wending != null) {
                WeddingId = wending.Id;
                Alias = wending.Alias;
                Groom = wending.Groom;
                Bride = wending.Bride;
                WeddingDate = new WeddingDate(wending.WeddingDate);
                Photo = wending.Photo;
                LinkPhotos = wending.LinkPhotos;
                Description = wending.Description;
                Details = wending.Details;
                Template = wending.Template;
                Planner = wending.Planner;
                WeddingEvents = wending.WeddingEvents.OrderBy(w => w.Time).ToArray();

                Menu = wending.Menu;
                Data = wending.Data;
                Gifts = wending.Gifts;
                Wishes = wending.Wishes;
                WishesSec = wending.WishesSec;
                Info = wending.Info;
                Confirmation = wending.Confirmation;
                PhotoPeople = wending.PhotoPeople;
                
            }
        }

        public async Task<IActionResult> OnPostAsync(RequestMessage requestMessage) {

            ResponseMessage? responseMessage = null;

            if (ModelState.IsValid == false) {
                string[] errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToArray();
                responseMessage = new ResponseMessage("Ошибка", errors);
            } else {

                Models.Wedding? wending = await repository.GetById(requestMessage.WeddingId);

                if (wending == null) {
                    responseMessage = new ResponseMessage("Ошибка", new string[] { "Свадьба не найдена" });
                } else {
                    try {

                        GuestMessage message = new GuestMessage() {
                            Name = requestMessage.Name != null ? requestMessage.Name : string.Empty,
                            DateSending = DateTime.Now,
                            ConfirmationPresence = requestMessage.ConfirmationPresence,
                            FriendName = requestMessage.FriendName != null ? requestMessage.FriendName : string.Empty,
                            Comment = requestMessage.Comment != null ? requestMessage.Comment : string.Empty
                        };

                        wending.Messages.Add(message);
                        // Сохранение в базу данных
                        await repository.Update(wending);


                        // Отправка почтового сообщения
                        StringBuilder builder = new StringBuilder();
                        builder.AppendLine(requestMessage.Name);
                        builder.AppendLine(requestMessage.ConfirmationPresence!.Value ? "Приду" : "Не смогу прийти");
                        if (!string.IsNullOrEmpty(requestMessage.FriendName)) {
                            builder.AppendLine($"Со мной будет {requestMessage.FriendName}");
                        }
                        if (!string.IsNullOrEmpty(requestMessage.Comment)) {
                            builder.AppendLine(requestMessage.Comment);
                        }

                        builder.AppendLine();
                        builder.AppendLine($"Сообщение создано {message.DateSending.ToString("dd.MM.yyyy HH-mm")}");
                        builder.AppendLine($"Все сообщения можно посмотреть по ссылке:  https://wedding-56.ru/messages/{wending.Id.ToString("N")}");

                        await sendMail.SendMessage(builder.ToString());

                        responseMessage = new ResponseMessage("Сообщение сохранено");
                    } catch (Exception) {
                        responseMessage = new ResponseMessage("Ошибка", new string[] { "При сохранении сообщения произошла ошибка. Попробуйте отправить сообщение позже." });
                    }
                }


            }

            return new JsonResult(responseMessage);
        }
    }
}


