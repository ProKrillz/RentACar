using RentACar.IR.Interface;

namespace RentACar.BLL
{
    public class CarShop
    {
        public readonly ICustomer ici;
        private string _adminName;
        private string _adminPassword;
        readonly string _companyName;

        public CarShop(string companyname, string adminName, string adminPassword, ICustomer ci)
        {
            _companyName = companyname;
            _adminName = adminName;
            _adminPassword = adminPassword;
            ici = ci;
        }
    }
}
