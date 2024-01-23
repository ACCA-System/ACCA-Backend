using ACCA_Backend.DataAccess.Entities;
using ACCA_Backend.DataAccess.Repository.Context;
using ACCA_Backend.DataAccess.Services.Interfaces;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace ACCA_Backend.DataAccess.Services
{
    public class DonationTypeService : IDonationTypeService
    {
        private readonly AccaSystemContext _dbContext; // Reemplaza YourDbContext con el nombre de tu contexto de base de datos

        public DonationTypeService(AccaSystemContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<DonationType>> GetAllDonationTypes()
        {
            return await _dbContext.DonationType.ToListAsync();
        }

        public async Task<DonationType> GetDonationTypeById(int id)
        {
            return await _dbContext.DonationType.FindAsync(id);
        }

        public async Task<DonationType> AddDonationType(DonationType donationType)
        {
            _dbContext.DonationType.Add(donationType);
            await _dbContext.SaveChangesAsync();
            return donationType;
        }

        public async Task<DonationType> UpdateDonationType(DonationType donationType)
        {
            _dbContext.Entry(donationType).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return donationType;
        }

        public async Task DeleteDonationType(int id)
        {
            var donationType = await _dbContext.DonationType.FindAsync(id);
            if (donationType != null)
            {
                _dbContext.DonationType.Remove(donationType);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
