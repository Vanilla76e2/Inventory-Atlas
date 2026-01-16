using Inventory_Atlas.Infrastructure.Mappings.Common;
using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Core.DTOs.Documents;
using Inventory_Atlas.Infrastructure.Entities.Base;
using Inventory_Atlas.Infrastructure.Entities.Documents;

namespace Inventory_Atlas.Infrastructure.Mappings.Documents
{
    public class ReturnDocumentProfile : DocumentProfile
    {
        public ReturnDocumentProfile()
        {
            CreateMap<ReturnDocumentItem, ReturnDocumentItemDto>()
                .ForMember(dest => dest.ItemName,
                            opt => opt.MapFrom(src => src.Item.Name))
                .ForMember(dest => dest.ItemInventoryNumber,
                            opt => opt.MapFrom(src => src.Item.InventoryNumber));

            CreateMap<ReturnDocument, ReturnDocumentDto>()
                .IncludeBase<DocumentEntity, DocumentDto>()
                .ForMember(dest => dest.EmployeeName,
                            opt => opt.MapFrom(src => src.Employee.FullName))
                .ForMember(dest => dest.Items,
                            opt => opt.MapFrom(src => src.Items))
                .ForMember(dist => dist.MatriallyResponibleDisplayName,
                            opt => opt.MapFrom(src => src.MateriallyResponsible == null ? string.Empty : src.MateriallyResponsible.DisplayName)); ;

            CreateMap<ReturnDocument, ReturnDocumentListDto>()
                .IncludeBase<DocumentEntity, DocumentDto>()
                .ForMember(dest => dest.EmployeeName,
                            opt => opt.MapFrom(src => src.Employee.ShortName))
                .ForMember(dest => dest.ItemsCount,
                            opt => opt.MapFrom(src => src.Items.Count()))
                .ForMember(dist => dist.MatriallyResponibleDisplayName,
                            opt => opt.MapFrom(src => src.MateriallyResponsible == null ? string.Empty : src.MateriallyResponsible.DisplayName)); ;
        }
    }
}
