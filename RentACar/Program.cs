using Microsoft.Extensions.DependencyInjection;
using RentACar.BLL;
using RentACar.Enums;
using RentACar.IR.Interface;
using RentACar.IR.Repository;
using RentACar.Model;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;

var serviceProvider = new ServiceCollection().AddSingleton<ICar, RepoCar>().AddSingleton<ICustomer, RepoCostumer>().AddSingleton<IEmployer, RepoEmployer>().AddSingleton<IWriteLine, RepoWriteLine>().BuildServiceProvider();

CarShop shop = new CarShop("test", serviceProvider.GetService<ICustomer>(), serviceProvider.GetService<ICar>(), serviceProvider.GetService<IWriteLine>(), serviceProvider.GetService<IEmployer>() );

do
{
	shop.iwi.Menu(shop.GetCompanyName());
	switch (shop.iwi.InputUint("Choice: "))
	{
		case 1:
			if (shop.iwi.Login(shop.iei.GetAdmin().GetAdminUsername(), shop.iei.GetAdmin().GetAdminPassword()))
			{
				CarType type = shop.iwi.PickACarMenu();
				CarBrand brand = shop.iwi.PickACarBrandMenu();
				string carName = shop.iwi.InputString("Model: ");
				string plate = shop.iwi.InputString("Plate: ");
                Color color = shop.iwi.PickAColorMenu();
                if (type == CarType.Convertible)
					shop.icari.CreateCarConvertible(plate, carName, color, brand);
				if (type == CarType.Sport)
					shop.icari.CreateCarSport(plate, carName, color, brand);
				if (type == CarType.Station)
					shop.icari.CreateCarStation(plate, carName, color, brand);
			}
			else
				shop.iwi.WarningMsg("Wrong username or password");
			break;
		case 2:
			Console.Clear();
			shop.icari.GetAllCars().ForEach(car => Console.WriteLine($"Name: {car.Name}\nPlate: {car.Plate}\nColor: {car.CarColor}\nBrand: {car.Brand}"));
			Console.ReadKey();
			break;
        case 3:
            Console.Clear();
            if (shop.icari.GetAllCars().Count != 0)
            {
                shop.icari.GetAllCars().ForEach(car => Console.WriteLine($"Name: {car.Name}\nPlate: {car.Plate}\nColor: {car.CarColor}\nBrand: {car.Brand}"));
                Car? FoundCar = shop.icari.GetAllCars().Find(x => x.Id == shop.iwi.InputUint("Choise: "));
                if (FoundCar != null)
                {
                    bool updateCarRuntime = true;
                    do
                    {
                        switch (shop.iwi.InputUint("Update car\n\n1: Model\n2: Plate\n3: Color\n4: Brand\n5: Seats\n6: price\n7: Km Drived\n0: Exit\n\nChoice: "))
                        {
                            case 1:
                                shop.icari.UpdateCarName(FoundCar, shop.iwi.InputString("Model: "));
                                break;
                            case 2:
                                shop.icari.UpdateCarPlate(FoundCar, shop.iwi.InputString("Plate: "));
                                break;
                            case 3:
                                shop.icari.UpdateCarColor(FoundCar, shop.iwi.PickAColorMenu());
                                break;
                            case 4:
                                shop.icari.UpdateCarBrand(FoundCar, shop.iwi.PickACarBrandMenu());
                                break;
                            case 5:
                                shop.icari.UpdateCarSeats(FoundCar, shop.iwi.InputUint("Total seats: "));
                                break;
                            case 6:
                                shop.icari.UpdateCarPrice(FoundCar, shop.iwi.InputUint("New price: "));
                                break;
                            case 7:
                                shop.icari.UpdateCarKmDrived(FoundCar, shop.iwi.InputUint("Km: "));
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
                    shop.iwi.WarningMsg("No car found with the chosen id");
            }
            break;
        case 4:
            Console.Clear();
            if (shop.icari.GetAllCars().Count != 0)
            {
                shop.icari.GetAllCars().ForEach(car => Console.WriteLine($"Name: {car.Name}\nPlate: {car.Plate}\nColor: {car.CarColor}\nBrand: {car.Brand}"));
                shop.icari.DeleteCarById(shop.iwi.InputUint("Choice: "));
            }
            else
                shop.iwi.WarningMsg("No cars in system");
            break;
		case 5:
			switch (shop.iwi.PickPerson("Pick user to create\n\n1: Customer\n2: Employer\n\nChoice: "))
			{
				case PersonType.Customer:
                    shop.ici.CreateCustomer(shop.iwi.InputString("Firstname: "), shop.iwi.InputString("Lastname: "), shop.iwi.InputString("Mail: "), shop.iwi.InputUint("Phone: ").ToString());
                    break;
				case PersonType.Employer:
					if (shop.iwi.Login(shop.iei.GetAdmin().GetAdminUsername(), shop.iei.GetAdmin().GetAdminPassword()))
						shop.iei.CreateEmployer(shop.iwi.InputString("Firstname: "), shop.iwi.InputString("Lastname: "), shop.iwi.InputString("Mail: "), shop.iwi.InputUint("Phone: ").ToString());
					else
                        shop.iwi.WarningMsg("Wrong username or password");
					break;
				default:
					break;
			}
			break;
		case 6:
			Console.Clear();
			shop.ici.GetAllCustomers().ForEach(acc => Console.WriteLine($"\nFirstname: {acc.FirstName}\nLastname: {acc.LastName}\nMail: {acc.Mail}\nPhone: {acc.Phone}"));
			Console.ReadKey();
			break;
		case 7:
			Console.Clear();
			switch (shop.iwi.PickPerson("Pick update\n\n1: Customer\n2: Employer\n\nChoice: "))
			{
				case PersonType.Customer:
                    if (shop.ici.GetAllCustomers().Count != 0)
                    {
                        Console.Clear();
                        shop.ici.GetAllCustomers().ForEach(acc => Console.WriteLine($"Id: {acc.Id}\nFirstname: {acc.FirstName}\nLastname: {acc.LastName}\nMail: {acc.Mail}\nPhone: {acc.Phone}\n"));
                        Customer? FoundCustomer = shop.ici.GetAllCustomers().Find(x => x.Id == shop.iwi.InputUint("Choice: "));
                        if (FoundCustomer != null)
                        {
                            bool updateRuntime = true;
                            shop.iwi.UpdateCustomerMenu();
                            do
                            {
                                switch (shop.iwi.InputUint("Choice: "))
                                {
                                    case 1:
                                        shop.ici.UpdateCustomerFirstname(FoundCustomer, shop.iwi.InputString("New firstname: "));
                                        break;
                                    case 2:
                                        shop.ici.UpdateCustomerLastname(FoundCustomer, shop.iwi.InputString("New Lastname: "));
                                        break;
                                    case 3:
                                        shop.ici.UpdateCustomerMail(FoundCustomer, shop.iwi.InputString("New mail: "));
                                        break;
                                    case 4:
                                        shop.ici.UpdateCustomerPhone(FoundCustomer, shop.iwi.InputString("New phonenumber: "));
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
                            shop.iwi.WarningMsg("No customer with the chosen id");
                    }
                    else
                        shop.iwi.WarningMsg("No Customer in system");
					break;
				case PersonType.Employer:
                    if (shop.iei.GetAllEmployers().Count != 0)
                    {
                        Console.Clear();
                        shop.iei.GetAllEmployers().ForEach(acc => Console.WriteLine($"Id: {acc.Id}\nFirstname: {acc.FirstName}\nLastname: {acc.LastName}\nMail: {acc.Mail}\nPhone: {acc.Phone}\n"));
                        Employer? FoundEmployer = shop.iei.GetAllEmployers().Find(x => x.Id == shop.iwi.InputUint("Choice: "));
                        if (FoundEmployer != null)
                        {
                            bool updateRuntimeE = true;
                            shop.iwi.UpdateCustomerMenu();
                            do
                            {
                                switch (shop.iwi.InputUint("Choice: "))
                                {
                                    case 1:
                                        shop.iei.UpdateEmployerFirstname(FoundEmployer, shop.iwi.InputString("New firstname: "));
                                        break;
                                    case 2:
                                        shop.iei.UpdateEmployerLastname(FoundEmployer, shop.iwi.InputString("New Lastname: "));
                                        break;
                                    case 3:
                                        shop.iei.UpdateEmployerMail(FoundEmployer, shop.iwi.InputString("New mail: "));
                                        break;
                                    case 4:
                                        shop.iei.UpdateEmployerPhone(FoundEmployer, shop.iwi.InputString("New phonenumber: "));
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
                            shop.iwi.WarningMsg("No employer with the chosen id");
                    }
                    else
                        shop.iwi.WarningMsg("No employers in system");
                    break;
                default:
					break;
			}
            break;
        case 8:
            Console.Clear();
            switch (shop.iwi.PickPerson("Pick delete\n\n1: Customer\n2: Employer\n\nChoice: "))
            {
                case PersonType.Customer:
                    if (shop.ici.GetAllCustomers().Count != 0)
                    {
                        shop.ici.GetAllCustomers().ForEach(acc => Console.WriteLine($"Id: {acc.Id}\nFirstname: {acc.FirstName}\nLastname: {acc.LastName}\nMail: {acc.Mail}\nPhone: {acc.Phone}\n"));
                        shop.ici.DeleteCustomerById(shop.iwi.InputUint("Cohice: "));
                    }
                    else
                        shop.iwi.WarningMsg("No customer in system");
                    break;
                case PersonType.Employer:
                    if (shop.iei.GetAllEmployers().Count != 0)
                    {
                        shop.iei.GetAllEmployers().ForEach(acc => Console.WriteLine($"Id: {acc.Id}\nFirstname: {acc.FirstName}\nLastname: {acc.LastName}\nMail: {acc.Mail}\nPhone: {acc.Phone}\n"));
                        shop.iei.DeleteEmployerById(shop.iwi.InputUint("Choise: "));
                    }
                    else
                        shop.iwi.WarningMsg("No emplyer in system");
                    break;
                default:
                    break;
            }
            break;
        case 9:
			shop.runTime = false;
			break;
		default:
			break;
	}
} while (shop.runTime);