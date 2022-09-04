
using RentACar.Model;
using System.Diagnostics.Metrics;

namespace RentACar.IR.Interface;

public interface IEmployer
{
    public void CreateEmployer(string firstname, string lastname, string mail, string phone);
    public void UpdateEmployerFirstname(Employer employer, string firstname);
    public void UpdateEmployerLastname(Employer employer, string lastname);
    public void UpdateEmployerMail(Employer employer, string mail);
    public void UpdateEmployerPhone(Employer employer, string phone);
    public void AddResvationToSoldList(Employer employer, Reservation res);
    public List<Employer> GetAllEmployers();
    public Employer? GetEmployerById(int id);
    public void DeleteEmployerById(int id);
    public void CreateAdmin(string username, string password);
    public Admin GetAdmin();
}
