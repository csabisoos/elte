# Sebesség út idő kódváltozatok

## Kód: egyenes vonalú egyenletes mozgás

Út-idő-sebesség kiszámítása, kód variációk  
előfeltétel és típusellenőrzés nélkül  
```cs
namespace ut_ido_sebesseg_class {
 internal class Program {
         static void Main(string[] args) {
             // Deklaráció
             double s, t; 
            double v; 
            // Beolvasás előfeltétel ellenőrzés nélkül
             Console.Write("Megtett út: ");
            s = Convert.ToDouble(Console.ReadLine()); 
           Console.Write("Eltelt idő: ");
            t = Convert.ToDouble(Console.ReadLine());
           // Feldolgozás
           v = s / t;
           // Kiírás
           Console.WriteLine("A sebesség: {0}", v);
         }
     }
 } 
```
Típus és előfeltétel ellenőrzéssel:  
```cs
namespace ut_ido {
  internal class Program {
    static void Main(string[] args) {
    // Deklaráció
    double s, t;
    double v;
    // Beolvasás típus és előfeltétel ellenőrzéssel
    Console.Write("Megtett út: ");
    if ((double.TryParse(Console.ReadLine(), out s)) && (s >= 0)) {
      Console.Write("Eltelt idő: ");
      if ((double.TryParse(Console.ReadLine(), out t)) && (t > 0)) {
        // Feldolgozás
        v = s / t;
        // Kiírás
        Console.WriteLine("A sebesség: {0}", v);
      } else {
        Console.WriteLine("Hiba, idő");
      }
    } else {
      Console.WriteLine("Hiba, út");
    }
  }
 }
}
```
