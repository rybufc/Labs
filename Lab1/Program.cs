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
        private static List<Sort> sortMethods = new List<Sort>();
        private static bool isEnded;
        private static int[] sequence;
        private static int iterations = 1;

        public delegate int[] Sort(int[] toSort);

        static void Main(string[] args)
        {
            sortMethods.Add(Sorting_Methods.BubbleSort);
            sortMethods.Add(Sorting_Methods.ShellSort);

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

                case "test":
                    Test();
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
                    sort(sequence);
                }
                timer.Stop();
                Console.WriteLine(timer.Elapsed);
            }
        }

        static void Help()
        {
            Console.WriteLine("Programm Help");
        }
    }
}
