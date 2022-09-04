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
    public List<Car> GetAllCars();
    public void DeleteCarById(int id);
}
