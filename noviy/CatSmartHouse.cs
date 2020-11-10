using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace noviy
{
    class CatSmartHouse
    {

        List<Cat> cats = new List<Cat>();

        void PrintStatus()
        {
            int leftPosition = Console.CursorLeft;
            int topPosition = Console.CursorTop;

            for (int i = 0; i < cats.Count; i++)
            {
                string message = cats[i].GetStatus("");
                int color = Convert.ToInt32(message.Substring(0, 1));
                Console.SetCursorPosition(0, i);
                Console.ForegroundColor = (ConsoleColor)color;
                Console.Write(message.Substring(2).Trim().PadRight(50));
                Console.ResetColor();
                
            }
            Console.SetCursorPosition(0, CatsCount);
            Console.Write($"Еды в вольере: + {FoodResourse}".PadRight(50));
            Console.SetCursorPosition(leftPosition, topPosition);
        }


        public CatSmartHouse(int foodResource)
        {
            FoodResource = foodResource;
        }
        public void AddCat(Cat cat)
        {
            cats.Add(cat);
            cat.HungryStatusChanged += Cat_HungryStatusChanged;
        }
        public int FoodResource
        {
            get;
            set;
        }
        public int CatsCount
        {
            get
            {
                return cats.Count;
            }
        }
        public int FoodResourse { get; set; }

        public void Cat_HungryStatusChanged(object sender, EventArgs e)
        {
            var cat = (Cat)sender;
            if (cat.HungryStatus <= 20 && FoodResource > 0)
            {
                byte needFood = (byte)(100 - cat.HungryStatus);
                if (FoodResource > needFood)
                    FoodResource -= needFood;
                else
                {
                    needFood = (byte)FoodResource;
                    FoodResource = 0;
                }
                cat.Feed(needFood);
                PrintStatus();
            }
        }
    }
}
