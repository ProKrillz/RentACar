using RentACar.Model;

namespace RentACar.IR.Interface;
public interface ICar
{
    public void CreateCarConvertible(string plate, string name);
    public void CreateCarSport(string plate, string name);
    public void CreateCarStation(string plate, string name);
    public void UpdateCar();
    public void DeleteCar();
    public string GetCarById();
    public List<Car> GetAllCars();
}
