using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public static class Sorting_Methods
    {
        //Стандартная сортировка шарпа
        public static int[] StandardSort(int[] sequence)
        {
            int[] toSort = new int[sequence.Length];
            sequence.CopyTo(toSort, 0);
            Array.Sort(toSort);

            return toSort;
        }

        //Пузырёк
        public static int[] BubbleSort(int[] sequence)
        {
            int[] toSort = new int[sequence.Length];
            sequence.CopyTo(toSort, 0);
            bool isSorted = false;
            while (!isSorted)
            {
                isSorted = true;
                for (int i = 0; i < toSort.Length - 1; i++)
                {
                    if (toSort[i] > toSort[i + 1])
                    {
                        Swap(ref toSort[i], ref toSort[i + 1]);

                        isSorted = false;
                    }
                }
            }

            return toSort;
        }

        //Сортировка Шелла
        public static int[] ShellSort(int[] sequence)
        {
            int[] toSort = new int[sequence.Length];
            sequence.CopyTo(toSort, 0);

            for (int step = toSort.Length; step > 0; step /= 2)
            {
                for (int i = 0; i < step; i++)
                {
                    toSort = InsertSort(toSort, step, i);
                }
            }

            return toSort;
        }

        //Пирамидальная сортировка
        public static int[] HeapSort(int[] sequence)
        {
            int[] toSort = new int[sequence.Length];
            sequence.CopyTo(toSort, 0);

            toSort = BuildHeap(toSort);
            int Length = toSort.Length;
            while(Length > 0)
            {
                Swap(ref toSort[0], ref toSort[Length - 1]);
                Length--;
                toSort = Heapify(toSort, 0);
            }

            return toSort;
        }

        private static void Swap(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }

        //сортировка вставкой
        private static int[] InsertSort(int[] toSort, int step, int i)
        {
            for (; i + step < toSort.Length; i += step)
            {
                if (toSort[i + step] < toSort[i])
                {
                    Swap(ref toSort[i], ref toSort[i+1]);

                    for (int j = i; j - step >= 0 && toSort[j] < toSort[j - step]; j -= step)
                    {
                        Swap(ref toSort[i], ref toSort[i+1]);
                    }
                }
            }

            return toSort;
        }

        private static int[] BuildHeap(int[] toSort)
        {
            for (int i = toSort.Length / 2 - 1; i>=0; i--)
            {
                toSort = Heapify(toSort, i);
            }
            return toSort;
        }

        private static int[] Heapify(int[] toSort, int pos)
        {
            bool done = false;
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
