
namespace RentACar.IR.Repository
{
    public class RepoWriteLine
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
    }
}
