
namespace RentACar.Model;
public class Reservation
{
    public int Id { get; init; }
    public int CustomerId { get; set; }
    public int CarId { get; set; }
    public DateTime RentDay { get; set; }
    public DateTime ExpectedDelviredDay { get; set; }
    public DateTime DelviredDay { get; set; }

    public Reservation(int carId, int customerId, int days)
    {
        Id = Convert.ToInt32(Convert.ToString(carId) + Convert.ToString(customerId));
        CustomerId = customerId;
        CarId = carId;
        RentDay = DateTime.Now;
        ExpectedDelviredDay = RentDay.AddDays(days);
    }
}
