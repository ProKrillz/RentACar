using RentACar.IR.Interface;

namespace RentACar.BLL
{
    public class CarShop
    {
        public readonly ICar ici;
        public readonly IWriteLine iwi;
        readonly string _companyName;
        public bool runTime = true;
        public double Balance;

        public CarShop(string companyname, ICar cai, IWriteLine wi)
        {
            _companyName = companyname;
            ici = cai;
            iwi = wi;
        }
        public string GetCompanyName() => _companyName;
    }
}
