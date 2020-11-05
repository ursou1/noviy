using System;

namespace noviy
{
    class Program
    {
        static void Main(string[] args)
        {
           Cat cat = new Cat("Анфиса", new DateTime(2015, 10, 11));
           cat.MakeNoise();
           Console.WriteLine($"Кошке по имени {cat.Name} уже {cat.GetAge()} лет");
           cat.HungryStatus = 150;
           Console.WriteLine($"{cat.HungryStatus}");
           Console.ReadLine();
            // 111

            
        }
    }
}
