using ClinicApp2.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicApp2.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly IUnitOfWork _unitOfWork;

    public DoctorRepository(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Doctor?> GetDoctorAsync(int id, CancellationToken cancellationToken)
    {
        return await _unitOfWork.GetDbContext().Doctors.Where(d => d.IdDoctor == id).Select(d => d).FirstOrDefaultAsync(cancellationToken);
    }
}