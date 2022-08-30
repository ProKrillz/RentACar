using RentACar.Model;

namespace RentACar.IR.Interface;
public interface ICustomer
{
    public void CreateCustomer(string firstname, string lastname, string mail, string phone);
    public void UpdateCustomerFirstname(Customer customer, string firstname);
    public void UpdateCustomerLastname(Customer customer, string lastname);
    public void UpdateCustomerMail(Customer customer, string mail);
    public void UpdateCustomerPhone(Customer customer, string phone);
    public List<Customer> GetAllCustomers();
    public Customer? GetCustomerById(int id);
    public void DeleteCustomerById(int id);
}
