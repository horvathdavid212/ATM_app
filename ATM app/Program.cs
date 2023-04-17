using System;

public class kartyaTulajdonos
{
    string kartyaSzam;
    int pin;
    string keresztnev;
    string vezeteknev;
    int egyenleg;

    public kartyaTulajdonos(string kartyaSzam, int pin, string keresztnev, string vezeteknev, int egyenleg)
    {
        this.kartyaSzam = kartyaSzam;
        this.pin = pin;
        this.keresztnev = keresztnev;
        this.vezeteknev = vezeteknev;
        this.egyenleg = egyenleg;
    }

    public string getKartyaSzam()
    {
        return kartyaSzam;
    }
    public int getPin()
    {
        return pin;
    }
    public string getKeresztnev() 
    { 
        return keresztnev;
    }
    public string getVezeteknev()
    {
        return vezeteknev;
    }
    public int getEgyenleg()
    {
        return egyenleg;
    }

    public void setKartyaSzam(string ujKartyaSzam)
    {
        kartyaSzam = ujKartyaSzam;
    }
    public void setPin(int ujPin)
    {
        pin = ujPin;
    }
    public void setKeresztnev(string ujKeresztnev)
    {
        keresztnev = ujKeresztnev;
    }
    public void setVezeteknev(string ujVezeteknev)
    {
        vezeteknev = ujVezeteknev;
    }
    public void setEgyenleg(int ujEgyenleg)
    {
        egyenleg = ujEgyenleg;
    }

    public static void Main(string[] args)
    {
        void lehetosegek()
        {
            Console.WriteLine("Válasszon a következő lehetőségek közül...");
            Console.WriteLine("1. Betét");
            Console.WriteLine("2. Kivétel");
            Console.WriteLine("3. Egyenleg");
            Console.WriteLine("4. Kilép");
        }

        void betet(kartyaTulajdonos jelenlegiFelhasznalo)
        {
            Console.WriteLine("Mennyi pénzt kíván behelyezni?");
            int betet = int.Parse(Console.ReadLine());
            jelenlegiFelhasznalo.setEgyenleg(jelenlegiFelhasznalo.getEgyenleg()+betet);
            Console.WriteLine("Az új egyenlege: " + jelenlegiFelhasznalo.getEgyenleg());
        }

        void kivetel(kartyaTulajdonos jelenlegiFelhasznalo)
        {
            Console.WriteLine("Mennyi pénzt kíván kivenni?");
            int kivetel = int.Parse(Console.ReadLine());
            if (jelenlegiFelhasznalo.getEgyenleg() < kivetel)
            {
                Console.WriteLine("Nincs elegendő pénze a bankkártyáján.");
            }
            else
            {
                jelenlegiFelhasznalo.setEgyenleg(jelenlegiFelhasznalo.getEgyenleg() - kivetel);
                Console.WriteLine("Pénz kivétel sikeresen megtörtént.");
                Console.WriteLine("Az új egyenlege: " + jelenlegiFelhasznalo.getEgyenleg());
            }
        }

        void egyenleg(kartyaTulajdonos jelenlegiFelhasznalo)
        {
            Console.WriteLine("Egyenlege: " + jelenlegiFelhasznalo.getEgyenleg());
        }

        List<kartyaTulajdonos> kartyaTulajdonos = new List<kartyaTulajdonos>();
        kartyaTulajdonos.Add(new kartyaTulajdonos("1", 1, "David","Horvath", 300000));
        kartyaTulajdonos.Add(new kartyaTulajdonos("5519681166006601", 1524, "James", "Smith", 120000));
        kartyaTulajdonos.Add(new kartyaTulajdonos("5599922812408186", 4264, "Walter", "White", 320000000));
        kartyaTulajdonos.Add(new kartyaTulajdonos("5455266120852849", 1831, "Jesse", "Pinkman", 6600000));
        kartyaTulajdonos.Add(new kartyaTulajdonos("5383441318456862", 1664, "Saul", "Goodman", 1600500));

        Console.WriteLine("Üdvözüljük!");
        Console.WriteLine("Kérem helyezze be a bankkártyáját.");
        string bankKartyaSzam = "";
        kartyaTulajdonos jelenlegiFelhasznalo;

        while (true)
        {
            try
            {
                bankKartyaSzam = Console.ReadLine();
                //adatbázisban leellenőrzi az egyezést:
                jelenlegiFelhasznalo=kartyaTulajdonos.FirstOrDefault(a=>a.kartyaSzam==bankKartyaSzam);
                if (jelenlegiFelhasznalo != null) { break; }
                else { Console.WriteLine("Helytelen kártya. Kérem próbálja újra."); }
            }
            catch (Exception)
            {
                Console.WriteLine("Helytelen kártya. Kérem próbálja újra.");
            }
        }

        Console.WriteLine("Kérem adja meg pinkódját: ");
        int felhasznaloPin = 0;

        while (true)
        {
            try
            {
                felhasznaloPin = int.Parse(Console.ReadLine());
                if (jelenlegiFelhasznalo.getPin() == felhasznaloPin) { break; }
                else { Console.WriteLine("Helytelen PIN kód. Kérem próbálja újra."); }
            }
            catch (Exception)
            {
                Console.WriteLine("Helytelen PIN kód. Kérem próbálja újra.");
            }
        }

        Console.WriteLine("Üdvözöljük " + jelenlegiFelhasznalo.getKeresztnev()+"!");

        int opcio = 0;
        do
        {
            lehetosegek();
            try
            {
                opcio = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {

                throw;
            }
            if (opcio == 1) { betet(jelenlegiFelhasznalo); }
            else if (opcio == 2) { kivetel(jelenlegiFelhasznalo); }
            else if (opcio == 3) { egyenleg(jelenlegiFelhasznalo); }
            else if (opcio == 4) { break; }
            else { opcio = 0; }
        }
        while (opcio!=4);
        Console.WriteLine("Köszönjük! Legyen szép napja! :)");
    }
}