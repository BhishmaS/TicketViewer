using AutoMapper;
using TicketViewer.Model;

namespace TicketViewer.Services
{
    public class TicketViewerMappingProfile : Profile
    {
        public TicketViewerMappingProfile()
        {
            this.RegisterTicketViewerMappings();
        }

        private void RegisterTicketViewerMappings()
        {
            this.CreateMap<Model.Zendesk.User, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email));

            this.CreateMap<Model.Zendesk.TicketViewModel, Ticket>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.RequesterId, opt => opt.MapFrom(src => src.requester_id))
                .ForMember(dest => dest.AssigneeId, opt => opt.MapFrom(src => src.assignee_id))
                .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.subject))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.description))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.type))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.priority))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.tags))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.status))
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.created_at))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(src => src.updated_at));

            this.CreateMap<Model.Zendesk.TicketListViewModel, TicketsPage>()
                .ForMember(dest => dest.Tickets, opt => opt.MapFrom(src => src.tickets))
                .ForMember(dest => dest.TotalTickets, opt => opt.MapFrom(src => src.count))
                .ForMember(dest => dest.PreviousPage, opt => opt.MapFrom(src => src.previous_page))
                .ForMember(dest => dest.NextPage, opt => opt.MapFrom(src => src.next_page));
        }
    }
}
