using RentACar.Model;

namespace RentACar.IR.Repository;
public class RepoCar
{
    int _counter;
    private List<Car> _cars;
    public RepoCar()
    {
        _cars = new List<Car>();
    }
    public void CreateCarConvertible(string plate, string name) => _cars.Add(new Convertible(++_counter,plate,name));
    public void CreateCarSport(string plate, string name) => _cars.Add(new Sport(++_counter, plate, name));
    public void CreateCarStation(string plate, string name) => _cars.Add(new Station(++_counter, plate, name));
    public List<Car> GetAllCars() => _cars;
    public void DeleteCarById(int id)
    {
        Car? foundCar = _cars.Find(x => x.Id == id);
        if (foundCar != null)
            _cars.Remove(foundCar);
    }
}
