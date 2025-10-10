using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Repository.Common;

namespace Inventory_Atlas.Infrastructure.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы с программным обеспечением
    /// </summary>
    public interface ISoftwareRepository : IDatabaseRepository<Software>
    {
        /// <summary>
        /// Получает программное обеспечение по лицензионному ключу
        /// </summary>
        /// <param name="licenceKey">Лицензионный ключ для поиска</param>
        /// <returns>Коллекция программного обеспечения с указанным лицензионным ключом</returns>
        Task<IEnumerable<Software>> GetByLicenceKeyAsync(string licenceKey);

        /// <summary>
        /// Получает программное обеспечение по производителю
        /// </summary>
        /// <param name="vendor">Производитель программного обеспечения</param>
        /// <returns>Коллекция программного обеспечения указанного производителя</returns>
        Task<IEnumerable<Software>> GetByVendorAsync(string vendor);
    }
}