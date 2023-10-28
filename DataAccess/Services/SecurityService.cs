using ACCA_Backend.DataAccess.Entities;

namespace ACCA_Backend.DataAccess.Services
{
    public interface ISessionService
    {
        public Task<Sessions> SaveSession(Users user);

        public Task<Sessions> GetSession(int UserId);
    }
}
