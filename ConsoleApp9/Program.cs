using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConfectioneryConsoleApp
{
    // Класс, представляющий подпункт меню
    public class MenuItem
    {
        public string Description { get; }
        public decimal Price { get; }

        public MenuItem(string description, decimal price)
        {
            Description = description;
            Price = price;
        }
    }

    // Класс, представляющий стрелочное меню
    public static class ArrowMenu
    {
        public static int ShowMenu(IEnumerable<MenuItem> options, string category)
        {
            Console.WriteLine($"{category}\n");

            int currentPosition = 0;

            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                Console.WriteLine($"{category}\n");
                for (int i = 0; i < options.Count(); i++)
                {
                    Console.WriteLine($"{(currentPosition == i ? "->" : "   ")} {options.ElementAt(i).Description} - {options.ElementAt(i).Price:C}");
                }

                key = Console.ReadKey();

                if (key.Key == ConsoleKey.UpArrow && currentPosition > 0)
                {
                    currentPosition--;
                }
                else if (key.Key == ConsoleKey.DownArrow && currentPosition < options.Count() - 1)
                {
                    currentPosition++;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    return -1;
                }

            } while (key.Key != ConsoleKey.Enter);

            return currentPosition;
        }
    }

    // Класс для заказа
    public class CakeOrder
    {
        private decimal price;
        private string cakeDescription;
        private int currentMenuLevel;

        private Dictionary<string, List<MenuItem>> menuOptions = new Dictionary<string, List<MenuItem>>
        {
            { "Форма", new List<MenuItem> { new MenuItem("Круг", 5), new MenuItem("Квадрат", 5), new MenuItem("Сердечко", 6), new MenuItem("Звездочка", 6) } },
            { "Размер", new List<MenuItem> { new MenuItem("Маленький", 10), new MenuItem("Обычный", 12), new MenuItem("Большой", 20) } },
            { "Количество коржей", new List<MenuItem> { new MenuItem("1", 1), new MenuItem("2", 2), new MenuItem("3", 3), new MenuItem("4", 4000000) } },
            { "Вкус коржей", new List<MenuItem> { new MenuItem("Ванильный", 1), new MenuItem("Шоколадный", 1), new MenuItem("Карамельный", 1), new MenuItem("Ягодный", 1) } },
            { "Вкус глазури", new List<MenuItem> { new MenuItem("Ванильная", 3), new MenuItem("Шоколадная", 2), new MenuItem("Карамельная", 2), new MenuItem("Ягодная", 2) } },
            { "Декор", new List<MenuItem> { new MenuItem("Ягоды", 3), new MenuItem("Шоколадная крошка", 2), new MenuItem("Окрошка", 2), new MenuItem("Окошко", 2), new MenuItem("Баяс", 2) } }
        };

        public void PlaceOrder()
        {
            currentMenuLevel = 0;

            do
            {
                DisplayMenuCategory(menuOptions.Keys.ElementAt(currentMenuLevel));

            } while (currentMenuLevel < menuOptions.Count);

            AddOrderToBook();

            Console.WriteLine($"Итого: {price:C}");
            Console.WriteLine("Заказ сохранен в файл.");

            Console.Write("Желаете сделать еще заказ? (Y/N): ");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.Clear();
                PlaceOrder();
            }
        }

        private void DisplayMenuCategory(string category)
        {
            Console.WriteLine($"{category}\n");

            for (int i = 0; i < menuOptions[category].Count; i++)
            {
                var option = menuOptions[category][i];
                Console.WriteLine($"{(i == 0 ? "->" : "   ")} {option.Description} - {option.Price:C}");
            }

            int selectedIndex = ArrowMenu.ShowMenu(menuOptions[category], category);

            if (selectedIndex == -1 && currentMenuLevel > 0)
            {
                currentMenuLevel--;
            }
            else if (selectedIndex != -1 && currentMenuLevel < menuOptions.Count - 1)
            {
                if (category == "Декор")
                {
                    ProcessDecorOption(menuOptions[category][selectedIndex].Description);
                }
                else
                {
                    string selectedOption = menuOptions[category][selectedIndex].Description;
                    decimal optionPrice = menuOptions[category][selectedIndex].Price;

                    price += optionPrice;
                    cakeDescription += $"{category}: {selectedOption} - {optionPrice:C}\n";

                    currentMenuLevel++;
                }
            }
            else if (selectedIndex != -1 && currentMenuLevel == menuOptions.Count - 1)
            {
                FinishOrder();
            }
        }

        private void ProcessDecorOption(string decorOption)
        {
            price += menuOptions["Декор"].Find(item => item.Description == decorOption).Price;
            cakeDescription += $"{decorOption} - {menuOptions["Декор"].Find(item => item.Description == decorOption).Price:C}\n";
            currentMenuLevel++;
        }

        private void FinishOrder()
        {
            Console.Clear();

            string order = $"{DateTime.Now}   Цена заказа: {price:C}. Заказ: {cakeDescription}\n";
            string path = "Orders.txt";
            File.AppendAllText(path, order);

            Console.WriteLine($"Итого: {price:C}");
            Console.WriteLine("Заказ сохранен в файл.");

            Console.Write("Желаете сделать еще заказ? (Y/N): ");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                price = 0;
                cakeDescription = "";
                currentMenuLevel = 0;
                Console.Clear();
                PlaceOrder();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void AddOrderToBook()
        {
            string order = $"{DateTime.Now}   Цена заказа: {price:C}. Заказ: {cakeDescription}\n";
            string path = "Orders.txt";
            File.AppendAllText(path, order);
        }

        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Добро пожаловать в кондитерскую!");

                CakeOrder order = new CakeOrder();
                order.PlaceOrder();
            }
        }
    }
}
