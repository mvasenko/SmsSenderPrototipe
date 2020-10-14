using BLL.Contracts.DTObjects;

namespace BLL.Contracts.Managers
{
    public interface IAuthenticationManager
    {
        void SendInvites(SendInvitesDto dto);
    }
}