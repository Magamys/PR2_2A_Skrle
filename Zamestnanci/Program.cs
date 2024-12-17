namespace Zamestnanci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Firma company = new Firma();

            StalyZmestnanec Pepa = new StalyZmestnanec("Josef", "Novotný", 28000);
            company.Zamestnej(Pepa);

            StalyZmestnanec Karel = new StalyZmestnanec("Karel", "Smutný", 27000);
            company.Zamestnej(Karel);

            Brigadnik Jarda = new Brigadnik("Jaroslav", "Černý");
            company.Zamestnej(Jarda);
            company.Zamestnej(Jarda); //neobjeví se na výplatnici podruhé
            Jarda.Odpracovano = 98;
            Jarda.HodinovaMzda = 170;

            Dobrovolnik Ivan = new Dobrovolnik("Ivan", "Zelenka");
            company.Zamestnej(Ivan);

            company.Vyplata(); //vypíše plat pro Pepu, Jardu a nulu pro Ivana - celkem 71660,- Kč
        }
    }
}
