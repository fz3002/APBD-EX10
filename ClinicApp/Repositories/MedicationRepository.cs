using ClinicApp.Context;
using ClinicApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicApp.Repositories;

public class MedicationRepository : IMedicationRepository
{
    private readonly IUnitOfWork _unitOfWork;

    public MedicationRepository(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Medicament?> GetMedicamentAsync(int id, CancellationToken cancellationToken)
    {
        return await _unitOfWork.GetDbContext().Medicaments.Where(m => m.IdMedicament == id).Select(m => m).FirstOrDefaultAsync(cancellationToken);
    }
}