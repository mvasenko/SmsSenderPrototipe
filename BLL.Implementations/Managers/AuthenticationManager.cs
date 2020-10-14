using BLL.Contracts.DTObjects;
using BLL.Contracts.Managers;
using BLL.Contracts.Services;
using DAL.Contracts.Repositories;

namespace BLL.Implementations.Managers
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IInvitationRepository _invitationRepository;

        private readonly ISendInvitesRequestValidationService<SendInvitesDto> _requestValidationService;

        private readonly ISmsService _smsService;

        public AuthenticationManager(
            IInvitationRepository invitationRepository,
            ISendInvitesRequestValidationService<SendInvitesDto> requestValidationService,
            ISmsService smsService)
        {
            _invitationRepository = invitationRepository;
            _requestValidationService = requestValidationService;
            _smsService = smsService;
        }

        public void SendInvites(SendInvitesDto dto)
        {
            _requestValidationService.ValidateRequest(dto);

            _requestValidationService.ValidateSendInvitesAbility(dto, _invitationRepository.GetCountInvitations(4));

            _invitationRepository.SaveInvitations(7, dto.PhoneNumbers.ToArray());

            dto.PhoneNumbers.ForEach(pn => _smsService.SendSms(pn, dto.Message));
        }
    }
}
