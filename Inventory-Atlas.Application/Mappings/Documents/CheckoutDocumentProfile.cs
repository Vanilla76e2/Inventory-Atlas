using Inventory_Atlas.Application.Mappings.Common;
using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Core.DTOs.Documents;
using Inventory_Atlas.Application.Entities.Base;
using Inventory_Atlas.Application.Entities.Documents;

namespace Inventory_Atlas.Application.Mappings.Documents
{
    public class CheckoutDocumentProfile : DocumentProfile
    {
        public CheckoutDocumentProfile()
        {
            // Маппинг для элемента документа
            CreateMap<CheckoutDocumentItem, CheckoutDocumentItemDto>()
                .ForMember(dest => dest.ItemName,
                            opt => opt.MapFrom(src => src.Item.Name))
                .ForMember(dest => dest.ItemInventoryNumber,
                            opt => opt.MapFrom(src => src.Item.InventoryNumber));

            // Маппинг для самого документа
            CreateMap<CheckoutDocument, CheckoutDocumentDto>()
                .IncludeBase<DocumentEntity, DocumentDto>()
                .ForMember(dist => dist.EmployeeName,
                            opt => opt.MapFrom(src => src.Employee.FullName))
                .ForMember(dist => dist.Items,
                            opt => opt.MapFrom(src => src.Items))
                .ForMember(dist => dist.MatriallyResponibleDisplayName,
                            opt => opt.MapFrom(src => src.MateriallyResponsible == null ? string.Empty : src.MateriallyResponsible.DisplayName));

            CreateMap<CheckoutDocument, CheckoutDocumentListDto>()
                .ForMember(dest => dest.EmployeeName, 
                            opt => opt.MapFrom(src => src.Employee.ShortName))
                .ForMember(dest => dest.ItemsCount, 
                            opt => opt.MapFrom(src => src.Items.Count()))
                .ForMember(dist => dist.MatriallyResponibleDisplayName,
                            opt => opt.MapFrom(src => src.MateriallyResponsible == null ? string.Empty : src.MateriallyResponsible.DisplayName)); ;
        }
    }
}
