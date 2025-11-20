using VibeMapper.Application.Interfaces;
using VibeMapper.Core.Models;

namespace VibeMapper.Application.Services
{
    public class ChemicalService : IChemicalService
    {
        private readonly IChemicalRepository _chemicalRepository;

        public ChemicalService(IChemicalRepository chemicalRepository)
        {
            _chemicalRepository = chemicalRepository;
        }

        public async Task<IEnumerable<Chemical>> GetChemicalsAsync()
        {
            var chemicals = await _chemicalRepository.GetAllAsync();
            if (chemicals == null || !chemicals.Any())
            {
                return GetDefaultChemicals();
            }
            return chemicals;
        }

        public async Task<Chemical> GetChemicalByIdAsync(int id)
        {
            return await _chemicalRepository.GetByIdAsync(id);
        }

        public async Task CreateChemicalAsync(Chemical chemical)
        {
            await _chemicalRepository.AddAsync(chemical);
        }

        public async Task UpdateChemicalAsync(Chemical chemical)
        {
            await _chemicalRepository.UpdateAsync(chemical);
        }

        public async Task DeleteChemicalAsync(int id)
        {
            await _chemicalRepository.DeleteAsync(id);
        }

        private IEnumerable<Chemical> GetDefaultChemicals()
        {
            return new[]
            {
                new Chemical
                {
                    Name = "Hydrogen Peroxide",
                    CASNumber = "7722-84-1",
                    ECNumber = "231-765-0",
                    DNELs = new List<DNEL>
                    {
                        new DNEL { ExposedGroup = "Worker", ExposureRoute = "Inhalation", ExposureType = "Long-term local", Value = 1.4m, Unit = "mg/m³" },
                        new DNEL { ExposedGroup = "Worker", ExposureRoute = "Inhalation", ExposureType = "Acute local", Value = 3m, Unit = "mg/m³" },
                        new DNEL { ExposedGroup = "General Population", ExposureRoute = "Inhalation", ExposureType = "Long-term local", Value = 0.21m, Unit = "mg/m³" }
                    },
                    PNECs = new List<PNEC>
                    {
                        new PNEC { Compartment = "Freshwater", Value = 0.0126m, Unit = "mg/L" },
                        new PNEC { Compartment = "Marine water", Value = 0.0126m, Unit = "mg/L" },
                        new PNEC { Compartment = "Sewage Treatment Plant", Value = 4.66m, Unit = "mg/L" }
                    }
                },
                new Chemical
                {
                    Name = "Dibenzoyl Peroxide",
                    CASNumber = "94-36-0",
                    ECNumber = "202-327-6",
                    DNELs = new List<DNEL>
                    {
                        new DNEL { ExposedGroup = "Worker", ExposureRoute = "Inhalation", ExposureType = "Long-term systemic", Value = 11.75m, Unit = "mg/m³" },
                        new DNEL { ExposedGroup = "Worker", ExposureRoute = "Dermal", ExposureType = "Long-term systemic", Value = 6.6m, Unit = "mg/kg bw/day" },
                        new DNEL { ExposedGroup = "General Population", ExposureRoute = "Oral", ExposureType = "Long-term systemic", Value = 1.6m, Unit = "mg/kg bw/day" }
                    },
                    PNECs = new List<PNEC>
                    {
                        new PNEC { Compartment = "Freshwater", Value = 0.0006m, Unit = "mg/L" },
                        new PNEC { Compartment = "Marine water", Value = 0.00006m, Unit = "mg/L" },
                        new PNEC { Compartment = "Soil", Value = 0.0758m, Unit = "mg/kg" }
                    }
                },
                new Chemical
                {
                    Name = "tert-Butyl hydroperoxide",
                    CASNumber = "75-91-2",
                    ECNumber = "200-915-7",
                    DNELs = new List<DNEL>(), // No data available example
                    PNECs = new List<PNEC>()
                }
            };
        }
    }
}
