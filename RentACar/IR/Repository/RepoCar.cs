using RentACar.IR.Interface;
using RentACar.Model;

using RentACar.Enums;
using System.Globalization;

namespace RentACar.IR.Repository;
public class RepoCar : ICar
{
    int _counter;
    int _counterCustomer;
    int _counterEmployer;
    private List<Car> _cars;
    private List<Customer> _customers;
    private List<Employer> _employers;
    private List<Reservation> _reservation;
    private Admin _admin;
    private IWriteLine iwi;
    
    public RepoCar()
    {
        _cars = new List<Car>();
        _customers = new List<Customer>();
        _employers = new List<Employer>();
        _reservation = new List<Reservation>(); 
        iwi = new RepoWriteLine();
        _admin = new Admin("admin", "linkin");
    }
    public void CreateCarConvertible(string plate, string name, Color color, CarBrand brand) => _cars.Add(new Convertible(++_counter, plate, name, color, brand));
    public void CreateCarSport(string plate, string name, Color color, CarBrand brand) => _cars.Add(new Sport(++_counter, plate, name, color, brand));
    public void CreateCarStation(string plate, string name, Color color, CarBrand brand) => _cars.Add(new Station(++_counter, plate, name, color, brand));
    public List<Car> GetAllCars() => _cars;
    public void UpdateCarPlate(Car car, string plate) => car.Plate = plate;
    public void UpdateCarName(Car car, string name) => car.Name = name;
    public void UpdateCarColor(Car car, Color color) => car.CarColor = color;
    public void UpdateCarBrand(Car car, CarBrand brand) => car.Brand = brand;
    public void UpdateCarKmDrived(Car car, double km) => car.KmDrived = km;
    public void UpdateCarSeats(Car car, int seat) => car.Seat = seat;
    public void UpdateCarPrice(Car car, double price) => car.Price = price;
    public void UpdateCar()
    {
        Console.Clear();
        if (_cars.Count != 0)
        {
            Console.Clear();
            PrintCarList();
            Car? FoundCar = GetCarById(iwi.InputUint("Choise: "));
            if (FoundCar != null)
            {
                bool updateCarRuntime = true;
                do
                {
                    switch (iwi.InputUint("Update car\n\n1: Model\n2: Plate\n3: Color\n4: Brand\n5: Seats\n6: price\n7: Km Drived\n0: Exit\n\nChoice: "))
                    {
                        case 1:
                            UpdateCarName(FoundCar, iwi.InputString("Model: "));
                            break;
                        case 2:
                            UpdateCarPlate(FoundCar, iwi.InputString("Plate: "));
                            break;
                        case 3:
                            UpdateCarColor(FoundCar, iwi.PickAColorMenu());
                            break;
                        case 4:
                            UpdateCarBrand(FoundCar, iwi.PickACarBrandMenu());
                            break;
                        case 5:
                            UpdateCarSeats(FoundCar, iwi.InputUint("Total seats: "));
                            break;
                        case 6:
                            UpdateCarPrice(FoundCar, iwi.InputUint("New price: "));
                            break;
                        case 7:
                            UpdateCarKmDrived(FoundCar, iwi.InputUint("Km: "));
                            break;
                        case 0:
                            updateCarRuntime = false;
                            break;
                        default:
                            break;
                    }
                } while (updateCarRuntime);
            }
            else
                iwi.WarningMsg("No car found with the chosen id");
        }
    }
    public void DeleteCarById(int id)
    {
        Car? foundCar = _cars.Find(x => x.Id == id);
        if (foundCar != null)
            _cars.Remove(foundCar);
    }
    public void DeleteCar()
    {
        Console.Clear();
        if (_cars.Count != 0)
        {
            PrintCarList();
            DeleteCarById(iwi.InputUint("Choice: "));
        }
        else
        {
            Console.WriteLine("No cars found");
            Console.ReadKey();       
        }
    }
    public Car? GetCarById(int id) => _cars.Find(x => x.Id == id);
    public void PrintCarList() 
    {
        Console.Clear();
        _cars.ForEach(car => Console.WriteLine(
            $"Id: {car.Id}\nName: {car.Name}\nPlate: {car.Plate}\nColor: {car.CarColor}\nBrand: {car.Brand}\nModel: {car.Name}\nPrice: {car.Price}"));
    } 
    public void CreateCar()
    {
        if (iwi.Login(GetAdmin().GetAdminUsername(), GetAdmin().GetAdminPassword()))
        {
            CarType type = iwi.PickACarTypeMenu();
            CarBrand brand = iwi.PickACarBrandMenu();
            string model = iwi.InputString("Model: ");
            string plate = iwi.InputString("Plate: ");
            Color color = iwi.PickAColorMenu();
            if (type == CarType.Convertible)
                CreateCarConvertible(plate, model, color, brand);
            if (type == CarType.Sport)
                CreateCarSport(plate, model, color, brand);
            if (type == CarType.Station)
                CreateCarStation(plate, model, color, brand);
        }
        else
            iwi.WarningMsg("Wrong username or password");
    }
    // Customer
    public void CreateCustomer(string firstname, string lastname, string mail, string phone) =>
       _customers.Add(new Customer(++_counterCustomer, firstname, lastname, mail, phone));
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
    public void PrintCustomerList()
    {
        Console.Clear();
        if (_customers != null)
            _customers.ForEach(acc => Console.WriteLine($"Id: {acc.Id}\nName: {acc.FirstName} {acc.LastName}\nMail: {acc.Mail}\nPhone: {acc.Phone}\n"));
        else
            iwi.WarningMsg("No customer in system");
    }
    public void CreaterPerson()
    {
        Console.Clear();
        switch (iwi.PickPerson("Pick user to create\n\n1: Customer\n2: Employer\n\nChoice: "))
        {
            case PersonType.Customer:
                CreateCustomer(iwi.InputString("Firstname: "), iwi.InputString("Lastname: "), iwi.InputString("Mail: "), iwi.InputUint("Phone: ").ToString());
                break;
            case PersonType.Employer:
                if (iwi.Login(GetAdmin().GetAdminUsername(), GetAdmin().GetAdminPassword()))
                    CreateEmployer(iwi.InputString("Firstname: "), iwi.InputString("Lastname: "), iwi.InputString("Mail: "), iwi.InputUint("Phone: ").ToString());
                else
                    iwi.WarningMsg("Wrong username or password");
                break;
            default:
                break;
        }
    }
    public void UpdatePerson()
    {
        Console.Clear();
        switch (iwi.PickPerson("Pick update\n\n1: Customer\n2: Employer\n\nChoice: "))
        {
            case PersonType.Customer:
                if (_customers.Count != 0)
                {
                    Console.Clear();
                    PrintCustomerList();
                    Customer? FoundCustomer = GetCustomerById(iwi.InputUint("Choice: "));
                    if (FoundCustomer != null)
                    {
                        bool updateRuntime = true;
                        iwi.UpdateCustomerMenu();
                        do
                        {
                            switch (iwi.InputUint("Choice: "))
                            {
                                case 1:
                                    UpdateCustomerFirstname(FoundCustomer, iwi.InputString("New firstname: "));
                                    break;
                                case 2:
                                    UpdateCustomerLastname(FoundCustomer, iwi.InputString("New Lastname: "));
                                    break;
                                case 3:
                                    UpdateCustomerMail(FoundCustomer, iwi.InputString("New mail: "));
                                    break;
                                case 4:
                                    UpdateCustomerPhone(FoundCustomer, iwi.InputString("New phonenumber: "));
                                    break;
                                case 5:
                                    updateRuntime = false;
                                    break;
                                default:
                                    break;
                            }
                        } while (updateRuntime);
                    }
                    else
                        iwi.WarningMsg("No customer with the chosen id");
                }
                else
                    iwi.WarningMsg("No Customer in system");
                break;
            case PersonType.Employer:
                if (_employers.Count != 0)
                {
                    Console.Clear();
                    PrintEmployerList();
                    Employer? FoundEmployer = GetEmployerById(iwi.InputUint("Choice: "));
                    if (FoundEmployer != null)
                    {
                        bool updateRuntimeE = true;
                        iwi.UpdateCustomerMenu();
                        do
                        {
                            switch (iwi.InputUint("Choice: "))
                            {
                                case 1:
                                    UpdateEmployerFirstname(FoundEmployer, iwi.InputString("New firstname: "));
                                    break;
                                case 2:
                                    UpdateEmployerLastname(FoundEmployer, iwi.InputString("New Lastname: "));
                                    break;
                                case 3:
                                    UpdateEmployerMail(FoundEmployer, iwi.InputString("New mail: "));
                                    break;
                                case 4:
                                    UpdateEmployerPhone(FoundEmployer, iwi.InputString("New phonenumber: "));
                                    break;
                                case 5:
                                    updateRuntimeE = false;
                                    break;
                                default:
                                    break;
                            }

                        } while (updateRuntimeE);
                    }
                    else
                        iwi.WarningMsg("No employer with the chosen id");
                }
                else
                    iwi.WarningMsg("No employers in system");
                break;
            default:
                break;
        }
    }
    public void DeletePerson()
    {
        Console.Clear();
        switch (iwi.PickPerson("Pick delete\n\n1: Customer\n2: Employer\n\nChoice: "))
        {
            case PersonType.Customer:
                if (_customers.Count != 0)
                {
                    PrintCustomerList();
                    DeleteCustomerById(iwi.InputUint("Cohice: "));
                }
                else
                    iwi.WarningMsg("No customer in system");
                break;
            case PersonType.Employer:
                if (_customers.Count != 0)
                {
                    PrintEmployerList();
                    DeleteEmployerById(iwi.InputUint("Choise: "));
                }
                else
                    iwi.WarningMsg("No emplyer in system");
                break;
            default:
                break;
        }
    }
    // Employer
    public void CreateEmployer(string firstname, string lastname, string mail, string phone) =>
        _employers.Add(new Employer(++_counterEmployer, firstname, lastname, mail, phone));
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
    public Admin GetAdmin() => _admin;
    public void PrintEmployerList()
    {
        Console.Clear();
        _employers.ForEach(acc => Console.WriteLine($"Id: {acc.Id}\nName: {acc.FirstName} {acc.LastName}\nMail: {acc.Mail}\nPhone: {acc.Phone}\n"));
    }
    public void PrintPersonMenu()
    {
        switch (iwi.PickPerson("Pick person type\n\n1: Customer\n2: Employer\n\nChoice: "))
        {
            case PersonType.Customer:
                PrintCustomerList();
                Console.ReadKey();
                break;
            case PersonType.Employer:
                PrintEmployerList();
                Console.ReadKey();
                break;
            default:
                break;
        }
    }
    // Res
    public void RentCar(Car car, Customer customer, Employer employer, DateTime rentDay, int days)
    {
        if (car.RentCustomerId == 0)
        {
            Reservation rent = new Reservation(car.Id, customer.Id, employer.Id, rentDay, days);
            rent.Balance = car.Price * days;
            _reservation.Add(rent);
            car.RentCustomerId = customer.Id;
            employer.SoldRentCar.Add(rent);
        }
    }
    public void DeliverCarRes(Reservation res, Car car)
    {
        if (res.ExpectedDelviredDay > DateTime.Now)
        {
            res.DelviredDay = DateTime.Now;

            TimeSpan diff = res.ExpectedDelviredDay.Subtract(res.DelviredDay);
            res.Balance += res.Balance + (diff.Days * res.Balance);
            car.RentCustomerId = 0;
        }
        else
        {
            res.DelviredDay = DateTime.Now;
            res.Balance += res.Balance;
            car.RentCustomerId = 0;
        }
    }
    public List<Reservation> GetReservations() => _reservation;
    public Reservation? GetReservationById(int id) => _reservation.Find(x => x.Id == id);

