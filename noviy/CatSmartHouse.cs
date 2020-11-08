using System;
using System.Collections.Generic;
using System.Text;

namespace noviy
{
    class CatSmartHouse
    {

        List<Cat> cats = new List<Cat>();

        public CatSmartHouse(int foodResource)
        {
            FoodResource = FoodResource;
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

        private void Cat_HungryStatusChanged(object sender, EventArgs e)
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
                Console.WriteLine($"Покормлена кошка: {cat.Name}\nОстаток еды в вольере: {FoodResource}");
            }
        }
    }
}
