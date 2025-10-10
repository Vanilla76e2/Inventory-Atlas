using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Technics
{
    /// <summary>
    /// DTO для источника бесперебойного питания (UPS) как устройства.
    /// <para/>
    /// Тип: <see cref="UpsDto"/>
    /// <para/>
    /// Наследуется от <see cref="DeviceDto"/> и содержит информацию о мощности, автономии и количестве розеток.
    /// </summary>
    public class UpsDto : DeviceDto
    {
        /// <summary>
        /// Мощность UPS в ваттах.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public int? CapacityWatts { get; set; }

        /// <summary>
        /// Время автономной работы в минутах.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public int? Autonomy { get; set; }

        /// <summary>
        /// Количество розеток на UPS.
        /// <para/>
        /// Тип: <see langword="short"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public short? SocketCount { get; set; }
    }
}
