using Inventory_Atlas.Infrastructure.Entities.Dictionaries;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Inventory_Atlas.Infrastructure.Repository.Dictionaries
{
    /// <summary>
    /// Репозиторий для работы с IpAddress-адресами.
    /// <para/>
    /// Наследуется от <see cref="DatabaseRepository{IpDictionary}"/> и реализует <see cref="IIpAddressRepository"/>.
    /// </summary>
    public class IpAddressRepository : DatabaseRepository<IpDictionary>, IIpAddressRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="IpAddressRepository"/>.
        /// </summary>
        /// <param name="contextProvider">Поставщик контекста базы данных.</param>
        /// <param name="logger">Логгер для репозитория.</param>
        public IpAddressRepository(IDatabaseContextProvider contextProvider, ILogger<IpAddressRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <summary>
        /// Выполняет поиск IpAddress-адресов по заданным фильтрам.
        /// </summary>
        /// <param name="ip">
        /// IpAddress-адрес или часть IpAddress (опционально). 
        /// Если вводится полный IpAddress, выполняется точное сравнение, иначе поиск по подстроке.
        /// </param>
        /// <param name="note">Комментарий или описание IpAddress (опционально, поиск по подстроке, нечувствительно к регистру).</param>
        /// <returns>Список объектов <see cref="IpDictionary"/>, удовлетворяющих фильтрам.</returns>
        public async Task<IEnumerable<IpDictionary>> SearchAsync(string? ip = null, string? note = null)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            var query = context.Set<IpDictionary>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(ip))
            {
                if (IPAddress.TryParse(ip, out var parsed))
                {
                    query = query.Where(e => e.IpAddress.Equals(parsed));
                }
                else
                {
                    query = query.Where(e => EF.Functions.ILike(e.IpAddress.ToString(), $"%{ip}%"));
                }
            }

            if (!string.IsNullOrWhiteSpace(note))
                query = query.Where(e => EF.Functions.ILike(e.Note, $"%{note}%"));

            return await query.ToListAsync();
        }
    }
}
