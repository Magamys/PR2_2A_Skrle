namespace _00_Rev_02_prumer_lichych
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string vklad;
            int num;
            int celkem = 0;
            int i = 0;
            

            Console.WriteLine("Zadej celé číslo, nebo stop: ");

            while (true)
            {
                vklad = Console.ReadLine();

                if (vklad == "stop")
                    break;

                int.TryParse(vklad, out num);

                if (num > 0 && num % 2 != 0)
                {
                    celkem += num;
                    i++;
                }
                    
            }

            double prumer = celkem / i;

            if(i == 0)
                Console.WriteLine("nebylo vloženo žádné kladné liché číslo");
            else
                Console.WriteLine(prumer);
        }
    }
}
