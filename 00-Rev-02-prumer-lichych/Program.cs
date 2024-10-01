namespace _00_Rev_02_prumer_lichych
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string vklad;
            double num;
            double celkem = 0;
            int pocet = 0;

            Console.WriteLine("Zadej celé číslo, nebo stop: ");

            while (true)
            {
                vklad = Console.ReadLine();

                if (vklad == "stop")
                    break;

                double.TryParse(vklad, out num);
                

                if (num > 0 && num % 2 != 0)
                {
                    celkem += num;
                    pocet++;
                }

                
                    
            }

            

            if(pocet == 0)
                Console.WriteLine("nebylo vloženo žádné kladné liché číslo");
            else
            {
                double prumer = celkem / pocet;
                Console.WriteLine(prumer);
            }
                
        }
    }
}
