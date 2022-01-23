using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{

    class Solution
    {

        // Complete the minimumSwaps function below.
        static int minimumSwaps(int[] arr)
        {
            int n = arr.Length;
            
            List<Tuple<int, int>> lst = new List<Tuple<int, int>>();

            for (int i = 0; i < n; i++)
            {
                lst.Add(new Tuple<int, int>(arr[i], i));
            }

            // Sort the lst w.r.t the first element of pair

            lst.Sort();

            int ans = 0;

            for (int i = 0; i < n; i++)
            {

                // If the element is already placed correct, then continue
                if (lst[i].Item2 == i)
                    continue;
                else
                {
                    // Swap with its respective index 
                    // move the current element into its correct position
                    Tuple<int, int> temp = lst[lst[i].Item2];
                    lst[lst[i].Item2] = lst[i];
                    lst[i] = temp;
                }

                // Swap until the correct index matches

                if (i != lst[i].Item2)
                    --i;

                ans++;
            }
            return ans;
        }


        static void Main(string[] args)
        {
            //Input shoudl be like continuous integer from 1 to n randomly
            //Eg input1 - 1 3 2
            //Eg input2 - 2 1 3 4
            //Eg input5 - 5 2 3 1 4
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));

            int res = minimumSwaps(arr);

            Console.WriteLine(res);
        }
    }

}
