internal class Program
{
    static Random random = new Random(123456);
    public static void Main(string[] args)
    {

        int cartAmount = 50;
        int start = 0;
        int end = 50;
        int maxCustomersPerMinute = 6;
        int minTime = 5;
        int maxTime = 45;

        Stack<Cart> voziky = new Stack<Cart>();

        for (int i = 0; i < cartAmount; i++)
        {
            voziky.Push(new Cart(i + 1));
        }

        Day(start, end, maxCustomersPerMinute, minTime, maxTime, voziky, cartAmount);
    }

    static void Day(int time, int end, int maxCustomersPerMinute, int minTime, int maxTime, Stack<Cart> voziky, int cartAmount)
    {
        List<Cart> vraceneVoziky;
        List<Cart> vozikyVProvozu = new List<Cart>();
        Queue<Customer> zakaznici = new Queue<Customer>();

        while (end > time || vozikyVProvozu.Count > 0)
        {
            vraceneVoziky = new List<Cart>();

            if (end > time)
            {
                int pocetNovychZakazniku = random.Next(maxCustomersPerMinute);
                for (int i = 0; i < pocetNovychZakazniku; i++)
                {
                    Customer zakaznik = new Customer(random.Next(minTime, maxTime));
                    zakaznici.Enqueue(zakaznik);
                }

                Console.WriteLine("počet zákazníků: " + zakaznici.Count);

                while (voziky.Count > 0 && zakaznici.Count > 0)
                {
                    Customer zakaznik = zakaznici.Dequeue();
                    Cart vozik = voziky.Pop();
                    vozik.Vyrid(zakaznik);
                    vozikyVProvozu.Add(vozik);
                }
            }

            time++;

            foreach (var vozikVProvozu in vozikyVProvozu)
            {
                if (!vozikVProvozu.PouzivaSe())
                {
                    vraceneVoziky.Add(vozikVProvozu);
                }
            }
            foreach (var vracenyVozik in vraceneVoziky)
            {
                vozikyVProvozu.Remove(vracenyVozik);
                voziky.Push(vracenyVozik);
            }

            Console.WriteLine($"V čase {time} byl počet volných vozíků {voziky.Count} a počet vozíků v provozu {vozikyVProvozu.Count}.");


        }



        Console.WriteLine("Celkový čas strávený lidmi v marketu: " + time);
        Console.WriteLine($"Lidi, kteří nestihli dostat vozík: " + zakaznici.Count);

        foreach (var vozik in voziky)
        {
            Console.WriteLine($"Vozík číslo {vozik.ID} -- byl v provozu {vozik.Fatigue} minut");
        }

    }

}







internal class Customer
{
    public int Trvani { get; private set; }

    public Customer(int trvani)
    {
        Trvani = trvani;
    }
}







internal class Cart

{
    public int Fatigue { get; private set; }
    public int ID { get; private set; }
    public int FreeWhen { get; private set; }

    public Cart(int id)
    {
        ID = id;
        FreeWhen = 0;
        Fatigue = 0;
    }

    public void Vyrid(Customer clovek)
    {
        Fatigue += clovek.Trvani;
        FreeWhen = clovek.Trvani;
    }

    public bool PouzivaSe()
    {
        FreeWhen--;
        return FreeWhen > 0;
    }
}