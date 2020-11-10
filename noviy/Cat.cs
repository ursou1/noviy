using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace noviy
{
    class Cat
    {
        public event EventHandler HungryStatusChanged;
        byte _hungryStatus;
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

        public byte HungryStatus
        {
            get
            {
                return _hungryStatus;
            }

            set
            {
                byte s = value;
                if (s < 0)
                {
                     s = 0;
                }
                else if (s > 100)
                {
                     s = 100;
                }
                if (HungryStatus != s)
                {
                    HungryStatusChanged?.Invoke(this, null); // оператор ?. защищает нас от вызова события, на которое не подписан ни один метод
                }
                _hungryStatus = s;
            }
        }
        public void Feed(byte xorek)
        {
            HungryStatus += xorek;
        }

        public string GetStatus(string color)
        {
            string name = Name;
            string age = Convert.ToString(GetAge());
            string status = Convert.ToString(HungryStatus);
            Console.WriteLine($" {Name}, Возраст: {GetAge()}, {HungryStatus}");
            if (HungryStatus < 10)
            {
                color = Convert.ToString(Convert.ToInt32(Console.ForegroundColor = ConsoleColor.DarkRed));
            }
            else if (HungryStatus >= 10 && HungryStatus <= 40)
            {
                color = Convert.ToString(Convert.ToInt32(Console.ForegroundColor = ConsoleColor.Red));
            }
            else if (HungryStatus > 40 && HungryStatus <= 70)
            {
                color = Convert.ToString(Convert.ToInt32(Console.ForegroundColor = ConsoleColor.Yellow));
            }
            else if (HungryStatus > 70 && HungryStatus <= 90)
            {
                color = Convert.ToString(Convert.ToInt32(Console.ForegroundColor = ConsoleColor.Yellow));
            }
            else if (HungryStatus > 90)
            {
                color = Convert.ToString(Convert.ToInt32(Console.ForegroundColor = ConsoleColor.Green));
            }
            string getStatus = $"{color}, Имя: {name}, Возраст: {age}, Статус: {status}";
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
