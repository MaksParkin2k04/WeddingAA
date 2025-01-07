using Microsoft.EntityFrameworkCore;

namespace Wedding.Models {
    /// <summary>
    /// Организатор свадьбы
    /// </summary>
    [Owned]
    public class WeddingPlanner {

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; } = string.Empty;

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; } = string.Empty;
    }
}