    public bool CheckReservation(DateTime date, int carId)
    {
        foreach (Reservation item in _reservation)
        {
            if (item.Id == carId)
            {
                if (date.Day >= item.RentDay.Day && date.Day <= item.ExpectedDelviredDay.Day)
                    return true;
            }
        }
        return false;
    }
    public void ReservationMenu()
    {
        Console.Clear();
        switch (iwi.InputUint("Reservation\n\n1: Rent a car\n2: Delverier car\n3: Show all reservations\n\nChoice: "))
        {
            case 1:
                if (GetAllCars().Count != 0 || GetAllCustomers().Count != 0 || GetAllEmployers().Count != 0)
                {
                    string rentDay;
                    bool pickDate;
                    DateTime date;
                    Console.WriteLine("Pick car id");
                    PrintCarList();
                    Car? FoundRentCar = GetCarById(iwi.InputUint("\nChoise: "));
                    if (FoundRentCar != null)
                    {
                        do
                        {
                            var cultureInfo = new CultureInfo("da-DK");
                            rentDay = iwi.InputString("Write a date to rent (date month yeah): ");
                            date = DateTime.Parse(rentDay, cultureInfo);
                            pickDate = CheckReservation(date, FoundRentCar.Id);
                            if (pickDate)
                                iwi.WarningMsg("Car is rent on given day, Pick a new date");
                        } while (pickDate);
                        Console.WriteLine("Pick customer id");
                        PrintCustomerList();
                        Customer? FoundRentCustomer = GetCustomerById(iwi.InputUint("Choice: "));
                        Console.WriteLine("Pick employer id");
                        PrintEmployerList();
                        Employer? FoundRentEmployer = GetEmployerById(iwi.InputUint("Choice: "));
                        if (FoundRentCustomer != null && FoundRentCar != null && FoundRentEmployer != null)
                            RentCar(FoundRentCar, FoundRentCustomer, FoundRentEmployer, date, iwi.InputUint("How many days du you wanna use the car: "));
                        else
                            iwi.WarningMsg("Missing files in system");
                    }
                }
                else
                    iwi.WarningMsg("Missing files in system");
                break;
            case 2:
                if (_reservation.Count != 0)
                {
                    PrintReservation();
                    Reservation? reservationFound = GetReservationById(iwi.InputUint("Choice: "));
                    if (reservationFound != null)
                    {
                        Car? FoundCar = GetCarById(reservationFound.CarId);
                        if (FoundCar != null)
                        {
                            DeliverCarRes(reservationFound, FoundCar);
                        }
                    }
                }
                else
                    iwi.WarningMsg("No reservations in system");
                break;
            case 3:
                PrintReservation();
                Console.ReadKey();
                break;
            default:
                break;
        }
    }
    public void PrintReservation()
    {
        Console.Clear();
        foreach (Reservation item in _reservation)
        {
            Console.WriteLine($"Id: {item.Id}\nRent day: {item.RentDay}\nExpected return date: {item.ExpectedDelviredDay}\nReturn date: {item.DelviredDay}\nPrice: {item.Balance}\n");
            Car? FoundCar = GetCarById(item.CarId);
            Customer? FoundCustomer = GetCustomerById(item.CustomerId);
            Employer? FoundEmployer = GetEmployerById(item.EmployerId);
            Console.WriteLine($"Car\nBrand: {FoundCar.Brand}\nModel: {FoundCar.Name}\nColor: {FoundCar.CarColor}\nPlate: {FoundCar.Plate}\nKm: {FoundCar.KmDrived}\nPrice: {FoundCar.Price}\n");
            Console.WriteLine($"Customer\nName: {FoundCustomer.FirstName} {FoundCustomer.LastName}\nPhone: {FoundCustomer.Phone}\nMail: {FoundCustomer.Mail}\n");
            Console.WriteLine($"Employer\nName: {FoundEmployer.FirstName} {FoundEmployer.LastName}");
            Console.WriteLine("____________________________");
        }
    }
}
