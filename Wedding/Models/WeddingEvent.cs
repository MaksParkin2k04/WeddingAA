namespace Wedding.Models {
    /// <summary>
    /// Свадебное мероприятие
    /// </summary>
    public class WeddingEvent {

        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название мероприятия
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Описание мероприятия
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Время проведения мероприятия
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Данные для карты
        /// </summary>
        public string MapData { get; set; } = string.Empty;

        /// <summary>
        /// Адрес места проведения мероприятия
        /// </summary>
        public string Address { get; set; } = string.Empty;

        public string Location {  get; set; } = string.Empty;
    }
}
