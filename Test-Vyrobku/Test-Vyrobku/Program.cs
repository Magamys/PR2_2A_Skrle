namespace Test_vyrobku
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vyrobek vzor = new Vyrobek(34);
            tester tester = new tester(vzor, 19.5);

            Vyrobek vyrobek1 = new Vyrobek(2.5);
            Vyrobek vyrobek2 = new Vyrobek(23.5);
            Vyrobek vyrobek3 = new Vyrobek(17.9);

            bool x;

            x = tester.IsGood(vyrobek1, tester.Tolerance);
            if (x = true)
                Console.WriteLine("Výrobek 1 je dobrý.");
            else
                Console.WriteLine("Výrobek 1 není v míře.");

            x = tester.IsGood(vyrobek2, tester.Tolerance);
            if (x = true)
                Console.WriteLine("Výrobek 2 je dobrý.");
            else
                Console.WriteLine("Výrobek 2 není v míře.");

            x = tester.IsGood(vyrobek3, tester.Tolerance);
            if (x = true)
                Console.WriteLine("Výrobek 3 je dobrý.");
            else
                Console.WriteLine("Výrobek 3 není v míře.");

        }
    }
}
