using System;
using System.ComponentModel;

namespace noviy
{
    class Program
    {
        static void Main(string[] args)
        {
           Cat cat = new Cat("Анфиса", new DateTime(2015, 10, 11));
           Cat cat1 = new Cat("Маша", new DateTime(1993, 9, 6));
           
            CatSmartHouse cats = new CatSmartHouse(100);
            {
                cats.AddCat(cat);
                cats.AddCat(cat1);
            }
            //cat.HungryStatus = 150;
            //cat1.HungryStatus = 60;
            Console.SetCursorPosition(0, cats.CatsCount + 1);
            CommandCenter command = new CommandCenter(cats);
            Console.ReadLine();
        }
       
    }
}
