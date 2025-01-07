namespace Wedding.Models {
    public class Wedding {

        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Алиас страницы
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Имя жениха
        /// </summary>
        public string Groom { get; set; }

        /// <summary>
        /// Имя невесты
        /// </summary>
        public string Bride { get; set; }

        /// <summary>
        /// Дата свадьбы
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Дата свадьбы
        /// </summary>
        public DateTime WeddingDate { get; set; }

        /// <summary>
        /// Фотография
        /// </summary>
        public string Photo { get; set; }

        /// <summary>
        /// Ссылка на фотографии со свадьбы
        /// </summary>
        public string? LinkPhotos { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Детали
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Шаблон
        /// </summary>
        public string Template { get; set; }

        /// <summary>
        /// Организатор свадьбы
        /// </summary>
        public WeddingPlanner Planner { get; set; }

        /// <summary>
        /// Свадебные мероприятия
        /// </summary>
        public List<WeddingEvent>? WeddingEvents { get; set; }

        /// <summary>
        /// Список сообщений от гостей
        /// </summary>
        public List<GuestMessage>? Messages { get; set; }

        public string Menu { get; set; }

        public string Gifts { get; set; }
        public string Info { get; set; }

        public string Confirmation { get; set; }

        public string PhotoPeople { get; set; }

        public string Wishes { get; set; }

        public string WishesSec { get; set; }
    }
}
