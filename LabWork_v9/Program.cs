using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LabWork09
{
    public class Program
    {
        // 2) Функция Проверка ввода числа (Int)
        static uint InputUintNumber(string msg)
        {
            Console.Write(msg);
            bool isConvert;
            uint number;
            do
            {
                isConvert = uint.TryParse(Console.ReadLine(), out number);
                Console.ForegroundColor = ConsoleColor.Red;
                if (!isConvert) Console.WriteLine("Ошибка! Введите целое положительное число.");
                Console.ForegroundColor = ConsoleColor.White;
            } while (!isConvert);
            return number;
        }
        // 3) Интерфейс
        public static uint Menu()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Создать локацию (объект класса)");
            Console.WriteLine("2. Создать Список Локаций (массив из объектов класса)");
            Console.WriteLine("3. Узнать координаты локации (вывести информацию об объекте)");
            Console.WriteLine("4. Узнать координаты всех локаций в списке (вывести информацию обо всех объектах)");
            Console.WriteLine("5. Найти растояния между локациями");
            Console.WriteLine("6. Унарные операции с объектом");
            Console.WriteLine("7. Операции приведения типа");
            Console.WriteLine("8. Бинарные операции");
            Console.WriteLine("9. Количество созданных локаций (объектов класса)");
            Console.WriteLine("10. Найти ближайшую географическую точку к «Острову Ноль»");
            Console.WriteLine("11. Узнать кол-во списков координат»");
            Console.WriteLine("12. Демонстрация индексатора");
            Console.WriteLine("13. Выйти \n");
            uint numberMenu = InputUintNumber("Ваш выбор: \t");
            return numberMenu;
        }
        public static uint Menu1()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("   1. Создание объекта конструктором без параметра");
            Console.WriteLine("   2. Создание объекта с помощью ДСЧ (конструктором с параметром)");
            Console.WriteLine("   3. Создание объекта, ручной ввод данных (конструктором с параметром)");
            Console.WriteLine("   4. Копирование объекта (конструктор копирования)");
            Console.WriteLine("   5. Назад");
            uint numberMenu = InputUintNumber("Ваш выбор: \t");
            return numberMenu;
        }
        public static uint Menu2()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("    1. Создание массива объектов конструктором без параметра");
            Console.WriteLine("    2. Создание массива объектов с помощью ДСЧ (конструктором с параметром)");
            Console.WriteLine("    3. Создание массива объектов, ручной ввод данных (конструктором с параметром)");
            Console.WriteLine("    4. Создание копии коллекции (глубокое кланирование)");
            Console.WriteLine("    5. Узнать данные эллементов массива");
            Console.WriteLine("    6. Назад");
            uint numberMenu = InputUintNumber("Ваш выбор: \t");
            return numberMenu;
        }
        public static uint Menu5()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("    1. Реализовать методом класса");
            Console.WriteLine("    2. реализовать статичной функцией");
            Console.WriteLine("    3. Назад");
            uint numberMenu = InputUintNumber("Ваш выбор: \t");
            return numberMenu;
        }
        public static uint Menu6()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("    1. Увеличить широту и долготу объекта на 0,01");
            Console.WriteLine("    2. Инвертировать знаки широты и долготы");
            Console.WriteLine("    3. Назад");
            uint numberMenu = InputUintNumber("Ваш выбор: \t");
            return numberMenu;
        }
        public static uint Menu7()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Распологется ли точка на экваторе?");
            Console.WriteLine("2. Определение расположения точки(«Восточная долгота» / «Западная долгота» / «Нулевой меридиан»)");
            Console.WriteLine("3. Назад");
            uint numberMenu = InputUintNumber("Ваш выбор: \t");
            return numberMenu;
        }
        public static uint Menu8()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Определить: Находятся ли точки на одной параллели?");
            Console.WriteLine("2. Определить: Находятся ли точки на разных меридинах?");
            Console.WriteLine("3. Назад");
            uint numberMenu = InputUintNumber("Ваш выбор: \t");
            return numberMenu;
        }
        static void Main(string[] args)
        {
            GeoCoordinates locationMain = new GeoCoordinates(); // Создаём объект класса GeoCoordinates
            GeoCoordinatesArray locationArrMain = new GeoCoordinatesArray(); // Создаем массив из объектов класса
            Random rnd = new Random(); // Объект Random, созданный вне конструктора
            bool flag = false;
            bool flag1, flag2, flag5, flag6, flag7, flag8;

            while (flag != true)
            {
                switch (Menu())
                {
                    case 1:
                        flag1 = false;
                        while (flag1 != true)
                        {
                            switch (Menu1())
                            {
                                case 1:
                                    locationMain = new GeoCoordinates();
                                    Console.WriteLine("Созданный объект:");
                                    locationMain.Print();
                                    break;
                                case 2:
                                    locationMain = new GeoCoordinates(rnd);
                                    Console.WriteLine("Созданный объект:");
                                    locationMain.Print();
                                    break;
                                case 3:
                                    try
                                    {
                                        locationMain = new GeoCoordinates();
                                        locationMain.CreateFromUserInput();
                                        Console.WriteLine("Созданный объект:");
                                        locationMain.Print();
                                    }
                                    catch (Exception error)
                                    {
                                        Console.WriteLine(error.Message);
                                    }
                                    break;
                                case 4:
                                    locationMain = new GeoCoordinates(rnd);
                                    Console.WriteLine("Созданный объект:");
                                    Console.WriteLine(locationMain);
                                    Console.WriteLine("Копия объекта:");
                                    GeoCoordinates locCopy = new GeoCoordinates(locationMain);
                                    locCopy.Print();
                                    break;
                                case 5:
                                    flag1 = true;
                                    break;
                                default:
                                    Console.WriteLine("Ошибка! Вы ввели несуществующий номер.");
                                    break;
                            }
                        }
                        break;
                    case 2:
                        flag2 = false;
                        while (flag2 != true)
                        {
                            try
                            {
                                switch (Menu2())
                                {
                                    case 1:
                                        locationArrMain = new GeoCoordinatesArray();
                                        locationArrMain.PrintLocations();
                                        break;
                                    case 2:
                                        uint countRnd = InputUintNumber("Кол-во объектов: \t");
                                        locationArrMain = new GeoCoordinatesArray((int)countRnd, rnd);
                                        locationArrMain.PrintLocations();
                                        break;
                                    case 3:
                                        uint countKey1 = InputUintNumber("Кол-во объектов: \t");
                                        locationArrMain = new GeoCoordinatesArray(countKey1);
                                        Console.WriteLine("Выши объекты: ");
                                        locationArrMain.PrintLocations();
                                        break;
                                    case 4:
                                        Console.WriteLine("Массив для копирования: ");
                                        locationArrMain.PrintLocations();
                                        GeoCoordinatesArray cloneArray = new GeoCoordinatesArray(locationArrMain);
                                        Console.WriteLine("Копия массива: ");
                                        cloneArray.PrintLocations();
                                        break;
                                    case 5:
                                        locationArrMain.PrintLocations();
                                        break;
                                    case 6:
                                        flag2 = true;
                                        break;
                                    default:
                                        Console.WriteLine("Ошибка! Вы ввели несуществующий номер.");
                                        break;
                                }
                            }
                            catch (Exception error)
                            {
                                Console.WriteLine(error.Message);
                            }

                        }
                        break;
                    case 3:
                        locationMain.Print();
                        break;
                    case 4:
                        try
                        {
                            locationArrMain.PrintLocations();
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message);
                        }
                        break;
                    case 5:
                        try
                        {
                            flag5 = false;
                            while (flag5 != true)
                            {
                                switch (Menu5())
                                {
                                    case 1:
                                        Console.WriteLine("Задайте объекты для сравнения: ");
                                        GeoCoordinatesArray locations1 = new GeoCoordinatesArray(2);
                                        double dist1 = locations1[0].Distance(locations1[1]);
                                        Console.WriteLine($"Растояние между точками равно {dist1}");
                                        break;
                                    case 2:
                                        Console.WriteLine("Задайте объекты для сравнения: ");
                                        GeoCoordinatesArray locations2 = new GeoCoordinatesArray(2);
                                        double dist2 = GeoCoordinates.DistanceSt(locations2[0], locations2[1]);
                                        Console.WriteLine($"Растояние между точками равно {dist2}");
                                        break;
                                    case 3:
                                        flag5 = true;
                                        break;
                                    default:
                                        Console.WriteLine("Ошибка! Вы ввели несуществующий номер.");
                                        break;
                                }
                            }
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message);
                        }
                        break;
                    case 6:
                        flag6 = false;
                        while (flag6 != true)
                        {
                            switch (Menu6())
                            {
                                case 1:
                                    try
                                    {
                                        Console.WriteLine("Задайте объект для изменения: ");
                                        locationMain = new GeoCoordinates();
                                        locationMain.CreateFromUserInput();
                                        Console.WriteLine("Созданный объект:");
                                        locationMain.Print();
                                        Console.WriteLine("Результат: ");
                                        locationMain++.Print();
                                    }
                                    catch (Exception error)
                                    {
                                        Console.WriteLine(error.Message);
                                    }
                                    break;
                                case 2:
                                    try
                                    {
                                        Console.WriteLine("Задайте объект для изменения: ");
                                        locationMain = new GeoCoordinates();
                                        locationMain.CreateFromUserInput();
                                        Console.WriteLine("Созданный объект:");
                                        locationMain.Print();
                                        Console.WriteLine("Результат: ");
                                        (-locationMain).Print();
                                    }
                                    catch (Exception error)
                                    {
                                        Console.WriteLine(error.Message);
                                    }
                                    break;
                                case 3:
                                    flag6 = true;
                                    break;
                                default:
                                    Console.WriteLine("Ошибка! Вы ввели несуществующий номер.");
                                    break;
                            }
                        }
                        break;
                    case 7:
                        flag7 = false;
                        while (flag7 != true)
                        {
                            switch (Menu7())
                            {
                                case 1:
                                    try
                                    {
                                        Console.WriteLine("Задайте объект для изменения: ");
                                        locationMain = new GeoCoordinates();
                                        locationMain.CreateFromUserInput();
                                        Console.WriteLine((bool)locationMain);
                                    }
                                    catch (Exception error)
                                    {
                                        Console.WriteLine(error.Message);
                                    }
                                    break;
                                case 2:
                                    try
                                    {
                                        Console.WriteLine("Задайте объект для изменения: ");
                                        locationMain = new GeoCoordinates();
                                        locationMain.CreateFromUserInput();
                                        Console.WriteLine(locationMain);
                                    }
                                    catch (Exception error)
                                    {
                                        Console.WriteLine(error.Message);
                                    }
                                    break;
                                case 3:
                                    flag7 = true;
                                    break;
                                default:
                                    Console.WriteLine("Ошибка! Вы ввели несуществующий номер.");
                                    break;
                            }
                        }
                        break;
                    case 8:
                        flag8 = false;
                        while (flag8 != true)
                        {
                            try
                            {
                                switch (Menu8())
                                {
                                    case 1:
                                        Console.WriteLine("Задайте объекты для сравнения: ");
                                        GeoCoordinatesArray locations1 = new GeoCoordinatesArray(2);
                                        Console.WriteLine(locations1[0] == locations1[1]);
                                        break;
                                    case 2:
                                        Console.WriteLine("Задайте объекты для сравнения: ");
                                        GeoCoordinatesArray locations2 = new GeoCoordinatesArray(2);
                                        Console.WriteLine(locations2[0] != locations2[1]);
                                        break;
                                    case 3:
                                        flag8 = true;
                                        break;
                                    default:
                                        Console.WriteLine("Ошибка! Вы ввели несуществующий номер.");
                                        break;
                                }
                            }
                            catch (Exception error)
                            {
                                Console.WriteLine(error.Message);
                            }
                        }
                        break;
                    case 9:
                        Console.WriteLine($"Кол-во объектов класса GeoCoordinates: \t {GeoCoordinates.objectCount}");
                        break;
                    case 10:
                        try
                        {
                            uint countKey = InputUintNumber("Кол-во объектов: \t");
                            locationArrMain = new GeoCoordinatesArray(countKey);
                            Console.WriteLine("Выши объекты: ");
                            locationArrMain.PrintLocations();
                            locationArrMain.FindNearestToZeroIslandIndex();
                        }
                        catch (Exception EmptyArray)
                        {
                            Console.WriteLine(EmptyArray.Message);
                        }
                        break;
                    case 11:
                        {
                            Console.WriteLine($"Кол-во списков координат: {GeoCoordinatesArray.GetObjectCount()}");
                            break;
                        }
                    case 12:
                        {
                            // предусмотренно тестирование всех 4 вариантов
                            try
                            {
                                int count = (int)InputUintNumber("Введите длину массива: ");
                                GeoCoordinatesArray testArr = new GeoCoordinatesArray(count, rnd);
                                int countEl = (int)InputUintNumber("Введите номер эллемента, которых хотите просмотреть: ");
                                testArr[countEl - 1].Print();
                                int countElPlus = (int)InputUintNumber("Введите номер эллемента, которых хотите добавить: (элемент создается ДСЧ) \t");
                                GeoCoordinates element = new GeoCoordinates(rnd);
                                testArr[countElPlus - 1] = element;
                                testArr.PrintLocations();
                            }
                            catch (Exception error)
                            {
                                Console.WriteLine(error.Message);
                            }
                            break;
                        }
                    case 13:
                        flag = true;
                        break;
                    default:
                        Console.WriteLine("Ошибка! Вы ввели несуществующий номер.");
                        break;
                }
            }
        }
    }
}