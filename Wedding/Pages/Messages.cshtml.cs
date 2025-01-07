using Microsoft.AspNetCore.Mvc.RazorPages;
using Wedding.Models;

namespace Wedding.Pages {
    public class MessagesModel : PageModel {

        public MessagesModel(IWeddingRepository repository) {
            this.repository = repository;
        }

        private readonly IWeddingRepository repository;

        /// <summary>
        /// Имя жениха
        /// </summary>
        public string Groom { get; private set; } = string.Empty;
        /// <summary>
        /// Имя невесты
        /// </summary>
        public string Bride { get; private set; } = string.Empty;
        /// <summary>
        /// Дата свадьбы
        /// </summary>
        public DateTime WeddingDate { get; private set; }
        /// <summary>
        /// Свадебные мероприятия
        /// </summary>
        public IReadOnlyList<GuestMessage>? Messages { get; private set; }

        public async Task OnGetAsync(Guid weddingId) {
            Models.Wedding? wedding = await repository.GetById(weddingId);

            if ((wedding != null)) {
                Groom = wedding.Groom;
                Bride = wedding.Bride;
                WeddingDate = wedding.WeddingDate;
                Messages = wedding.Messages;
            }
        }
    }
}
