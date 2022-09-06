
namespace RentACar.Model;
public class Reservation
{
    public int Id { get; init; }
    public int CustomerId { get; set; }
    public int CarId { get; set; }
    public int EmployerId { get; set; }
    public double Balance { get; set; }
    public DateTime RentDay { get; set; }
    public DateTime ExpectedDelviredDay { get; set; }
    public DateTime DelviredDay { get; set; }

    public Reservation(int carId, int customerId, int employerId, DateTime rentDay, int days)
    {
        Id = Convert.ToInt32(Convert.ToString(carId) + Convert.ToString(customerId) + Convert.ToString(employerId));
        CustomerId = customerId;
        CarId = carId;
        EmployerId = employerId;
        RentDay = rentDay;
        ExpectedDelviredDay = RentDay.AddDays(days);
    }
}
