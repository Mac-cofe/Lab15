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
                            Console.WriteLine("Сколько элементов в данной арифметической прогрессии?");
                            int n = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                            for (int i = 0; i < n; i++)
                            {
                                Console.WriteLine(progression.GetNext());
                            }
                            progression.Reset();
                            Console.WriteLine("Повторим прогрессию после сброса до начального значения");
                            for (int i = 0; i < n; i++)
                            {
                                Console.Write(progression.GetNext() + " ");
                            }
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
                            int a2 = Convert.ToInt32(Console.ReadLine());
                            progressionG.SetStart(a2);
                            Console.WriteLine("Сколько элементов в данной геометрической прогрессии?");
                            int n = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                            for (int i = 0; i < n ; i++)
                            {
                                progressionG.GetNext();
                            }
                            progressionG.Reset();
                            Console.WriteLine("Повторим прогрессию после сброса до начального значения");
                            for (int i = 0; i < n; i++)
                            {
                                progressionG.GetNext();
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
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

            void Reset();            //выполняет сброс к начальному значению  

        }

        class ArithProgression : ISeries         // класс Генерирования арифметической прогрессии
        {
            public int X { get; set; }

            public int X_begin { get; set; }

            public ArithProgression() { } // конструктор

            public int GetNext()               // возвращает следующее число ряда
            {
                return X++;

            }
            public void SetStart(int x)          // устанавливает начальное значение
            {
                X = x;
                X_begin = x;
                
            }

            public void Reset()             //выполняет сброс к начальному значению  
            {
                SetStart(X_begin);
            }

        }

        class GeomProgression : ISeries         // класс Генерирования геометрической прогрессии
        {
            public int X { get; set; }
            public int X_begin { get; set; }

            public GeomProgression() { }  // конструктор

            public int GetNext()               // возвращает следующее число ряда
            {
                Console.WriteLine(X);
                return X*=2;
                
            }
            public void SetStart(int x)              // устанавливает начальное значение
            {
                X = x;
                X_begin = x;
            }

            public void Reset()                 //выполняет сброс к начальному значению  
            {
                //Console.WriteLine(X_begin);
                SetStart(X_begin);
            }

        }

    }
}






