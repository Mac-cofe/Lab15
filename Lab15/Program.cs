using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15
{
    class Program
    {
        static void Main()
        {

            Console.WriteLine("Какую прогрессию сгенерировать?\n     1. Арифметическая прогрессия \n     2. Геометрическая прогрессия ");
            Console.WriteLine("     3. Автоматически сгенерированная арифметическая прогрессия\n     4. Автоматически сгенерированная геометрическая прогрессия");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        ArithProgression progression = new ArithProgression();
                        try
                        {
                            Console.WriteLine("Введите значение первого члена арифметической прогрессии");
                            int a1 = Convert.ToInt32(Console.ReadLine());
                            progression.SetStart(a1);
                            Console.WriteLine("Введите значение разности арифметической прогрессии");
                            int d = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Сколько элементов в данной арифметической прогрессии?");
                            int n = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                            progression.Sum(a1, d, n);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    }
                case 2:
                    {
                        GeomProgression progressionG = new GeomProgression();
                        try
                        {
                            Console.WriteLine("Введите значение первого члена геометрической прогрессии");
                            int a1 = Convert.ToInt32(Console.ReadLine());
                            progressionG.SetStart(a1);
                            Console.WriteLine("Введите значение знаменателя геометрической прогрессии");
                            int d = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Сколько элементов в данной геометрической прогрессии?");
                            int n = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                            progressionG.Sum(a1, d, n);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    }
                case 3:
                    {
                        ArithProgression progressionAuto = new ArithProgression();
                        progressionAuto.Sum(1, -3, 5);
                        break;
                    }
                case 4:
                    {
                        GeomProgression progressionAutoG = new GeomProgression();
                        progressionAutoG.Sum(10, 2, 6);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Некорректный выбор");
                        break;
                    }

            }
            Console.ReadKey();
        }

        interface ISeries
        {

            void SetStart(int x);    // устанавливает начальное значение

            int GetNext();       // возвращает следующее число ряда

            void Reset();            //выполняет сброс к начальному значению  ?????? 

            void Sum();             // сумма элементов прогресии
        }

        class ArithProgression : ISeries         // класс Генерирования арифметической прогрессии
        {
            public int X { get; set; }
            public int X_Next { get; set; }
            public int X_Current { get; set; }
            public int d; 
            public int N { get; set; }

            public int D                // Свойство d
            {
                set
                {
                    if (d != 0)
                    { d = value; }
                    else
                    { Console.WriteLine("Разность арифметической прогресии не может быть = 0"); } // не понимаю, когда и на что должно повлиять это
                }
                get
                { return d; }
            }
            public ArithProgression() { } // конструктор

            public int GetNext(int D)               // возвращает следующее число ряда
            {
                X_Next = X_Current + D;
                X_Current += D;
                return X_Next;
            }
            public void SetStart(int x)          // устанавливает начальное значение
            {
                X = x;
                X_Current = X;
            }
            public void Sum(int X, int D, int N)             // сумма элементов прогресии
            {
                Console.WriteLine("Элементы арифметической прогрессии:");
                Console.Write($"   {X} ");
                for (int i = 0; i < N - 1; i++)
                {
                    int X_Next = GetNext(D);
                    Console.Write($"{X_Next} ");
                }
                Console.WriteLine();
                int aN = X + D * (N - 1);
                double Summ = (X + aN) * N / 2;
                if (Summ!=0)
                Console.WriteLine($"Сумма всех элементов арифметической прогрессии = {Summ}");
                else
                    Console.WriteLine("Введены ошибочные данные. Прогрессия сгенерирована некорректно");
            }

            public int GetNext()
            {
                throw new NotImplementedException();
            }

            public void Sum()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

        }

        class GeomProgression : ISeries         // класс Генерирования геометрической прогрессии
        {
            public int X { get; set; }
            public int X_Next { get; set; }
            public int X_Current { get; set; }
            public int d;
            public int N { get; set; }

            public int D
            {
                set
                {
                    if (d != 0)
                    { d = value; }
                    else
                    { Console.WriteLine("Знаменатель геометрической прогресии не может быть = 0"); }  // не понимаю, когда и на что должно повлиять это
                }
                get
                { return d; }
            }


            public GeomProgression() { }  // конструктор

            public int GetNext(int D)               // возвращает следующее число ряда
            {
                X_Next = X_Current * D;
                X_Current *= D;
                return X_Next;
            }
            public void SetStart(int x)              // устанавливает начальное значение
            {
                X = x;
                X_Current = X;
            }
            public void Sum(int X, int D, int N)             // сумма элементов прогресии
            {
                Console.WriteLine("Элементы геометрической прогрессии:");
                SetStart(X);
                Console.Write($"   {X} ");
                for (int i = 0; i < N - 1; i++)
                {
                    int X_Next = GetNext(D);
                    Console.Write($"{X_Next} ");
                }
                Console.WriteLine();
                double aN = X * Math.Pow((double)D, N - 1);
                double Summ = (aN * D - X) / (D - 1);
                if (Summ!=X)
                Console.WriteLine($"Сумма всех элементов геометрической прогрессии = {Summ}");
                else
                    Console.WriteLine("Введены ошибочные данные. Прогрессия сгенерирована некорректно");
            }

            public int GetNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            public void Sum()
            {
                throw new NotImplementedException();
            }
        }

    }
}






