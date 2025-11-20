using VibeMapper.Core.Models;

namespace VibeMapper.Application.Interfaces
{
    public interface IChemicalRepository
    {
        Task<IEnumerable<Chemical>> GetAllAsync();
        Task<Chemical> GetByIdAsync(int id);
        Task AddAsync(Chemical chemical);
        Task UpdateAsync(Chemical chemical);
        Task DeleteAsync(int id);
    }
}
