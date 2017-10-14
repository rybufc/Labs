using System;

namespace Lab1
{
    /// <summary>
    /// Класс, включающий в себя методы сортировки массива
    /// </summary>
    public static class SortingMethods
    {
        /// <summary>
        /// Сортирует массив стандартным методом
        /// </summary>
        /// <param name="sequence"> Сортируемый массив</param>
        /// <returns> Отсортированный массив</returns>
        public static int[] StandardSort(int[] sequence)
        {
            int[] toSort = new int[sequence.Length];
            sequence.CopyTo(toSort, 0);
            Array.Sort(toSort);

            return toSort;
        }

        /// <summary>
        /// Сортирует массив с помощью алгоритма сортировки пузырьком
        /// </summary>
        /// <param name="sequence"> Сортируемый массив</param>
        /// <returns> Отсортированный массив</returns>
        public static int[] BubbleSort(int[] sequence)
        {
            int[] toSort = new int[sequence.Length];
            sequence.CopyTo(toSort, 0);
            bool isSorted = false;

            while (!isSorted)   // Проверка отсортированности массива
            {
                isSorted = true;
                for (int i = 0; i < toSort.Length - 1; i++)  // Проход по массиву с начала
                {
                    if (toSort[i] > toSort[i + 1])  // Сравнение рядом стоящих элементов массива
                    {
                        Swap(ref toSort[i], ref toSort[i + 1]); // Смена местами рядом стоящих элементов массива

                        isSorted = false;
                    }
                }
            }

            return toSort;
        }

        /// <summary>
        /// Сортировка массива с помощью алгоритма Шелла
        /// </summary>
        /// <param name="sequence"> Сортируемый массив</param>
        /// <returns> Отсортированый массив</returns>
        public static int[] ShellSort(int[] sequence)
        {
            int[] toSort = new int[sequence.Length];
            sequence.CopyTo(toSort, 0);

            // Изменение шага с которым
            // будет осуществляться проход по массиву
            for (int step = toSort.Length; step > 0; step /= 2)
            {
                for (int i = 0; i < step; i++)  // Проход по массиву через заданный шаг
                {
                    // Сортировка вставкой элементов массива,
                    // расположенных через заданный шаг 
                    toSort = InsertSort(toSort, step, i);
                }
            }

            return toSort;
        }

        /// <summary>
        /// Сортировка массива с помощью алгоритма
        /// пирамидальной сортировки
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static int[] HeapSort(int[] sequence)
        {
            int[] toSort = new int[sequence.Length];
            sequence.CopyTo(toSort, 0);

            // Выстраивание элементов массива
            // в сортировочное дерево
            toSort = BuildHeap(toSort);
            int Length = toSort.Length;
            while (Length > 0)   // Уменьшение рассматриваемой длины массива после каждой итерации
            {
                // Смена местами первого и последнего
                // рассматриваемого элемента
                Swap(ref toSort[0], ref toSort[Length - 1]);
                Length--;
                toSort = Heapify(toSort, 0);    // Восстановление сортировочного дерева
            }

            return toSort;
        }

        /// <summary>
        /// Смена местами значений двух переменных
        /// </summary>
        /// <param name="first"> Первая переменная</param>
        /// <param name="second"> Вторая переменная</param>
        private static void Swap(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }

        /// <summary>
        /// Сортировка вставкой элементов массива,
        /// расположенных через определённый шаг
        /// </summary>
        /// <param name="toSort"> Сортируемый массив</param>
        /// <param name="step"> Шаг, через который сортируются элементы</param>
        /// <param name="i"> Номер элемента, с которого начинается сортировка</param>
        /// <returns> Изменённый массив</returns>
        private static int[] InsertSort(int[] toSort, int step, int i)
        {
            for (; i + step < toSort.Length; i += step) // Проход по массиву с заданным шагом
            {
                // Сравнение двух элементов массива,
                // расположенных через заданный шаг
                if (toSort[i + step] < toSort[i])
                {
                    Swap(ref toSort[i], ref toSort[i + 1]);   // Смена местами этих элементов

                    // Вынос рассматриваемого элемента
                    // на его место
                    for (int j = i; j - step >= 0 && toSort[j] < toSort[j - step]; j -= step)
                    {
                        // Смена местами рассматриваемого
                        // элемента с предыдущим
                        Swap(ref toSort[i], ref toSort[i + 1]);
                    }
                }
            }

            return toSort;
        }

        /// <summary>
        /// Построение сортировочного дерева из
        /// элементов заданного массива
        /// </summary>
        /// <param name="toSort"> Сортируемый массив</param>
        /// <returns> 
        /// Массив, элементы которого
        /// выстроены в сортировочное дерево
        /// </returns>
        private static int[] BuildHeap(int[] toSort)
        {
            // Перебор корневых элементов
            // всех поддеревьев сортировочного дерева
            for (int i = toSort.Length / 2 - 1; i >= 0; i--)
            {
                toSort = Heapify(toSort, i); // Построение выбранного поддерева
            }
            return toSort;
        }

        /// <summary>
        /// Построение и восстановление заданного
        /// поддерева сортировочного дерева
        /// </summary>
        /// <param name="toSort"> Сортируемый массив</param>
        /// <param name="pos"> Корневой элемент сортируемого поддерева</param>
        /// <returns> Отсортированный массив</returns>
        private static int[] Heapify(int[] toSort, int pos)
        {
            bool done = false;  // Флажок отсортированности ветви
            while (pos * 2 + 1 < toSort.Length && !done)
            {
                int maxSon = pos * 2 + 1;

                // Сравнение предполагаемых дочерних элементов
                if (maxSon + 1 < toSort.Length && toSort[maxSon] < toSort[maxSon + 1])
                {
                    maxSon++;
                }
                // Сравнение предполагаемых корневого и макс. дочернего элемента
                if (toSort[pos] < toSort[maxSon])
                {
                    // Смена местами корневого и дочернего элементов
                    Swap(ref toSort[pos], ref toSort[maxSon]);
                    pos = maxSon;
                }
                // Смена значения флажка на 1 если ветвь отсортированна
                else
                {
                    done = true;
                }
            }

            return toSort;
        }

    }
}
