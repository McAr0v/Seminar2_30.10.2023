using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar2_30._10._2023
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*
            
            Дан двумерный массив.

            732
            496
            185
            
            Отсортировать данные в нем по возрастанию.
            123
            456
            789
            
             */

            int[,] a = 
            { 
                { 7, 3, 2 }, 
                { 4, 9, 6 }, 
                { 1, 8, 5 } 
            };

            // Создаем одномерный массив с числами из двумерного

            int[] tempArray = CreateArray(a);

            // Сортируем одномерный массив

            DirectSort(tempArray);

            // На всякий случай выводим в консоль, чтобы понять
            // все ли правильно отсортировалось

            Console.WriteLine($"[{string.Join(", ", tempArray)}]");

            // Загружаем в наш двумерный массив новый, с отсортированными ячейками

            a = CreateDoubleArray(tempArray, a.GetLength(0), a.GetLength(1));

            // Просто пробел для разделения массивов
            Console.WriteLine();

            // Отображаем двумерный массив
            ShowDoubleArray(a);



        }

        // ---- ФУНКЦИЯ ОТОБРАЖЕНИЯ ДВУМЕРНОГО МАССИВА -----

        public static void ShowDoubleArray(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write($"{a[i, j]}");
                }

                Console.WriteLine();
            }
        }

        // ---- ФУНКЦИЯ СОЗДАНИЯ ДВУМЕРНОГО МАССИВА ИЗ ОДНОМЕРНОГО МАССИВА -----
        public static int[,] CreateDoubleArray(int[] a, int rows, int colums)
        {
            // Создаем двумерный массив с нужными размерами

            int[,] tempArray = new int[rows, colums];

            // Счетчик индексов, для одномерного массива

            int counter = 0;

            // Проходимся по строкам и столбцам двумерного массива
            // и заполняем данными из одномерного

            for (int i = 0; i < rows; i++)
            {

                for (int j = 0; j < colums; j++)
                {
                    tempArray[i, j] = a[counter];
                    counter++;

                }

            }

            return tempArray;

        }

        // --- ФУНКЦИЯ СОЗДАНИЯ ОДНОМЕРНОГО МАССИВА ИЗ ДВУМЕРНОГО ----

        public static int[] CreateArray(int[,] array)
        {
            // Создаем новый одномерный массив с нулями.
            // Размерность - чтобы влезли все числа двумерного массива

            int[] tempArray = new int[array.GetLength(0) * array.GetLength(1)];

            // Создаем счетчик, чтобы увеличивать индекс по одномерному массиву

            int counter = 0;

            // Проходимся по строкам и столбцам двумерного массива
            // и вставляем в одномерный массив значения

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    tempArray[counter] = array[i, j];
                    counter++;
                }
            }

            return tempArray;

        }

        // ---- ФУНКЦИЯ СОРТИРОВКИ ОДНОМЕРНОГО МАССИВА ------

        public static void DirectSort(int[] array)
        {
            // Проходим по всему нашему массиву и сравниваем
            for (int i = 0; i < array.Length - 1; i++)
            {
                // Указываем, что наш минимальный индекс будет i
                int minIndex = i;

                // Сравниваем следующие элементы массива с i
                for (int j = i + 1; j < array.Length; j++)
                {
                    // Если следующий элемент меньше чем i
                    if (array[j] < array[minIndex])
                    {
                        // То говорим, что минимальный теперь j
                        minIndex = j;
                    }
                }

                // Если i не равен минимальному индексу
                if (i != minIndex)
                {
                    // Меняем i-ый элемент (с которого изначально искали) на элемент с минимальным индексом (который самый маленький)
                    int temp = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = temp;
                }
            }
        }

    }
}
