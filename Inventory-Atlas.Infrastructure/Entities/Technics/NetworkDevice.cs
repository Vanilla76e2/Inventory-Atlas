using Inventory_Atlas.Core.Models;
using Inventory_Atlas.Infrastructure.Entities.Base;
using Inventory_Atlas.Infrastructure.Entities.Inventory;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Inventory_Atlas.Infrastructure.Entities.Technics
{
    /// <summary>
    /// Сетевое устройство.
    /// <para/>
    /// Наследуется от <see cref="DeviceEntity"/> и реализует <see cref="IHasIpAddress"/>.
    /// Содержит информацию о модели, IpAddress, MAC, настройках Wi-Fi, количестве портов и т.д.
    /// </summary>
    [Table("NetworkDevices", Schema = "Technics")]
    public class NetworkDevice : InventoryItem, IHasIpAddress
    {
        /// <summary>
        /// Модель устройства.
        /// <para/>
        /// Тип: <see langword="string"/>.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("model")]
        public string? Model { get; set; }

        /// <summary>
        /// Производитель устройства.
        /// <para/>
        /// Тип: <see langword="string"/>.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("vendor")]
        public string? Vendor { get; set; }

        /// <summary>
        /// Серийный номер устройства.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("serial_number")]
        public string? SerialNumber { get; set; }

        /// <summary>
        /// IpAddress-адрес устройства.
        /// <para/>
        /// Тип: <see cref="IPAddress"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("ip_address")]
        public IPAddress? IpAddress { get; set; }

        /// <summary>
        /// MAC-адрес устройства.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("mac_address")]
        public string? MacAddress { get; set; }

        /// <summary>
        /// DHCP-настройка.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("dhcp_range")]
        public string? DhcpRange { get; set; }

        /// <summary>
        /// Логин администратора устройства.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("admin_login")]
        public string? AdminLogin { get; set; }

        /// <summary>
        /// Пароль администратора устройства.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("admin_password")]
        public string? AdminPassword { get; set; }

        /// <summary>
        /// Количество физических портов.
        /// <para/>
        /// Тип: <see langword="short"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("port_count")]
        public short? PortCount { get; set; }

        /// <summary>
        /// Признак наличия Wi-Fi.
        /// <para/>
        /// Тип: <see langword="bool"/>.
        /// <para/>
        /// По умолчанию <see langword="false"/>.
        /// </summary>
        [Column("has_wifi")]
        public bool HasWifi { get; set; } = false;

        /// <summary>
        /// Название Wi-Fi сети.
        /// <para/>
        /// Тип: Коллекция <see cref="WiFiNetworksJsonModel"/>?.
        /// </summary>
        [Column("wifi_networks")]
        public List<WiFiNetworkJsonModel> WiFiNetworksJson { get; set; } = new();

        /// <summary>
        /// Пропускная способность сети (в Мбит/с).
        /// <para/>
        /// Тип: <see langword="int"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("network_bandwidth")]
        public int? NetworkBandwidth {  get; set; }
    }
}
