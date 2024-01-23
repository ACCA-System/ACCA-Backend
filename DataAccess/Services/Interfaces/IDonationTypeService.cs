using ACCA_Backend.DataAccess.Entities;
using System.Threading.Tasks;

namespace ACCA_Backend.DataAccess.Services.Interfaces
{
    public interface IDonationTypeService
    {
        Task<IEnumerable<DonationType>> GetAllDonationTypes();
        Task<DonationType> GetDonationTypeById(int id);
        Task<DonationType> AddDonationType(DonationType donationType);
        Task<DonationType> UpdateDonationType(DonationType donationType);
        Task DeleteDonationType(int id);
    }
}
