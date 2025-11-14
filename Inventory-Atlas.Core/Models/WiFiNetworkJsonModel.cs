
namespace Inventory_Atlas.Core.Models
{
    /// <summary>
    /// Модель параметров Wi-Fi сети в формате JSON.
    /// </summary>
    public class WiFiNetworkJsonModel
    {
        /// <summary>
        /// Диапазон беспроводной сети.
        /// <para/>
        /// Тип <see langword="string"/>?.
        /// </summary>
        public string? Band { get; set; }

        /// <summary>
        /// Наименование беспроводной сети.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// </summary>
        public string? Ssid { get; set; }

        /// <summary>
        /// Пароль беспроводной сети.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// </summary>
        public string? Password { get; set; }
    }


    public class WiFiNetworkPublicModel
    {
        /// <summary>
        /// Диапазон беспроводной сети.
        /// <para/>
        /// Тип <see langword="string"/>?.
        /// </summary>
        public string? Band { get; set; }

        /// <summary>
        /// Наименование беспроводной сети.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// </summary>
        public string? Ssid { get; set; }
    }
}
