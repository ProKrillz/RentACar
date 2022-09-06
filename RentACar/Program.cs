using Microsoft.Extensions.DependencyInjection;
using RentACar.BLL;
using RentACar.IR.Interface;
using RentACar.IR.Repository;

var serviceProvider = new ServiceCollection().AddSingleton<ICar, RepoCar>().AddSingleton<IWriteLine, RepoWriteLine>().BuildServiceProvider();

CarShop shop = new CarShop("Rent Cars Of Doom", serviceProvider.GetService<ICar>(), serviceProvider.GetService<IWriteLine>());

do
{
    shop.iwi.Menu(shop.GetCompanyName());
    switch (shop.iwi.InputUint("Choice: "))
    {
        case 1:
            shop.ici.CreateCar();
            break;
        case 2:
            shop.ici.PrintCarList();
            Console.ReadKey();
            break;
        case 3:
            shop.ici.UpdateCar();
            break;
        case 4:
            shop.ici.DeleteCar();
            break;
        case 5:
            shop.ici.CreaterPerson();
            break;
        case 6:
            shop.ici.PrintPersonMenu();
            break;
        case 7:
            shop.ici.UpdatePerson();
            break;
        case 8:
            shop.ici.DeletePerson();
            break;
        case 9:
            shop.ici.ReservationMenu();
            break;
        default:
            break;
    }
} while (shop.runTime);