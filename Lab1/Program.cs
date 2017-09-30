using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        //private static List<Sort> sortMethods = new List<Sort>();
        private static List<Tuple<Sort, string>> sortMethods = new List<Tuple<Sort, string>>();
        private static bool isEnded;
        private static int[] sequence;
        private static int iterations = 1;

        public delegate int[] Sort(int[] toSort);

        static void Main(string[] args)
        {
            sortMethods.Add(new Tuple<Sort, string>(Sorting_Methods.BubbleSort, "Bubble Sort"));
            sortMethods.Add(new Tuple<Sort, string>(Sorting_Methods.ShellSort, "Shell Sort"));
            sortMethods.Add(new Tuple<Sort, string>(Sorting_Methods.HeapSort, "Heap Sort"));

            while (!isEnded)
            {
                getCommand(Console.ReadLine());
            }
        }

        static void getCommand(string token)
        {
            string command = token.Split()[0];

            switch (command)
            {
                case "help":
                    Help();
                    break;

                case "iterations":
                    iterations = int.Parse(token.Split()[1]);
                    break;

                case "sequence":
                    sequence = GetSequence(GetTokens(token));
                    break;

                case "checksequence":
                    CheckSequence();
                    break;

                case "test":
                    Test();
                    break;

                case "random":
                    if (token.Split().Length == 2)
                    {
                        RandomizeSequence(int.Parse(token.Split()[1]));
                    }
                    else
                    {
                        RandomizeSequence();
                    }
                    break;

                case "exit":
                    isEnded = true;
                    break;

                default:
                    Console.WriteLine("Данной команды нет в списке доступных команд."+
                    " Просьба за доступными командами обратиться в хелп по командам с помощью команды help.");
                    break;
            }
        }

        static void CheckSequence()
        {
            Console.Write('[');
            for (int i = 0; i < sequence.Length; i++)
            {
                Console.Write(sequence[i] + " ");
            }
            Console.Write("]\n");
        }

        static void RandomizeSequence(int length = 1000)
        {
            Random random = new Random();
            sequence = new int[1000];

            for (int i = 0; i < sequence.Length; i++)
            {
                sequence[i] = random.Next();
            }
        }

        static string[] GetTokens(string token)
        {
            string[] parsedToken = token.Split();
            string[] result = new string[parsedToken.Length - 1];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = parsedToken[i + 1];
            }

            return result;
        }

        static int[] GetSequence(string[] tokens)
        {
            int[] newSequence = new int[tokens.Length];
            for (int i = 0; i < newSequence.Length; i++)
            {
                newSequence[i] = int.Parse(tokens[i]);
            }
            return newSequence;
        }

        static void Test()
        {
            Stopwatch timer = new Stopwatch();

            foreach (var sort in sortMethods)
            {
                timer.Restart();
                for (int i = 0; i < iterations; i++)
                {
                    sort.Item1(sequence);
                }
                timer.Stop();
                Console.WriteLine(sort.Item2 + " : " + timer.Elapsed);
            }
        }

        static void Help()
        {
            Console.WriteLine("Programm Help");
        }
    }
}
