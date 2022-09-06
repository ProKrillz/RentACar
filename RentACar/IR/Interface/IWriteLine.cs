using RentACar.Enums;
using RentACar.Model;

namespace RentACar.IR.Interface;
public interface IWriteLine
{
    public string InputString(string text);
    public int InputUint(string text);
    public decimal InputDecimal(string text);
    public void WarningMsg(string txt);
    public void Menu(string name);
    public bool Login(string admin, string password);
    public CarType PickACarTypeMenu();
    public Color PickAColorMenu();
    public CarBrand PickACarBrandMenu();
    public PersonType PickPerson(string txt);
    public void UpdateCustomerMenu();
}
