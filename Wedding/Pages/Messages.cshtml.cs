using Microsoft.AspNetCore.Mvc.RazorPages;
using Wedding.Models;

namespace Wedding.Pages {
    public class MessagesModel : PageModel {

        public MessagesModel(IWeddingRepository repository) {
            this.repository = repository;
        }

        private readonly IWeddingRepository repository;

        /// <summary>
        /// ��� ������
        /// </summary>
        public string Groom { get; private set; } = string.Empty;
        /// <summary>
        /// ��� �������
        /// </summary>
        public string Bride { get; private set; } = string.Empty;
        /// <summary>
        /// ���� �������
        /// </summary>
        public DateTime WeddingDate { get; private set; }
        /// <summary>
        /// ��������� �����������
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
