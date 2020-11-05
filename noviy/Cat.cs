using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace noviy
{
    class Cat
    {
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
        public byte _hungryStatus;

        public byte HungryStatus
        {
            get
            {
                return _hungryStatus;
            }

            set
            {
                if (value < 0)
                {
                     _hungryStatus = 0;
                }
                else if (value > 100)
                {
                     _hungryStatus = 100;
                }
                else
                {
                    _hungryStatus = value;
                }
                if (HungryStatus != _hungryStatus)
                {
                    HungryStatusChanged?.Invoke(this, null); // оператор ?. защищает нас от вызова события, на которое не подписан ни один метод
                }
            }
        }
        public void GetStatus()
        {
            Console.WriteLine($"{Name}");
            Console.WriteLine($"Возраст {GetAge()}");
            if (HungryStatus <= 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{Name} умирает от голода");
                Console.ResetColor();
            }
            else if (HungryStatus > 10 && HungryStatus <= 40)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{Name} очень голодна");
                Console.ResetColor();
            }
            else if (HungryStatus > 40 && HungryStatus <= 70)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{Name} хочет кушать");
                Console.ResetColor();
            }
            else if (HungryStatus > 70 && HungryStatus <= 90)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{Name} не против перекусить");
                Console.ResetColor();
            }
            else if (HungryStatus > 90)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{Name} недавно поела");
                Console.ResetColor();
            }
        }
        async Task LifeCircle()
        {
            await Task.Delay(10000);
            HungryStatus -= 10;
            await LifeCircle();
        }
        public event EventHandler HungryStatusChanged;

        public void Feed()
        {
            HungryStatus = 100;
        }
    }
}
