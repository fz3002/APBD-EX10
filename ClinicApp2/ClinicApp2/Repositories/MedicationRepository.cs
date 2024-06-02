using ClinicApp2.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicApp2.Repositories;

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