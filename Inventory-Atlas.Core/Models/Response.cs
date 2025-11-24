namespace Inventory_Atlas.Core.Models
{
    /// <summary>
    /// Модель ответа сервиса.
    /// </summary>
    /// <typeparam name="T">Тип отвечающего сервиса.</typeparam>
    public class Response<T>
    {
        /// <summary>
        /// Флаг успешноси операции.
        /// <para/>
        /// Тип: <see langword="bool"/>.
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Сообщение с пояснением о провале операции.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>
        /// </summary>
        public string? Error { get; set; }

        /// <summary>
        /// Данные объекта с которым проводилась операция.
        /// <para/>
        /// Тип: <see cref="T"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        public T? Data { get; set; }
        
        /// <summary>
        /// Метод возвращающий ответ об успехе.
        /// </summary>
        /// <param name="data">Объект в результате операции.</param>
        /// <returns><see cref="Response{T}"/>.</returns>
        public static Response<T> Ok(T? data) =>
            new() { IsSuccess = true, Data = data };

        /// <summary>
        /// Метод возвращающий ответ о провеле.
        /// </summary>
        /// <param name="error">Пояснение о провале.</param>
        /// <returns><see cref="Response{T}"/>.</returns>
        public static Response<T> Fail(string error) =>
            new() { IsSuccess = false, Error = error };
    }
}
