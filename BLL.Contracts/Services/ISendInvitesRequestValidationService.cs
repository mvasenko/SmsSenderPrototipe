using BLL.Contracts.DTObjects;

namespace BLL.Contracts.Services
{
    public interface ISendInvitesRequestValidationService<T> : IRequestValidationService<T>
    {
        void ValidateSendInvitesAbility(SendInvitesDto dto, int currentInvitationsNumber);
    }
}