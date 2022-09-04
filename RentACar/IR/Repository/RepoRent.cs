using RentACar.IR.Interface;
using RentACar.Model;

namespace RentACar.IR.Repository;
public class RepoRent
{
    private List<Reservation> _reservation;

    public RepoRent()
    {
        _reservation = new();
    }
    public void RentCar(Car car, Customer customer, Employer employer, int days)
    {
        if (car.RentCustomerId == null)
        {
            Reservation rent = new Reservation(car.Id, customer.Id, days);
            _reservation.Add(rent);
            car.RentCustomerId = customer.Id;
            employer.SoldRentCar.Add(rent);
        }
    }
    public void DeliverCar(Reservation res)
    {
        
        
    }
}
