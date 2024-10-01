namespace _00_Rev_01_poslední_dlouhe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] pole = { "Karel", "Jiřina", "Hnidoslav", "Lukáš" };
            

            Console.WriteLine(PosledniDlouhe(pole, 6));
            Console.WriteLine(PosledniDlouhe(pole, 2));
            Console.WriteLine(PosledniDlouhe(pole, 12));
        }

        public static string PosledniDlouhe(string[] pole, int limit)
        {
            string nejdelsi = "";

            for(int i = 0; i < pole.Length; i++)
            {
                if (pole[i].Length >= limit)
                    nejdelsi = pole[i];
                
            }

            return nejdelsi;
        }
    }
}
