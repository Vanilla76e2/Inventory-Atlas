using AutoMapper;
using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Infrastructure.Entities.Base;
using Inventory_Atlas.Infrastructure.Entities.Documents;

namespace Inventory_Atlas.Application.Mappings.Common
{
    public abstract class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<DocumentEntity, DocumentDto>();

            CreateMap<CheckoutDocument, DocumentDto>();
            CreateMap<ReturnDocument, DocumentDto>();
            CreateMap<TransferDocument, DocumentDto>();
            CreateMap<WriteOffDocument, DocumentDto>();
        }
    }
}
