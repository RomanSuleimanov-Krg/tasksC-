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

            //int firstNumber, secondNumber;

            //Console.Write("Введите первое число: ");
            //firstNumber = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Введите второе число: ");
            //secondNumber = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine($"\nИсходные значения:      [a={firstNumber++}]    [b={secondNumber--}]");
            //Console.WriteLine($"После модификаторов:    [a={firstNumber}]    [b={secondNumber}]\n");

            //Console.WriteLine($"+----------------+----------------+");
            //Console.WriteLine($"| Операция       | Результат      |");
            //Console.WriteLine($"+----------------+----------------+");
            //Console.WriteLine($"| Сумма          |             {firstNumber + secondNumber} |");
            //Console.WriteLine($"| Разность       |             {firstNumber-- - secondNumber++} |");
            //Console.WriteLine($"| Произведение   |             {firstNumber * secondNumber} |");
            //Console.WriteLine($"| Среднее        |            {(Convert.ToDouble(++firstNumber) + --secondNumber) / 2} |");
            //Console.WriteLine($"| Целое деление  |              {(firstNumber / secondNumber)} |");
            //Console.WriteLine($"| Остаток        |              {firstNumber % secondNumber} |");
            //Console.WriteLine($"+----------------+----------------+");


            //AI оценила данное решение на 2/10

            //* ЗАДАЧА 2
            //    Random random = new Random();

            //    int[] userNumberArray = new int[10];


            //    for (int i = 0; i < userNumberArray.Length; i++)
            //    {
            //        userNumberArray[i] = random.Next(0,101);
            //    }

            //    //* Заполняю масив пользователя рандомными числами[0;101)
            //    Console.Write($"Программа случайным образом заполнила следующий масив: {string.Join(" ", userNumberArray)}");
            //    Console.WriteLine($"\nВот сумма всех чисел это масива и его среднее арифметическое значение = {CalculateStats(userNumberArray)}");
            //}
            //static (int sum, double average) CalculateStats(int[] userNumberArray)
            //{
            //    int sum = 0;
            //    double average = 0;

            //    for (int i = 0;i < userNumberArray.Length; i++)
            //    {
            //        sum += userNumberArray[i];
            //    }

            //    for (int i = 0;i <userNumberArray.Length; i++)
            //    {
            //        average = sum / (userNumberArray.Length);
            //    }

            //    return (sum, Math.Round(average,2));
            //* Сделал метод который принимает в себя масив и выдает кортеж суммы чисел масива и его среднее арифметическое(округленное до двух знаков)

            //*ЗАДАЧА 3

            int numSubjects;
            int[] grades;
            int gradesSubject;

            //объявляю переменные для кол-ва предметов, оценки по предмету и массив в котором будут храниться оценки

            Console.Write($"Привет друг. Скажи какое количество предметов в школе ты изучаешь? :");
            numSubjects = Convert.ToInt32(Console.ReadLine());

            grades = new int[numSubjects];

            //определяюсь с размером массива

            Console.WriteLine("Замечательно. Теперь давай заполним какие оценки у тебя были по каждому предмету. Помни друг, что ты учишься по 100 бальной системе!");
            for (int i = 0; i < numSubjects; i++)
            {
                Console.Write($"Какая оценка у тебя была по предмету {i + 1}?: ");
                gradesSubject = Convert.ToInt32(Console.ReadLine());
                if (gradesSubject >= 0 && gradesSubject <= 100)
                {
                    grades[i] = gradesSubject;
                }
                else
                {
                    while (gradesSubject < 0 || gradesSubject > 100)
                    {
                        Console.WriteLine("Ошибочка, введи пожалуйста свою оценку от 0 до 100");
                        Console.Write($"Какая оценка у тебя была по предмету {i + 1}?: ");
                        gradesSubject = Convert.ToInt32(Console.ReadLine());
                    }
                    grades[i] = gradesSubject;
                }
            }

            //заполнение массива оценками[0; 100] и попытка валидировать запрос оценки от пользователя в рамках моих умений

            double averageGrades = CalculateAverage(grades);

            Console.WriteLine($"Друг,САЗ твоего бала это = {averageGrades}");
            Console.WriteLine($"Изучив САЗ твоих баллов, твоя оценка {DetermineGrade(averageGrades)}");
        }

        static double CalculateAverage(int[] numbersArray)
        {
            double result;
            int sum = 0;

            for(int i = 0; i < numbersArray.Length; i++)
            {
                sum += numbersArray[i];
            }
            
            result = Convert.ToDouble(sum) / numbersArray.Length;

            return result;
        }
        // Функция которая принимает массив оценок пользователя и на выходи дает их среднее арифметическое значение (САЗ)
        static char DetermineGrade(double averageGradesUser)
        {
            string gradeLetter;

            if (averageGradesUser >= 90 && averageGradesUser <= 100)
            {
                gradeLetter = "A";
            }
            else if (averageGradesUser >= 80 && averageGradesUser < 90)
            {
                gradeLetter = "B";
            }
            else if (averageGradesUser >= 70 && averageGradesUser < 80)
            {
                gradeLetter = "C";
            }
            else if (averageGradesUser >= 60 && averageGradesUser < 70)
            {
                gradeLetter = "D";
            }
            else
            {
                gradeLetter= "F";
            }
            return Convert.ToChar(gradeLetter);
        }
        // Функиця которая принимает в себя САЗ пользователя и сравниет его с диапозонами средних балов и говорит какая у него оценка буквой
    }
}
