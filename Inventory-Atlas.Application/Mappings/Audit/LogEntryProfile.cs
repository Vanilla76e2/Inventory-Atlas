using AutoMapper;
using Inventory_Atlas.Application.Converters;
using Inventory_Atlas.Core.DTOs.Audit;
using Inventory_Atlas.Infrastructure.Entities.Audit;

namespace Inventory_Atlas.Application.Mappings.Audit
{
    public class LogEntryProfile : Profile
    {
        public LogEntryProfile()
        {
            // Mapping LogEntry -> LogEntryDto
            CreateMap<LogEntry, LogEntryDto>()
                .ForMember(dest => dest.Username,
                           opt => opt.MapFrom(src => src.UserSession.Username))
                .ForMember(dest => dest.Details,
                            opt => opt.ConvertUsing(new JsonStringToDictionaryConverter(), src => src.Details));

            // Mapping для пагинации (PagedLogEntryDto)
            CreateMap<(List<LogEntry> items, int totalCount, int pageNumber, int pageSize), PagedLogEntryDto>()
                .ForMember(dest => dest.Items,
                           opt => opt.MapFrom(src => src.items))
                .ForMember(dest => dest.TotalCount,
                           opt => opt.MapFrom(src => src.totalCount))
                .ForMember(dest => dest.PageNumber,
                           opt => opt.MapFrom(src => src.pageNumber))
                .ForMember(dest => dest.PageSize,
                           opt => opt.MapFrom(src => src.pageSize));
        }
    }
}
