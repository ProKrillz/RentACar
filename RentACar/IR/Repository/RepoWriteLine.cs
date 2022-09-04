using RentACar.Enums;
using RentACar.IR.Interface;

namespace RentACar.IR.Repository
{
    public class RepoWriteLine : IWriteLine
    {
        /// <summary>
        /// Writeline for returning a string
        /// </summary>
        /// <param name="text"></param>
        /// <returns>input to string</returns>
        public string InputString(string text)
        {
            while (true)
            {
                Console.Write(text);
                string? input = Console.ReadLine();
                if (input.Length > 0)
                    return input;
            }
        }
        /// <summary>
        /// Writeline for returning only +int
        /// </summary>
        /// <param name="text"></param>
        /// <returns>input to +int</returns>
        public int InputUint(string text)
        {
            uint value;
            while (true)
            {
                Console.Write(text);
                try
                {
                    value = Convert.ToUInt32(Console.ReadLine());
                    return Convert.ToInt32(value);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        /// <summary>
        /// Writeline for returning only decimal
        /// </summary>
        /// <param name="text"></param>
        /// <returns>input to decimal</returns>
        public decimal InputDecimal(string text)
        {
            decimal value;
            while (true)
            {
                Console.Write(text);
                try
                {
                    return value = Convert.ToDecimal(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
        }
        public void WarningMsg(string txt)
        {
            Console.Clear();
            Console.WriteLine(txt);
            Console.ReadKey();
        }
        public void Menu(string name)
        {
            Console.Clear();
            Console.WriteLine(name);
            Console.WriteLine("\n1: Add car\n2: Show all cars\n3: Update car\n4: Delete car\n5: Create user\n6: Show all customer\n7: Update Customer\n8: Delete User\n");
        }
        public bool Login(string username, string password)
        {
            Console.Clear();
            Console.WriteLine("Login as admin\n");
            if (username == InputString("Username: ") & password == InputString("Password: "))
            {
                Console.Clear();
                return true;
            }
            Console.Clear();
            return false;
        }
        public CarType PickACarMenu()
        {
            while (true)
            {
                switch (InputUint("Pick a car model\n\n1: Convertible\n2: Sport\n3: Station\n\nChoise: "))
                {
                    case 1:
                        return CarType.Convertible;
                    case 2:
                        return CarType.Sport;
                    case 3:
                        return CarType.Station;
                    default:
                        break;
                }
            }
        }
        public Color PickAColorMenu()
        {
            while (true)
            {
                int count = 0;
                Console.Clear();
                Console.WriteLine("Pick a color\n");
                foreach (Color item in Enum.GetValues(typeof(Color)))
                    Console.WriteLine($"{++count}: {item}" );

                int value = InputUint("\nChoise: ");
                if (Enum.IsDefined(typeof(Color),value))
                    return ((Color)value);
            }  
        }
        public CarBrand PickACarBrandMenu()
        {
            while (true)
            {
                int count = 0;
                Console.Clear();
                Console.WriteLine("Pick a brand\n");
                foreach (CarBrand item in Enum.GetValues(typeof(CarBrand)))
                    Console.WriteLine($"{++count}: {item}");

                int value = InputUint("\nChoise: ");
                if (Enum.IsDefined(typeof(CarBrand), value))
                    return ((CarBrand)value);
            }
        }
        public PersonType PickPerson(string txt)
        {
            while (true)
            {
                Console.Clear();      
                switch (InputUint(txt))
                {
                    case 1:
                        return PersonType.Customer;
                        case 2:
                        return PersonType.Employer;
                    default:
                        break;
                }
            }
        }
        public void UpdateCustomerMenu()
        {
            Console.Clear();
            Console.WriteLine("Update\n\n1: Firstname\n2: Lastname\n3: Mail\n4: Phone\n5: Exit\n");
        }
    }
}
