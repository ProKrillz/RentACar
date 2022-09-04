using RentACar.IR.Interface;
using RentACar.Model;

namespace RentACar.IR.Repository;

public class RepoCostumer : ICustomer
{
    int _counter;
    private List<Customer> _customers;
    
    public RepoCostumer()
    {
        _customers = new List<Customer>();
    }
    public void CreateCustomer(string firstname, string lastname, string mail, string phone) =>
        _customers.Add(new Customer(++_counter, firstname, lastname, mail, phone));
    public void UpdateCustomerFirstname(Customer customer, string firstname) => customer.FirstName = firstname;
    public void UpdateCustomerLastname(Customer customer, string lastname) => customer.LastName = lastname;
    public void UpdateCustomerMail(Customer customer, string mail) => customer.Mail = mail;
    public void UpdateCustomerPhone(Customer customer, string phone) => customer.Phone = phone;
    public List<Customer> GetAllCustomers() => _customers;
    public Customer? GetCustomerById(int id) => _customers.Find(x => x.Id == id);
    public void DeleteCustomerById(int id)
    {
        Customer? foundCustomer = _customers.Find(x => x.Id == id);
        if (foundCustomer != null)
            _customers.Remove(foundCustomer);
    }
    
}
