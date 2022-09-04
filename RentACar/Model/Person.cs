using RentACar.Enums;

namespace RentACar.Model;
public class Person
{
    public int Id { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }
    public PersonType Type { get; set; }
}
public class Customer : Person
{
    public Customer(int id, string firstname, string lastname, string mail, string phone)
    {
        Id = id;
        FirstName = firstname;
        LastName = lastname;
        Mail = mail;
        Phone = phone;
        Type = PersonType.Customer;
    }
}
public class Employer : Person
{
    public List<Reservation> SoldRentCar { get; set; }
    public Employer(int id, string firstname, string lastname, string mail, string phone)
    {
        Id = id;
        FirstName = firstname;
        LastName = lastname;
        Mail = mail;
        Phone = phone;
        Type = PersonType.Employer;
        SoldRentCar = new();
    }
}
public class Admin : Person
{
    private string _username;
    private string _password;
    public Admin(string username, string password)
    {
        _username = username;
        _password = password;
        Type = PersonType.Admin;
        FirstName = "Admin";
        Id = 0;
    }
    public string GetAdminUsername() => _username;
    public string GetAdminPassword() => _password;
}

