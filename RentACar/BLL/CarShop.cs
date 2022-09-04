using RentACar.IR.Interface;

namespace RentACar.BLL
{
    public class CarShop
    {
        public readonly ICustomer ici;
        public readonly ICar icari;
        public readonly IWriteLine iwi;
        public readonly IEmployer iei;
        readonly string _companyName;
        public bool runTime = true;

        public CarShop(string companyname, ICustomer? ci, ICar? cai, IWriteLine? wi, IEmployer ei)
        {
            _companyName = companyname;
            ici = ci;
            icari = cai;
            iwi = wi;
            iei = ei;
        }
        public string GetCompanyName() => _companyName;
    }
}
