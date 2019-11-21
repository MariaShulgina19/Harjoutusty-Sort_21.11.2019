using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSortTest
{
    class COMMENTS
    {
        /*
         //MergeSort LIST

            
        private static List<int> MergeSort(List<int> unsorted)

        {

            if (unsorted.Count <= 1)

                return unsorted;



            List<int> left = new List<int>();

            List<int> right = new List<int>();



            int middle = unsorted.Count / 2;

            for (int i = 0; i < middle; i++)  //Dividing the unsorted list

            {

                left.Add(unsorted[i]);

            }

            for (int i = middle; i < unsorted.Count; i++)

            {

                right.Add(unsorted[i]);

            }



            left = MergeSort(left);

            right = MergeSort(right);

            return Merge(left, right);

        }



        private static List<int> Merge(List<int> left, List<int> right)

        {

            List<int> result = new List<int>();



            while (left.Count > 0 || right.Count > 0)

            {

                if (left.Count > 0 && right.Count > 0)

                {

                    if (left.First() <= right.First())  //Comparing First two elements to see which is smaller

                    {

                        result.Add(left.First());

                        left.Remove(left.First());      //Rest of the list minus the first element

                    }

                    else

                    {

                        result.Add(right.First());

                        right.Remove(right.First());

                    }

                }

                else if (left.Count > 0)

                {

                    result.Add(left.First());

                    left.Remove(left.First());

                }

                else if (right.Count > 0)

                {

                    result.Add(right.First());



                    right.Remove(right.First());

                }

            }

            return result;

        }
    

        static void MergeSortMain(int[] num)// дополниетельный метод привести сортировку к формату делегата
        {
            //Table to LisT                         /extra time to create list
            List<int> unsorted4 = new List<int>();
            foreach (var item in num)
            {
                unsorted4.Add(item);
            }
            MergeSort(unsorted4);
           // List<int> sorted4 = MergeSort(unsorted4);

           // foreach (var item in sorted4)
           // {
           //     Console.WriteLine(item);
           // }

        }
    */

    }
}
