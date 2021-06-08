using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp37
{
    class Program
    {
        static void Main(string[] args)
        {
            Product prod = new Product();
            prod.Information();
        }
    }
    class Product
    {
        public string[] name = new string[] {"Молоко","Булка с маком","Lucky колбаса" };
        public string[] date = new string[] {"01.06.2021","08.05.2021","23.04.2021"};
        public string[] proizvod = new string[] {"Корова","Неизвестно","Наполеон" };
        public string[] sostav = new string[] {"Молоко коровы,E102,E303" , "Тесто,мак,E9999,сахар" , "рандомное мясо,E1,E2,E3,E4,E1234" };
        public string[] product = new string[] {"Молочные","Хлебобулочные","Мясные" };
        public float[] cost = new float[] { 30.99f , 23.49f, 999.99f};
        public string search;
        float costsale = 0;

        public void Information()
        {
            bool inf = true;
            while (inf)
            {
                for (int i = 0; i < name.Length; i++)
                {
                    Console.Write(name[i] + " |");
                }
                Console.WriteLine("");
                Console.WriteLine("Если вы хотите выйти напишите слово <Выход>");
                Console.WriteLine("Введите назвние продукта");
                search = Console.ReadLine();
                for (int i = 0; i < name.Length; i++)
                {
                    if (name[i] == search)
                    {
                        Console.Clear();
                        Console.WriteLine($"Назавние: {name[i]}");
                        Console.WriteLine($"Дата: {date[i]}");
                        Console.WriteLine($"Производитель: {proizvod[i]}");
                        Console.WriteLine($"Вид продукта: {product[i]}");
                        Console.WriteLine($"Цена: {cost[i]} руб");
                        SrokGod();
                        Sostav(i);
                        if (costsale > 0){Console.WriteLine($"Цена со скидкой: {Math.Round(costsale, 2)} руб");}
                        else{Console.WriteLine($"Скидки нет");}
                        Console.WriteLine("------------------------------------------");
                    }
                    else if(search == "Выход")
                    {
                        inf = false;
                    }
                }
            }
        }
        public void SrokGod()
        {
            int d1 = 03;
            int d2 = 06;
            int dateg;
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == search)
                {
                    string[] date2 = date[i].Split('.');
                    switch (product[i])
                    {
                        case "Молочные":
                            if (Convert.ToInt32(date2[1]) + 1 == d2)
                            {
                                dateg = 14 - Math.Abs(d1 - Convert.ToInt32(date2[0]) + 30);
                                if (dateg > 0)
                                {
                                    Console.WriteLine($"Дней до просрочки: {dateg}");
                                    Sale(dateg, i);
                                }
                                else
                                {
                                    Console.WriteLine($"Продукт просрочен");
                                }
                            }
                            else if (Convert.ToInt32(date2[1]) == d2)
                            {
                                dateg = 14 - Math.Abs(d1 - Convert.ToInt32(date2[0]));
                                Console.WriteLine($"Дней до просрочки: {dateg}");
                                Sale(dateg, i);
                            }
                            else
                            {
                                Console.WriteLine($"Продукт просрочен");
                            }
                            break;
                        case "Хлебобулочные":
                            if (Convert.ToInt32(date2[1]) + 1 == d2)
                            {
                                dateg = 30 - Math.Abs(d1 - Convert.ToInt32(date2[0]) + 30);
                                if (dateg > 0)
                                {
                                    Console.WriteLine($"Дней до просрочки: {dateg}");
                                    Sale(dateg, i);
                                }
                                else
                                {
                                    Console.WriteLine($"Продукт просрочен");
                                }
                            }
                            else if (Convert.ToInt32(date2[1]) == d2)
                            {
                                dateg = 30 - Math.Abs(d1 - Convert.ToInt32(date2[0]));
                                Console.WriteLine($"Дней до просрочки: {dateg}");
                                Sale(dateg, i);
                            }
                            else
                            {
                                Console.WriteLine($"Продукт просрочен");
                            }
                            break;
                        case "Мясные":
                            if (Convert.ToInt32(date2[1]) + 2 == d2)
                            {
                                dateg = 60 - Math.Abs(d1 - Convert.ToInt32(date2[0]) + 60);
                                if (dateg > 0)
                                {
                                    Console.WriteLine($"Дней до просрочки: {dateg}");
                                    Sale(dateg, i);
                                }
                                else
                                {
                                    Console.WriteLine($"Продукт просрочен");
                                }
                            }
                            else if (Convert.ToInt32(date2[1]) + 1 == d2)
                            {
                                dateg = 60 - Math.Abs(d1 - Convert.ToInt32(date2[0]) + 30);
                                if (dateg > 0)
                                {
                                    Console.WriteLine($"Дней до просрочки: {dateg}");
                                    Sale(dateg, i);
                                }
                                else
                                {
                                    Console.WriteLine($"Продукт просрочен");
                                }
                            }
                            else if (Convert.ToInt32(date2[1]) == d2)
                            {
                                dateg = 60 - Math.Abs(d1 - Convert.ToInt32(date2[0]));
                                Console.WriteLine($"Дней до просрочки: {dateg}");
                                Sale(dateg, i);
                            }
                            else
                            {
                                Console.WriteLine($"Продукт просрочен");
                            }
                            break;

                    }
                }
            }
        }

        public int Sostav(int i)
        {

            string[] sostav1 = sostav[i].Split(',');
            switch (search)
            {
                case "Молоко":
                    Console.Write($"Состав:");
                    for (int j = 0; j < sostav1.Length; j++)
                    {
                        if (sostav1[j].StartsWith("E") != true)
                        {
                            Console.Write(sostav1[j] + " ");

                        }
                    }
                    Console.WriteLine("");
                    Console.Write($"Добавки:") ;
                    for (int j = 0; j < sostav1.Length; j++)
                    {
                        if (sostav1[j].StartsWith("E"))
                        {
                            Console.Write(sostav1[j] + " ");

                        }
                    }
                    break;
                case "Булка":
                    Console.Write($"Состав:");
                    for (int j = 0; j < sostav1.Length; j++)
                    {
                        if (sostav1[j].StartsWith("E") != true)
                        {
                            Console.Write(sostav1[j] + " ");

                        }
                    }
                    Console.WriteLine("");
                    Console.Write($"Добавки:");
                    for (int j = 0; j < sostav1.Length; j++)
                    {
                        if (sostav1[j].StartsWith("E"))
                        {
                            Console.Write(sostav1[j] + " ");

                        }
                    }
                    break;
                case "Lucky колбаса":
                    Console.Write($"Состав:");
                    for (int j = 0; j < sostav1.Length; j++)
                    {
                        if (sostav1[j].StartsWith("E") != true)
                        {
                            Console.Write(sostav1[j] + " ");

                        }
                    }
                    Console.WriteLine("");
                    Console.Write($"Добавки:");
                    for (int j = 0; j < sostav1.Length; j++)
                    {
                        if (sostav1[j].StartsWith("E"))
                        {
                            Console.Write(sostav1[j] + " ");

                        }
                    }
                    break;
            }
            Console.WriteLine("");
            return 0;
        }
        public int Sale(int dateg,int i)
        {
            
            if (dateg <= 10 && dateg > 5)
            {
                costsale = cost[i] - cost[i] * 0.05f;
            }
            else if (dateg <= 5 && dateg > 3)
            {
                costsale = cost[i] - cost[i] * 0.10f;
            }
            else if (dateg <= 3)
            {
                costsale = cost[i] - cost[i] * 0.15f;
            }
            else
            {
                costsale = 0;
            }
            return 0;

        }
    }
}
