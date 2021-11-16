using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZD3
{
    class Program
    {
        static void Main(string[] args)
        {
            string FileName = "t.txt";
            if (File.Exists(FileName))
            {
                List<string[]> s = File.ReadAllLines(FileName).Select(x => x.Split(' ')).ToList();
                s.ForEach(x => Console.WriteLine(string.Join(" ", x)));
                try
                {
                    Console.WriteLine("Максимальный средний балл " + s.Max(x => float.Parse(x[4])));
                    Console.WriteLine("Минимальный средний балл " + s.Min(x => float.Parse(x[4])));
                    Console.WriteLine("Средний средний балл " + s.Average(x => double.Parse(x[4])));
                }
                catch { Console.WriteLine("В файле обнаружены некорректные данные, работа с баллами невозможна"); }

                Console.WriteLine("Выберете поле для сортировки:\n1 Имя\n2 Отчество\n3 Группа\n4 Средний балл\nПо умолчанию - Фамилия");
                string WayOfSort = Console.ReadLine();
                Console.WriteLine("Выберете направление сортировки\n1 По убыванию\nПо умолчанию - по возрастанию");
                string VectorOfSort = Console.ReadLine();

                try
                {
                    if (VectorOfSort != "1")
                        File.WriteAllLines(FileName, s.OrderBy(x => x[int.Parse(WayOfSort)]).ToArray().Select(x => string.Join(" ", x)).ToArray());
                    else
                        File.WriteAllLines(FileName, s.OrderByDescending(x => x[int.Parse(WayOfSort)]).ToArray().Select(x => string.Join(" ", x)).ToArray());
                }
                catch
                {
                    if (VectorOfSort != "1")
                        File.WriteAllLines(FileName, s.OrderBy(x => x[0]).ToArray().Select(x => string.Join(" ", x)).ToArray());
                    else
                        File.WriteAllLines(FileName, s.OrderByDescending(x => x[0]).ToArray().Select(x => string.Join(" ", x)).ToArray());
                }
            }
            else Console.WriteLine("Такого файла нет!");
            Console.ReadKey();
        }
    }
}
