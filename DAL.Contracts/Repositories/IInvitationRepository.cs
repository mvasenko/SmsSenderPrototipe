namespace DAL.Contracts.Repositories
{
    public interface IInvitationRepository
    {
        void SaveInvitations(int userId, string[] phoneNumbers);

        int GetCountInvitations(int appId);
    }
}