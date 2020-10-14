using AutoMapper;
using BLL.Contracts.DTObjects;
using Contracts.Requests;

namespace DI.Mappings
{
    public class SendInvitesMappingProfile : Profile
    {
        public SendInvitesMappingProfile()
        {
            CreateMap<SendInvitesRequest, SendInvitesDto>();
        }
    }
}
