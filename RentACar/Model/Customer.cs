
namespace RentACar.Model;
public class Customer
{
    public int Id { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }

    public Customer(int id, string firstname, string lastname, string mail, string phone) 
    { 
        Id = id; 
        FirstName = firstname;
        LastName = lastname;
        Mail = mail;
        Phone = phone;
    }
}
