using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tasksC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ЗАДАЧА 1
            //Введите первое число: 5
            //Введите второе число: 10

            //Исходные значения:    [a=5]   [b=10]
            //После модификаторов:  [a=6]   [b=9]

            //+----------------+----------------+
            //| Операция       | Результат      |
            //+----------------+----------------+
            //| Сумма          |             15 | 
            //| Разность       |             -3 | 
            //| Произведение   |             50 | до модификаторов
            //| Среднее        |           7.50 |
            //| Целое деление  |              0 |
            //| Остаток        |              6 |
            //+----------------+----------------+

            int firstNumber, secondNumber;

            Console.Write("Введите первое число: ");
            firstNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите второе число: ");
            secondNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\nИсходные значения:      [a={firstNumber++}]    [b={secondNumber--}]");
            Console.WriteLine($"После модификаторов:    [a={firstNumber}]    [b={secondNumber}]\n");

            Console.WriteLine($"+----------------+----------------+");
            Console.WriteLine($"| Операция       | Результат      |");
            Console.WriteLine($"+----------------+----------------+");
            Console.WriteLine($"| Сумма          |             {firstNumber + secondNumber} |");
            Console.WriteLine($"| Разность       |             {firstNumber-- - secondNumber++} |");
            Console.WriteLine($"| Произведение   |             {firstNumber * secondNumber} |");
            Console.WriteLine($"| Среднее        |            {(Convert.ToDouble(++firstNumber) + --secondNumber) / 2} |");
            Console.WriteLine($"| Целое деление  |              {(firstNumber / secondNumber)} |");
            Console.WriteLine($"| Остаток        |              {firstNumber % secondNumber} |");
            Console.WriteLine($"+----------------+----------------+");


            //AI оценила данное решение на 2/10
        }
    }
}
