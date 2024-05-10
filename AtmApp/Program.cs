namespace AtmApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ATM atm = new ATM();
            Console.WriteLine("Lütfen ID Numaranızı giriniz:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Lütfen password giriniz:");
            string password = Console.ReadLine();
            atm.Login(id,password);
            string choice = Console.ReadLine();
            atm.ProccessChoice(choice);
        }
    }
}
