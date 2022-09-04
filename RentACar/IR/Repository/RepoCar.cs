using RentACar.IR.Interface;
using RentACar.Model;

using RentACar.Enums;

namespace RentACar.IR.Repository;
public class RepoCar : ICar
{
    int _counter;
    private List<Car> _cars;
    public RepoCar()
    {
        _cars = new List<Car>();
    }
    public void CreateCarConvertible(string plate, string name, Color color, CarBrand brand) => _cars.Add(new Convertible(++_counter,plate,name, color, brand));
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
    public void DeleteCarById(int id)
    {
        Car? foundCar = _cars.Find(x => x.Id == id);
        if (foundCar != null)
            _cars.Remove(foundCar);
    }
}
