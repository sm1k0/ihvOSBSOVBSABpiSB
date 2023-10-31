using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoolConsoleApp2
{
    internal class Cakes
    {


        private int SelectedIndex;
        private string Label;
        private List<string> Options;
        private int price;
        private string Cake;

        public void Menu()
        {
            Console.Clear();

            ConsoleKey keyPressed;

            Label = "Пироги.";

            string[] options = { "Форма пирога", "Размер пирога", "Вкус пирога", "Количество пирога", "Глазурь", "Декор","Я слушаю только шамана и гимн Росиии","Конец заказа" };
            Options = new List<string>(options);

            int selectedIndex = Run();

            switch (selectedIndex)
            {
                case 0:
                    SelectedIndex = 0;
                    Console.Clear();
                    MenuForm();
                    break;
                case 1:
                    SelectedIndex = 0;
                    Console.Clear();
                    MenuSize();
                    break;
                case 2:
                    SelectedIndex = 0;
                    Console.Clear();
                    MenuTaste();
                    break;
                case 3:
                    SelectedIndex = 0;
                    Console.Clear();
                    MenuCountOfCakeSlice();
                    break;
                case 4:
                    SelectedIndex = 0;
                    Console.Clear();
                    MenuGlaze();
                    break;
                case 5:
                    SelectedIndex = 0;
                    Console.Clear();
                    MenuDecor();
                    break;
                case 6:
                    SelectedIndex = 0;
                    Console.Clear();
                    Shaman();
                    break;
                case 7:
                    SelectedIndex = 0;
                    AddOrderToBook();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nЗаказ создан. Для выхода нажмите ESC.");
                    Console.ResetColor();
                    break;
            }
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            keyPressed = keyInfo.Key;
            if (keyPressed == ConsoleKey.Escape)
            {
                Console.Clear();
            }
            Menu();
        }

        private void MenuForm()
        {
            Label = "Форма";

            string[] options = { "Круг - 5", "Квадрат - 5", "Сердечко - 6", "Звездочка - 6" };
            Options = new List<string>(options);

            int selectedIndex = Run();

            switch (selectedIndex)
            {
                case 0:
                    price += 5;
                    Cake += options[0] + "\n";
                    break;
                case 1:
                    price += 5;
                    Cake += options[1] + "\n";
                    break;
                case 2:
                    price += 6;
                    Cake += options[2] + "\n";
                    break;
                case 3:
                    price += 6;
                    Cake += options[3] + "\n";
                    break;
            }

            Console.Clear();
            Menu();
        }

        private void MenuSize()
        {

            Label = "Размер.";

            string[] options = { "Маленький (Диаметр - 10 см, 10 порций) - 10", "Обычный (Диаметр - 20 см, 20 порций) - 12", "Большой (Диаметр - 30 см, 30 порций) - 20" };
            Options = new List<string>(options);

            int selectedIndex = Run();

            switch (selectedIndex)
            {
                case 0:
                    price += 10;
                    Cake += options[0] + "\n";
                    break;
                case 1:
                    price += 12;
                    Cake += options[1] + "\n";
                    break;
                case 2:
                    price += 20;
                    Cake += options[2] + "\n";
                    break;
            }

            Console.Clear();
            Menu();
        }

        private void MenuCountOfCakeSlice()
        {
            Label = "Количество коржей";

            string[] options = { "1 - 1", "2 - 2", "3 - 3", "4 - 4000000" };
            Options = new List<string>(options);

            int selectedIndex = Run();

            switch (selectedIndex)
            {
                case 0:
                    price = price + 1;
                    Cake += "Количество коржей: " + options[0] + "\n";
                    break;
                case 1:
                    price += 2;
                    Cake += "Количество коржей: " + options[1] + "\n";
                    break;
                case 2:
                    price += 3;
                    Cake += "Количество коржей: " + options[2] + "\n";
                    break;
                case 3:
                    price += 4000000;
                    Cake += "Количество коржей: " + options[3] + "\n";
                    break;
               
            }

            Console.Clear();
            Menu();
        }

        private void MenuTaste()
        {
            Label = "Вкус коржей";

            string[] options = { "Ванильны - 1", "Шоколадный - 1", "Карамельный - 1", "Ягодный - 1" };
            Options = new List<string>(options);

            int selectedIndex = Run();

            switch (selectedIndex)
            {
                case 0:
                    price = price + 1;
                    Cake += options[0] + "\n";
                    break;
                case 1:
                    price += 1;
                    Cake += options[1] + "\n";
                    break;
                case 2:
                    price += 1;
                    Cake += options[2] + "\n";
                    break;
                case 3:
                    price += 1;
                    Cake += options[3] + "\n";
                    break;
                
            }

            Console.Clear();
            Menu();
        }

        private void MenuGlaze()
        {
            Label = "Вкус глазури";

            string[] options = { "Ванильная - 3", "Шоколадная - 2", "Карамельная - 2", "Ягодная - 2" };
            Options = new List<string>(options);

            int selectedIndex = Run();

            switch (selectedIndex)
            {
                case 0:
                    price = price + 3;
                    Cake += options[0] + "\n";
                    break;
                case 1:
                    price += 2;
                    Cake += options[1] + "\n";
                    break;
                case 2:
                    price += 2;
                    Cake += options[2] + "\n";
                    break;
                case 3:
                    price += 2;
                    Cake += options[3] + "\n";
                    break;
            }

            Console.Clear();
            Menu();
        }

        private void MenuDecor()
        {
            Label = "Декор";

            string[] options = { "Ягоды - 3", "Шоколадная крошка - 2", "Окрошка - 2", "Окошко - 2", "Баяс - 2"};
            Options = new List<string>(options);

            int selectedIndex = Run();

            switch (selectedIndex)
            {
                case 0:
                    price = price + 3;
                    Cake += options[0] + "\n";
                    break;
                case 1:
                    price += 2;
                    Cake += options[1] + "\n";
                    break;
                case 2:
                    price += 2;
                    Cake += options[2] + "\n";
                    break;
                case 3:
                    price += 2;
                    Cake += options[3] + "\n";
                    break;
                case 4:
                    price += 4;
                    Cake += options[4] + "\n";
                    break;
                case 5:
                    price += 2;
                    Cake += options[5] + "\n";
                    break;
            }

            Console.Clear();
            Menu();
        }

        private void Shaman()
        {
            Label = "Декор";

            string[] options = { "Молодец заказ беспатлный " };
            Options = new List<string>(options);

            int selectedIndex = Run();

            switch (selectedIndex)
            {
                case 0:
                    price -= price;
                    break;
                
            }

            Console.Clear();
            Menu();
        }
        private void AddOrderToBook()
        {
            string order = $"{DateTime.Now}   Цена заказа: {price}. Заказ: {Cake}\n";
            string path = @"Orders.txt";
            File.AppendAllText(path, order);
        }
        private int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                DisplayOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                UpdateSelectedIndex(keyPressed);
            } while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;
        }

        private void DisplayOptions()
        {
            new Thread(() =>
            {
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(Label);

                for (int i = 0; i < Options.Capacity; i++)
                {
                    string currentOption = Options[i];

                    if (i == SelectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else if (i == Options.Capacity - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine(currentOption);

                }

                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nЦена:{price} \nВаш пирог:{Cake}");
                Console.ResetColor();
            }).Start();
        }

        private void UpdateSelectedIndex(ConsoleKey keyPressed)
        {
            if (keyPressed == ConsoleKey.UpArrow)
            {
                SelectedIndex--;
                if (SelectedIndex == -1)
                {
                    SelectedIndex = Options.Capacity - 1;
                }
            }
            else if (keyPressed == ConsoleKey.DownArrow)
            {
                SelectedIndex++;
                if (SelectedIndex == Options.Capacity)
                {
                    SelectedIndex = 0;
                }
            }
        }

    }
}
