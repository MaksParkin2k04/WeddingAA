namespace Wedding.Models {
    /// <summary>
    /// Опции отправки электронной почты
    /// </summary>
    public class MailOptions {

        /// <summary>
        /// Адрес электронной почты получателя
        /// </summary>
        public string EmailTo { get; set; } = string.Empty;

        /// <summary>
        /// Адрес электронной почты отправителя
        /// </summary>
        public string EmailFrom { get; set; } = string.Empty;

        /// <summary>
        /// Cервер исходящей почты
        /// </summary>
        public string Host { get; set; } = string.Empty;

        /// <summary>
        /// Порт сервера исходящей почты
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Использовать SSL
        /// </summary>
        public bool UseSsl { get; set; }

        /// <summary>
        /// Логин отправителя
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Пороль отправителя
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
