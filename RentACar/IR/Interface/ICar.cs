using RentACar.Model;
using RentACar.Enums;

namespace RentACar.IR.Interface;
public interface ICar
{
    public void CreateCarConvertible(string plate, string name, Color color, CarBrand brand);
    public void CreateCarSport(string plate, string name, Color color, CarBrand brand);
    public void CreateCarStation(string plate, string name, Color color, CarBrand brand);
    public void UpdateCarPlate(Car car, string plate);
    public void UpdateCarName(Car car, string name);
    public void UpdateCarColor(Car car, Color color);
    public void UpdateCarBrand(Car car, CarBrand brand);
    public void UpdateCarKmDrived(Car car, double km);
    public void UpdateCarSeats(Car car, int seat);
    public void UpdateCarPrice(Car car, double price);
    public void UpdateCar();
    public List<Car> GetAllCars();
    public void DeleteCarById(int id);
    public void DeleteCar();
    public Car? GetCarById(int id);
    public void PrintCarList();
    public void CreateCar();
    // Customer
    public void CreateCustomer(string firstname, string lastname, string mail, string phone);
    public void UpdateCustomerFirstname(Customer customer, string firstname);
    public void UpdateCustomerLastname(Customer customer, string lastname);
    public void UpdateCustomerMail(Customer customer, string mail);
    public void UpdateCustomerPhone(Customer customer, string phone);
    public List<Customer> GetAllCustomers();
    public Customer? GetCustomerById(int id);
    public void DeleteCustomerById(int id);
    public void PrintCustomerList();
    public void CreaterPerson();
    public void UpdatePerson();
    public void DeletePerson();
    // Employer 
    public void CreateEmployer(string firstname, string lastname, string mail, string phone);
    public void UpdateEmployerFirstname(Employer employer, string firstname);
    public void UpdateEmployerLastname(Employer employer, string lastname);
    public void UpdateEmployerMail(Employer employer, string mail);
    public void UpdateEmployerPhone(Employer employer, string phone);
    public void AddResvationToSoldList(Employer employer, Reservation res);
    public List<Employer> GetAllEmployers();
    public Employer? GetEmployerById(int id);
    public void DeleteEmployerById(int id);
    public Admin GetAdmin();
    public void PrintEmployerList();
    public void PrintPersonMenu();
    // Rent
    public void RentCar(Car car, Customer customer, Employer employer, DateTime rentDay, int days);
    public void DeliverCarRes(Reservation res, Car car);
    public List<Reservation> GetReservations();
    public Reservation GetReservationById(int id);
    public bool CheckReservation(DateTime date, int carId);
    public void ReservationMenu();

}
