using Inventory_Atlas.Application.Mappings.Common;
using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Core.DTOs.Documents;
using Inventory_Atlas.Infrastructure.Entities.Base;
using Inventory_Atlas.Infrastructure.Entities.Documents;

namespace Inventory_Atlas.Application.Mappings.Documents
{
    public class WriteOffDocumentProfile : DocumentProfile
    {
        public WriteOffDocumentProfile()
        {
            CreateMap<WriteOffDocumentItem, WriteOffDocumentItemDto>()
                .ForMember(dest => dest.ItemName,
                            opt => opt.MapFrom(src => src.Item.Name))
                .ForMember(dest => dest.ItemInventoryNumber,
                            opt => opt.MapFrom(src => src.Item.InventoryNumber));

            CreateMap<WriteOffDocument, WriteOffDocumentDto>()
                .IncludeBase<DocumentEntity, DocumentDto>()
                .ForMember(dest => dest.Items,
                            opt => opt.MapFrom(src => src.Items));

            CreateMap<WriteOffDocument, WriteOffDocumentListDto>()
                .IncludeBase<DocumentEntity, DocumentDto>()
                .ForMember(dest => dest.ItemsCount,
                            opt => opt.MapFrom(src => src.Items.Count()));
        }
    }
}
