using System;
using System.Collections.Generic;
using System.Linq;

namespace DiceCup
{
    class Program
    {
        static void Main(string[] args)
        {
            // DiceCup
            // https://open.kattis.com/problems/dicecup
            // list of items (ints), returns the max repeated items
            // example: {9, 6, 5, 9, 4, 9, 4, 3, 4} --> {9, 4}


            var parameters = Enter2Num();

            var n = parameters[1];
            var m = parameters[0];

            var sums = AllSums(n, m);
            // PrintList(sums);

            var sumsRemovedRepeatedItems = RemoveRepeatedItems(sums);

            var allRepeats = new List<int>();
            for (int i = 0; i < sumsRemovedRepeatedItems.Count; i++)
            {
                allRepeats.Add(EventRepeat(sums, sumsRemovedRepeatedItems[i]));
            }

            var finalResult = MaxRepeatedItems(sumsRemovedRepeatedItems, allRepeats);
            
            PrintList(finalResult);
        }

        private static List<int> MaxRepeatedItems(List<int> items, List<int> repeats)
        {
            // returns max repeated items
            int pivot = MaxItemInList(repeats); // <-- max repeats
            var result = new List<int>();

            if (items.Count != repeats.Count)
                return result;
            else
            {

                for (int i = 0; i < repeats.Count; i++)
                {
                    if (repeats[i] == pivot)
                        result.Add(items[i]);
                }
                return result;
            }
        }

        private static int MaxItemInList(List<int> list)
        {
            int a = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                a = Math.Max(a, list[i]);
            }
            return a;
        }

        private static int EventRepeat(List<int> list, int myEvent)
        {
            int repeat = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == myEvent)
                    repeat = repeat + 1;
            }
            return repeat;
        }

        private static List<int> RemoveRepeatedItems(List<int> list)
        {
            var nlst = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (ItemInListExists(nlst, list[i]) == false)
                    nlst.Add(list[i]);
            }
            return nlst;
        }

        private static bool ItemInListExists(List<int> list, int item)
        {
            for (int i = 0 ; i < list.Count; i++)
            {
                if (list[i] == item)
                    return true;
            }
            return false;
        }

        private static void PrintList(List<int> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        

        private static List<int> AllSums(int n, int m)
        {
            var answers = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    answers.Add(i + j);
                }
            }
            return answers;
        }

        private static int[] Enter2Num()
        {
            //  20 >= (M, N) >= 4
            string[] arr = new string[2] { "", "" };
            int[] res = new int[2] { 0, 0 };
            try
            {
                arr = Console.ReadLine().Split(' ', 2);
                for (int i = 0; i < arr.Length; i++)
                {
                    res[i] = int.Parse(arr[i]);
                    if (res[i] < 4 || res[i] > 20)
                        throw new ArgumentException();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Enter2Num();
            }
            return res;
        }
    }
}
