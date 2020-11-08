using System;
using System.ComponentModel;

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
           // 
         //создаем еще кошку
           Cat cat1 = new Cat("Маша", new DateTime(1993, 9, 6));

            cat1.MakeNoise();
             cat1.HungryStatus = 60;
             Console.WriteLine($"Кошке по имени {cat1.Name} уже {cat1.GetAge()} лет");
             Console.WriteLine($"{cat1.HungryStatus}");
            
            CatSmartHouse chicken = new CatSmartHouse(100);
            chicken.AddCat(cat);
            chicken.AddCat(cat1);

            Console.ReadLine();
        }

       
    }
}
