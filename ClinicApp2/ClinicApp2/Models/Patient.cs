using System.ComponentModel.DataAnnotations;

namespace ClinicApp.Models;

public class Patient
{

    public int IdPatient { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateOnly Birthdate { get; set; }

    public ICollection<Prescription> Prescriptions { get; set; }
}