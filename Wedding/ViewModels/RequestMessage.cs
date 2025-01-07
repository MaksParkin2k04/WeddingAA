using System.ComponentModel.DataAnnotations;

namespace Wedding.ViewModels {
    public class RequestMessage {

        /// <summary>
        /// Идентификатор свадьбы
        /// </summary>
        [Required]
        public Guid WeddingId { get; set; }

        /// <summary>
        /// Имя гостя
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ввидите свое имя")]
        [StringLength(256, ErrorMessage = "Длина имени гостя должна быть от 3 до 256 символов")]
        public string? Name { get; set; }

        /// <summary>
        /// Поле определяет придет ли гость на свадьбу
        /// </summary>
        [Required(ErrorMessage = "Отметьте сможете ли вы прийти")]
        public bool? ConfirmationPresence { get; set; }

        /// <summary>
        /// Имя друга гостя
        /// </summary>
        [StringLength(100, ErrorMessage = "Максимальная длина имени друга 100 символов")]
        public string? FriendName { get; set; }

        /// <summary>
        /// Коментарий
        /// </summary>
        [StringLength(3000, ErrorMessage = "Максимальная длина комментария 3000 символов")]
        public string? Comment { get; set; }
    }
}
