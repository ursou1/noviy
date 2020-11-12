using System;
using System.Collections.Generic;
using System.Text;

namespace noviy
{
    class CommandCenter
    {
        public CommandCenter(CatSmartHouse AnotherName)
        {
            CatSmartHouse = AnotherName;
            WaitCommands(CatSmartHouse);
        }
        public CatSmartHouse CatSmartHouse
        { get; set; }
        public void WaitCommands(CatSmartHouse AnotherName)
        {
            string command = "";
            while (command != "exit")
            {
                Console.SetCursorPosition(0, CatSmartHouse.CatsCount + 2);
                command = Console.ReadLine();
                string[] array = command.Split();
                if (array[0] == "store")
                {
                    int namb = Convert.ToInt32(array[2]);
                    CatSmartHouse.FoodResource += namb;
                    Console.Write(array[1]);
                }
                if (array[0] == "cls")
                {
                    for (int i = 5; i < 10; i++)
                    {
                        Console.SetCursorPosition(0, i);
                        for (int j = 0; j < 100; j++)
                        {
                            Console.Write(' ');
                        }
                    }
                }
                if (array[0] == "help")
                {
                    Console.WriteLine("Добавить еды в вальер: store название еды количество ");
                    Console.WriteLine("Очистить консоль: cls");
                    Console.WriteLine("Изменить границу голода: ChangeHungryLimit +/- на сколько");
                    Console.WriteLine("Выход: exit");
                }
                if (array[0] == "ChangeHungryLimit")
                {
                    if (array[1] == "+")
                    {
                        AnotherName.hangrLimit -= Convert.ToInt32(array[2]);
                    }
                    else if (array[1] == "-")
                    {
                        AnotherName.hangrLimit += Convert.ToInt32(array[2]);
                    }
                }
            }
        }
    }
}
