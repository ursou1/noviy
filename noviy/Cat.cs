using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace noviy
{
    class Cat
    {
        public event EventHandler HungryStatusChanged;
        sbyte _hungryStatus;
        int min = 10;
        int mid40 = 40;
        int mid70 = 70;
        int max = 90;
        public string Name
        {
            get;
            set;
        }
        public Cat(string name, DateTime birthday)
        {
            Name = name;
            Birthday = birthday;
            Task.Run(LifeCircle);
        }
        public void MakeNoise()
        {
            Console.WriteLine($"{Name} мяукает");
        }
        public DateTime Birthday
        {
            get;
            set;
        }
        public int GetAge()
        {
            return (DateTime.Today - Birthday).Days / 365;
        }

        public sbyte HungryStatus
        {
            get
            {
                return _hungryStatus;
            }
            set
            {
                sbyte s = value;
                if (s < 0)
                {
                    s = 0;
                }
                else if (s > 100)
                {
                    s = 100;
                }
                else
                    _hungryStatus = value;
                if (_hungryStatus < s)
                {
                    HungryStatusChanged?.Invoke(this, null);
                }

                _hungryStatus = s;
            }
        }
        public void Feed(sbyte needFood)
        {
            HungryStatus += needFood;
        }

        public string GetStatus(string color)
        {
            if (HungryStatus <= min)
            {
                color = Convert.ToString(Convert.ToInt32(Console.ForegroundColor = ConsoleColor.DarkRed));
            }
            else if (HungryStatus > min && HungryStatus <= mid40)
            {
                color = Convert.ToString(Convert.ToInt32(Console.ForegroundColor = ConsoleColor.Red));
            }
            else if (HungryStatus > mid40 && HungryStatus <= mid70)
            {
                color = Convert.ToString(Convert.ToInt32(Console.ForegroundColor = ConsoleColor.DarkYellow));
            }
            else if (HungryStatus > mid70 && HungryStatus <= max)
            {
                color = Convert.ToString(Convert.ToInt32(Console.ForegroundColor = ConsoleColor.Yellow));
            }
            else if (HungryStatus > max)
            {
                color = Convert.ToString(Convert.ToInt32(Console.ForegroundColor = ConsoleColor.Green));
            }
            string name = Name;
            string age = Convert.ToString(GetAge());
            string status = Convert.ToString(HungryStatus);
            string getStatus = $"{color} {name} {age} {status}";
            return getStatus;
        }
        async Task LifeCircle()
        {
            await Task.Delay(1000);
            HungryStatus -= 10;
            await LifeCircle();
        }
        
    }
}
