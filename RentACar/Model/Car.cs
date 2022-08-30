using RentACar.Enum;

namespace RentACar.Model;
public class Car
{
    public int Id { get; init; }
    public string Plate { get; set; }
    public string Name { get; set; }
    public double KmDrived { get; set; }
    public Color CarColor { get; set; }
    public CarBrand Brand { get; set; }
    public CarType Type { get; init; }
    public int Seat { get; set; }
}
public class Convertible : Car
{
    public Convertible(int id, string plate, string name)
    {
        Id = id;
        Plate = plate;
        Name = name;
        Type = CarType.Convertible;
    }
}
public class Sport : Car
{
    public Sport(int id, string plate, string name)
    {
        Id = id;
        Plate = plate;
        Name = name;
        Type = CarType.Sport;
        Seat = 2;
    }
}
public class Station : Car
{
    public Station(int id, string plate, string name)
    {
        Id = id;
        Plate = plate;
        Name = plate;
        Type = CarType.Station;
    }
}

