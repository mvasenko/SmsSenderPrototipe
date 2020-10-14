using DAL.Contracts.Repositories;
using DAL.Core;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations.Repositories
{
    public class InvitationRepository : IInvitationRepository
    {
        private readonly AppDbContext _context;

        public InvitationRepository(AppDbContext context)
        {
            _context = context;
        }

        public void SaveInvitations(int userId, string[] phoneNumbers)
        {
            var user_id = new SqlParameter("@user_id", userId);
            var phonestext = new SqlParameter
            {
                ParameterName = "@phonestext",
                SqlDbType = SqlDbType.Structured,
                TypeName = "dbo.List",
                Value = phoneNumbers
            };
            _context.Database.ExecuteSqlRaw("invite @user_id, @phonestext", user_id, phonestext);
        }

        public int GetCountInvitations(int appId)
        {
            var appid = new SqlParameter("@appid", appId);
            var countInvitations = new SqlParameter
            {
                ParameterName = "@countInvitations",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            _context.Database.ExecuteSqlRaw("getcountinvitations @appid, @countInvitations OUT", appid,
                countInvitations);

            return (int) countInvitations.Value;
        }
    }
}
