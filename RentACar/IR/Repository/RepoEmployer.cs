using RentACar.IR.Interface;
using RentACar.Model;

namespace RentACar.IR.Repository;
public class RepoEmployer : IEmployer
{
	int _counter;
	private List<Employer> _employers;
    private Admin _admin;

	public RepoEmployer()
	{
		_employers = new();
        _admin = new Admin("admin", "linkin");
	}
    public void CreateEmployer(string firstname, string lastname, string mail, string phone) =>
        _employers.Add(new Employer(++_counter, firstname, lastname, mail, phone));
    public void UpdateEmployerFirstname(Employer employer, string firstname) => employer.FirstName = firstname;
    public void UpdateEmployerLastname(Employer employer, string lastname) => employer.LastName = lastname;
    public void UpdateEmployerMail(Employer employer, string mail) => employer.Mail = mail;
    public void UpdateEmployerPhone(Employer employer, string phone) => employer.Phone = phone;
    public void AddResvationToSoldList(Employer employer, Reservation res) => employer.SoldRentCar.Add(res);
    public List<Employer> GetAllEmployers() => _employers;
    public Employer? GetEmployerById(int id) => _employers.Find(x => x.Id == id);
    public void DeleteEmployerById(int id)
    {
        Employer? foundEmployer = _employers.Find(x => x.Id == id);
        if (foundEmployer != null)
            _employers.Remove(foundEmployer);
    }
    public void CreateAdmin(string username, string password) =>   _admin = new Admin(username, password);
    public Admin GetAdmin() => _admin;
}
