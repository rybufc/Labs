using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public static class Sorting_Methods
    {
        //Пузырёк
        public static int[] BubbleSort(int[] toSort)
        {
            bool isSorted = false;
            while (!isSorted)
            {
                isSorted = true;
                for (int i = 0; i < toSort.Length - 1; i++)
                {
                    if (toSort[i] > toSort[i + 1])
                    {
                        int temp = toSort[i];
                        toSort[i] = toSort[i + 1];
                        toSort[i + 1] = temp;

                        isSorted = false;
                    }
                }
            }

            return toSort;
        }

        //Сортировка Шелла
        public static int[] ShellSort(int[] toSort)
        {
            for (int step = toSort.Length; step > 0; step /= 2)
            {
                for (int i = 0; i < step; i++)
                {
                    toSort = insertSort(toSort, step, i);
                }
            }

            return toSort;
        }

        //сортировка вставкой
        private static int[] insertSort(int[] toSort, int step, int i)
        {
            for (; i + step < toSort.Length; i += step)
            {
                if (toSort[i + step] < toSort[i])
                {
                    int temp = toSort[i];
                    toSort[i] = toSort[i + 1];
                    toSort[i + 1] = temp;

                    for (int j = i; j - step >= 0 && toSort[j] < toSort[j - step]; j -= step)
                    {
                        temp = toSort[i];
                        toSort[i] = toSort[i + 1];
                        toSort[i + 1] = temp;
                    }
                }
            }

            return toSort;
        }
    }
}
