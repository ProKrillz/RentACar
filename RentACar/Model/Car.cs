using RentACar.Enums;

namespace RentACar.Model;
public class Car
{
    public int Id { get; init; }
    public string Plate { get; set; }
    public string Name { get; set; }
    public double KmDrived { get; set; }
    public double Price { get; set; }
    public Color CarColor { get; set; }
    public CarBrand Brand { get; set; }
    public CarType Type { get; init; }
    public int Seat { get; set; }
    public int RentCustomerId { get; set; }
}
public class Convertible : Car
{
    public Convertible(int id, string plate, string name, Color color, CarBrand brand)
    {
        Id = id;
        Plate = plate;
        Name = name;
        Type = CarType.Convertible;
        CarColor = color;
        Brand = brand;
        Price = 250;
    }
}
public class Sport : Car
{
    public Sport(int id, string plate, string name, Color color, CarBrand brand)
    {
        Id = id;
        Plate = plate;
        Name = name;
        Type = CarType.Sport;
        CarColor = color;
        Brand = brand;
        Seat = 2;
        Price = 350;
    }
}
public class Station : Car
{
    public Station(int id, string plate, string name, Color color, CarBrand brand)
    {
        Id = id;
        Plate = plate;
        Name = plate;
        Type = CarType.Station;
        CarColor = color;
        Brand = brand;
        Price = 300;
    }
}

