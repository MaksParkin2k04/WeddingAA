namespace Wedding.Models {
    /// <summary>
    /// Сообщение гостя
    /// </summary>
    public class GuestMessage {

        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата отправки
        /// </summary>
        public DateTime DateSending { get; set; }

        /// <summary>
        /// Имя отправителя
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Подтверждение присутствия
        /// </summary>
        public bool? ConfirmationPresence { get; set; }

        /// <summary>
        /// Имя пары
        /// </summary>
        public string? FriendName { get; set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; } = string.Empty;

        /// <summary>
        /// Возвращает текстовое представление свойства ConfirmationPresence
        /// </summary>
        /// <returns>Текстовое представление свойства ConfirmationPresence</returns>
        public string ConfirmationPresenceToText() {
            switch (ConfirmationPresence) {
                case null:
                    return "Неизвестно";
                case true:
                    return "Приду";
                case false:
                    return "Не смогу";
            }
        }
    }
}
