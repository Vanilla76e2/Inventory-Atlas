using Inventory_Atlas.Infrastructure.Mappings.Common;
using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Core.DTOs.Documents;
using Inventory_Atlas.Infrastructure.Entities.Base;
using Inventory_Atlas.Infrastructure.Entities.Documents;

namespace Inventory_Atlas.Infrastructure.Mappings.Documents
{
    public class TransferDocumentProfile : DocumentProfile
    {
        public TransferDocumentProfile()
        {
            CreateMap<TransferDocumentItem, TransferDocumentItemDto>()
                .ForMember(dest => dest.ItemName,
                            opt => opt.MapFrom(src => src.Item.Name))
                .ForMember(dest => dest.ItemInventoryNumber,
                            opt => opt.MapFrom(src => src.Item.InventoryNumber));

            CreateMap<TransferDocument, TransferDocumentDto>()
                .IncludeBase<DocumentEntity, DocumentDto>()
                .ForMember(dest => dest.FromEmployeeName,
                            opt => opt.MapFrom(src => src.FromEmployee.FullName))
                .ForMember(dest => dest.ToEmployeeName,
                            opt => opt.MapFrom(src => src.ToEmployee.FullName))
                .ForMember(dest => dest.Items,
                            opt => opt.MapFrom(src => src.Items))
                .ForMember(dist => dist.MatriallyResponibleDisplayName,
                            opt => opt.MapFrom(src => src.MateriallyResponsible == null ? string.Empty : src.MateriallyResponsible.DisplayName)); ;

            CreateMap<TransferDocument, TransferDocumentListDto>()
                .IncludeBase<DocumentEntity, DocumentDto>()
                .ForMember(dest => dest.FromEmployeeName,
                            opt => opt.MapFrom(src => src.FromEmployee.ShortName))
                .ForMember(dest => dest.ToEmployeeName,
                            opt => opt.MapFrom(src => src.ToEmployee.ShortName))
                .ForMember(dest => dest.ItemsCount,
                            opt => opt.MapFrom(src => src.Items.Count()))
                .ForMember(dist => dist.MatriallyResponibleDisplayName,
                            opt => opt.MapFrom(src => src.MateriallyResponsible == null ? string.Empty : src.MateriallyResponsible.DisplayName)); ;
        }
    }
}
