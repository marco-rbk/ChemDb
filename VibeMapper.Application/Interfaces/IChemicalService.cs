using VibeMapper.Core.Models;

namespace VibeMapper.Application.Interfaces
{
    public interface IChemicalService
    {
        Task<IEnumerable<Chemical>> GetChemicalsAsync();
        Task<Chemical> GetChemicalByIdAsync(int id);
        Task CreateChemicalAsync(Chemical chemical);
        Task UpdateChemicalAsync(Chemical chemical);
        Task DeleteChemicalAsync(int id);
    }
}
