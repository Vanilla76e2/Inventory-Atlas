using Inventory_Atlas.Core.DTOs.Inventory;

namespace Inventory_Atlas.Core.DTOs.Technics
{
    /// <summary>
    /// DTO для сетевого устройства.
    /// <para/>
    /// Тип: <see cref="NetworkDeviceDto"/>
    /// <para/>
    /// Наследуется от <see cref="InventoryItemDto"/> и содержит информацию о модели, вендоре, IP, MAC, портах и Wi-Fi.
    /// </summary>
    public class NetworkDeviceDto : InventoryItemDto
    {
        /// <summary>
        /// Модель сетевого устройства.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? Model { get; set; }

        /// <summary>
        /// Вендор/производитель устройства.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? Vendor { get; set; }

        /// <summary>
        /// Серийный номер устройства.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? SerialNumber { get; set; }

        /// <summary>
        /// IP-адрес устройства.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? IpAddress { get; set; }

        /// <summary>
        /// MAC-адрес устройства.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? MacAddress { get; set; }

        /// <summary>
        /// Диапазон DHCP (если устройство предоставляет DHCP).
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? DhcpRange { get; set; }

        /// <summary>
        /// Количество физических портов.
        /// <para/>
        /// Тип: <see langword="short"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public short? PortCount { get; set; }

        /// <summary>
        /// Пропускная способность сети в Мбит/с.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public int? NetworkBandwidth { get; set; }

        /// <summary>
        /// Признак наличия Wi-Fi.
        /// <para/>
        /// Тип: <see langword="bool"/>
        /// </summary>
        public bool HasWifi { get; set; }

        /// <summary>
        /// Имя Wi-Fi сети (SSID), если есть Wi-Fi.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? WifiName { get; set; }
    }

    /// <summary>
    /// DTO для сетевого устройства с административными данными.
    /// <para/>
    /// Тип: <see cref="NetworkDeviceAdminDto"/>
    /// <para/>
    /// Наследуется от <see cref="NetworkDeviceDto"/> и содержит логин/пароль администратора и пароль Wi-Fi.
    /// </summary>
    public class NetworkDeviceAdminDto : NetworkDeviceDto
    {
        /// <summary>
        /// Логин администратора устройства.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? AdminLogin { get; set; }

        /// <summary>
        /// Пароль администратора устройства.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? AdminPassword { get; set; }

        /// <summary>
        /// Пароль Wi-Fi сети устройства.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? WifiPassword { get; set; }
    }
}
