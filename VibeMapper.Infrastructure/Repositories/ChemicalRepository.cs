using Microsoft.EntityFrameworkCore;
using VibeMapper.Application.Interfaces;
using VibeMapper.Core.Models;
using VibeMapper.Infrastructure.Data;

namespace VibeMapper.Infrastructure.Repositories
{
    public class ChemicalRepository : IChemicalRepository
    {
        private readonly AppDbContext _context;

        public ChemicalRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Chemical>> GetAllAsync()
        {
            return await _context.Chemicals
                .Include(c => c.DNELs)
                .Include(c => c.PNECs)
                .ToListAsync();
        }

        public async Task<Chemical> GetByIdAsync(int id)
        {
            return await _context.Chemicals
                .Include(c => c.DNELs)
                .Include(c => c.PNECs)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Chemical chemical)
        {
            await _context.Chemicals.AddAsync(chemical);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Chemical chemical)
        {
            _context.Entry(chemical).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var chemical = await _context.Chemicals.FindAsync(id);
            if (chemical != null)
            {
                _context.Chemicals.Remove(chemical);
                await _context.SaveChangesAsync();
            }
        }
    }
}
