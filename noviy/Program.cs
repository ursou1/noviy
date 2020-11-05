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
           // 
            cat.HungryStatusChanged += Cat_HungryStatusChanged; // подписали Анфису
         //создаем еще кошку
           Cat cat2 = new Cat("Маша", new DateTime(1993, 9, 6));
           cat2.MakeNoise();
           cat2.HungryStatus = 60;
           Console.WriteLine($"Кошке по имени {cat2.Name} уже {cat2.GetAge()} лет");
           Console.WriteLine($"{cat2.HungryStatus}");
            cat2.HungryStatusChanged += Cat_HungryStatusChanged; // подписали Машу
            Console.ReadLine();
        }
        private static void Cat_HungryStatusChanged(object sender, EventArgs e)
        {
            Random rnd = new Random();
            Cat cat = (Cat)sender;
            if (cat.HungryStatus < 20 && rnd.Next(0, 10) < 5)
                cat.Feed();
            else
                cat.GetStatus();
        }
    }
}
