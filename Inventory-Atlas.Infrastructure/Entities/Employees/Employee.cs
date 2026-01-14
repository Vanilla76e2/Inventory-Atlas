using Inventory_Atlas.Application.Entities.Base;
using Inventory_Atlas.Application.Entities.Documents;
using Inventory_Atlas.Application.Entities.Technics;
using Inventory_Atlas.Application.Entities.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Application.Entities.Employees
{
    /// <summary>
    /// Сотрудник компании.
    /// <para/>
    /// Содержит персональные данные, контактную информацию, отдел и должность,
    /// а также связанные рабочие места и оборудование.
    /// </summary>
    [Table("Employees", Schema = "Employees")]
    public class Employee : SoftDeletable
    {
        /// <summary>
        /// Фамилия сотрудника.
        /// <para/>
        /// Тип: <see cref="string"/>.
        /// <para/>
        /// Обязательное поле, не может быть null.
        /// </summary>
        [Column("surname")]
        public string Surname { get; set; } = null!;

        /// <summary>
        /// Имя сотрудника.
        /// <para/>
        /// Тип: <see cref="string"/>.
        /// <para/>
        /// Обязательное поле, не может быть null.
        /// </summary>
        [Column("firstname")]
        public string Firstname { get; set; } = null!;

        /// <summary>
        /// Отчество сотрудника.
        /// <para/>
        /// Тип: <see cref="string"/>?.
        /// <para/>
        /// Может быть null, если отчество отсутствует.
        /// </summary>
        [Column("patronymic")]
        public string? Patronymic { get; set; }

        /// <summary>
        /// Электронная почта сотрудника.
        /// <para/>
        /// Тип: <see cref="string"/>?.
        /// <para/>
        /// Максимальная длина — 255 символов. Может быть null.
        /// </summary>
        [Column("email")]
        [StringLength(255)]
        public string? Email { get; set; }

        /// <summary>
        /// Номер телефона сотрудника.
        /// <para/>
        /// Тип: <see cref="string"/>?.
        /// <para/>
        /// Максимальная длина — 18 символов. Может быть null.
        /// </summary>
        [Column("phone_number")]
        [StringLength(18)]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Идентификатор отдела сотрудника.
        /// <para/>
        /// Тип: <see cref="int"/>?.
        /// <para/>
        /// Может быть null, если сотрудник не привязан к отделу.
        /// </summary>
        [Column("department_id")]
        public int? DepartmentId { get; set; }

        /// <summary>
        /// Навигационное свойство на отдел сотрудника.
        /// <para/>
        /// Тип: <see cref="Department"/>?.
        /// <para/>
        /// Позволяет получить информацию об отделе, к которому принадлежит сотрудник.
        /// </summary>
        [ForeignKey(nameof(DepartmentId))]
        public virtual Department? Department { get; set; }

        /// <summary>
        /// Должность сотрудника.
        /// <para/>
        /// Тип: <see cref="string"/>?.
        /// <para/>
        /// Может быть null, если должность не указана.
        /// </summary>
        [Column("position")]
        public string? Position { get; set; }

        /// <summary>
        /// Комментарий к сотруднику.
        /// <para/>
        /// Тип: <see cref="string"/>?.
        /// <para/>
        /// Может содержать дополнительные сведения или примечания.
        /// </summary>
        [Column("comment")]
        public string? Comment { get; set; }

        /// <summary>
        /// Флаг, указывающий, является ли сотрудник материально ответственным.
        /// <para/>
        /// Тип: <see langword="bool"/>.
        /// <para/>
        /// По умолчанию <see langword="false"/>
        /// </summary>
        [Column("is_responsible")]
        public bool IsResponsible { get; set; } = false;

        /// <summary>
        /// Дата рождения пользователя.
        /// <para/>
        /// Тип: <see cref="DateTime"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("birth_date")]
        public DateOnly? BirthDate { get; set; }

        /// <summary>
        /// Полное имя сотрудника в формате "Фамилия Имя Отчество".
        /// <para/>
        /// Тип: <see cref="string"/>.
        /// </summary>
        [NotMapped]
        public string FullName => $"{Surname} {Firstname} {(string.IsNullOrWhiteSpace(Patronymic) ? string.Empty : Patronymic)}".Trim();

        /// <summary>
        /// Инициалы сотрудника в формате "Фамилия И. О.".
        /// <para/>
        /// Тип: <see cref="string"/>.
        /// </summary>
        [NotMapped]
        public string ShortName => $"{Surname} {Firstname[0]}. {(string.IsNullOrWhiteSpace(Patronymic) ? string.Empty : Patronymic[0] + ".")}".Trim();

        /// <summary>
        /// Коллекция рабочих мест сотрудника.
        /// <para/>
        /// Тип: <see cref="ICollection{Workplace}"/>.
        /// <para/>
        /// Навигационное свойство для получения всех рабочих мест, связанных с сотрудником.
        /// </summary>
        [InverseProperty(nameof(Workplace.Employee))]
        public virtual ICollection<Workplace> Workplaces { get; set; } = new List<Workplace>();

        /// <summary>
        /// Коллекция записей в журнале обслуживания, которые выполнены сотрудником.
        /// <para/>
        /// Тип: <see cref="ICollection{MaintenanceLog}"/>
        /// Навигационное свойство для получения всех элементов журнала обслуживания, связанных с сотрудником.
        /// </summary>
        [InverseProperty(nameof(MaintenanceLog.Employee))]
        public virtual ICollection<MaintenanceLog> MaintenanceLogs { get; set; } = new List<MaintenanceLog>();

        /// <summary>
        /// Коллекция документов выдачи, связанных с сотрудником.
        /// <para/>
        /// Тип: <see cref="ICollection{CheckoutDocument}"/>.
        /// </summary>
        [InverseProperty(nameof(CheckoutDocument.Employee))]
        public virtual ICollection<CheckoutDocument> CheckoutDocuments { get; set; } = new List<CheckoutDocument>();

        /// <summary>
        /// Коллекция документов возврата, связанных с сотрудником.
        /// <para/>
        /// Тип: <see cref="ICollection{ReturnDocument}"/>.
        /// </summary>
        [InverseProperty(nameof(ReturnDocument.Employee))]
        public virtual ICollection<ReturnDocument> ReturnDocuments { get; set; } = new List<ReturnDocument>();

        /// <summary>
        /// Коллекция документов передачи, где сотрудник является отправителем.
        /// <para/>
        /// Тип: <see cref="ICollection{TransferDocument}"/>.
        /// </summary>
        [InverseProperty(nameof(TransferDocument.FromEmployee))]
        public virtual ICollection<TransferDocument> FromTransferDocuments { get; set; } = new List<TransferDocument>();

        /// <summary>
        /// Коллекция документов передачи, где сотрудник является получателем.
        /// <para/>
        /// Тип: <see cref="ICollection{TransferDocument}"/>.
        /// </summary>
        [InverseProperty(nameof(TransferDocument.ToEmployee))]
        public virtual ICollection<TransferDocument> ToTransferDocuments { get; set; } = new List<TransferDocument>();

        /// <summary>
        /// Коллекция записей о материальной ответственности сотрудника.
        /// <para/>
        /// Тип: <see cref="ICollection{MaterialResponsible}"/>.
        /// <para/>
        /// Навигационное свойство для получения всех объектов, за которые сотрудник является ответственным.
        /// </summary>
        [InverseProperty(nameof(MateriallyResponsible.Employee))]
        public virtual ICollection<MateriallyResponsible> MateriallyResponsibles { get; set; } = new List<MateriallyResponsible>();

        /// <summary>
        /// Коллекция записей об учётных записях сотрудника.
        /// <para/>
        /// Тип: <see cref="ICollection{UserProfile}"/>.
        /// <para/>
        /// Навигационное свойство для получения всех учётных записей принадлежащих пользователю.
        /// </summary>
        [InverseProperty(nameof(UserProfile.Employee))]
        public virtual ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();
    }
}
