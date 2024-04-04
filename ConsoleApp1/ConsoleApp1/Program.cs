using System;
using System.Collections.Generic;
using System.IO;
namespace laba_3
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберете действие: \n 1: создавать List \n 2: создавать Dictionary");
            //создаю ветвление что бы дать выбор что создать
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    MyList();
                    break;
                case 2:
                    MyDictionary ();
                    break;
                default:
                    Console.WriteLine("Вы ввели не ту цыфру.");
                    break;
            }

        }
        public static void MyList()
        {
            //создаю список, в который можно добавлять значения безгранично 
            List<string> list = new List<string>();
            //создаю действия 
            while (true)
            {
                Console.WriteLine("\nВыберите действие: \n 1. Добавить элемент \n 2. Удалить элемент \n 3. Редактировать элемент" +
                    " \n 4. Просмотреть элементы \n 5. Сохранить " +
                    "\n 6. Перевернуть список \n 7. Сортировать \n 8.Обратная сортировка \n 9. Выход \n 10. Загрузить список");
                switch  (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("Введите элемент для добавления: ");
                        list.Add(Console.ReadLine());
                        break;
                    case 2:

                        Console.WriteLine("Введите элемент для удаления: ");
                        int index = Convert.ToInt32(Console.ReadLine());
                        //проверка индекса
                        if (index >= 0 && index < list.Count)
                            list.RemoveAt(index);
                        else
                            Console.WriteLine("Некоректный индекс.");
                        break;
                    case 3:
                        Console.WriteLine("Введите индекс для редактирования: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        if (id >= 0 && id < list.Count)
                        {
                            Console.WriteLine("Введите новое значение: ");
                            list[id] = Console.ReadLine();
                        }
                        else
                            Console.WriteLine("Некоректный индекс.");
                        break;
                    case 4:
                        //вывод всез элиментов на экран вместье с индексом
                         int namb = 0;
                        foreach (var i in list)
                        {
                            Console.WriteLine(namb + ": "  + i);
                            namb++;

                        }
                        break;
                    case 5:
                        //сохронение в файл
                        File.WriteAllLines("myTextFile.txt", list);
                        break;
                        //c 6 по 8 сортировки 
                    case 6: 
                        list.Reverse();
                        break;
                    case 7:
                        list.Sort();
                        break;
                    case 8:
                        list.Sort();
                        list.Reverse();
                        break;
                    case 9:
                        //прерывание программы;
                        return;
                        break;
                    case 10:
                        //загрузить файл
                        if (File.Exists("myTextFile.txt") == true) 
                        {
                            string[] m = File.ReadAllLines("myTextFile.txt");

                            foreach (string line in m) 
                            {
                                list.Add(line);
                            }
                        }
                        break;

                    default:
                        //вывод ошыбки
                        Console.WriteLine("Вы ввели не ту цыфру.");
                        break;
                    

                }
            }
        }
        public static void MyDictionary()
        {
            //создание словоря
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            while (true)
            {
                Console.WriteLine("\nВыберите действие: \n 1. Добавить элемент \n 2. Удалить элемент \n 4. Просмотреть элементы \n 5. Выход \n 6. Сохранить \n 7. Загрузить ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введите ключ элимента: ");
                        string key = Console.ReadLine();
                        Console.WriteLine("Введите значение для добавления: ");
                        string value = Console.ReadLine();
                        dictionary.Add(key, value);
                        break;
                    case 2:
                        Console.WriteLine("Введите ключ для удаления: ");
                        string deleteKey = Console.ReadLine();
                        //проверка есть ли такой ключ
                        if (dictionary.ContainsKey(deleteKey))
                            dictionary.Remove(deleteKey);
                        else
                            Console.WriteLine("Элемент с указанным ключом отсутствует.");
                        break;
                    case 3:
                        Console.WriteLine("Введите ключ для редактирования: ");
                        string eKey = Console.ReadLine();
                        if (dictionary.ContainsKey(eKey))
                        {
                            Console.WriteLine("Введите новое значение: ");
                            string newValue = Console.ReadLine();
                            dictionary[eKey] = newValue;
                        }
                        else
                            Console.WriteLine("Элемент с указанным ключом отсутствует.");
                        break;
                    case 4:
                        Console.WriteLine("Элементы в словаре:");
                        foreach (var pair in dictionary)
                        {
                            Console.WriteLine($"Ключ: {pair.Key}, Значение: {pair.Value}");
                        }
                        break;
                    case 5:
                        return;
                        break;
                    case 6:
                        // сохранение
                        File.WriteAllLines("myfileDictionary.txt", dictionary.Select(i =>   i.Key + "," + i.Value ));
                        break;
                    case 7:
                        //Загрузка с файла
                        if (File.Exists("myfileDictionary.txt") == true)
                        {
                            string[] m = File.ReadAllLines("myfileDictionary.txt");
                            foreach (var line in m)
                            {
                                string[] parts = line.Split(',');
                                dictionary.Add(parts[0], parts[1]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Нет сохранения.");
                        }
                        break;
                }
            }
        }
    }
}
 