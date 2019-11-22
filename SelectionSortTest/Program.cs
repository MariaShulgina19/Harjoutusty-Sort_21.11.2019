using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics; // stopwatch


namespace SelectionSortTest
{
    class Program

    {

        public delegate void SortDelegate(int[] num);
        public delegate int[] CreateArrayDelegate(int size);


        static int[] CreateTable(int size) // static int[] CreateRandomArray(int size)
        {
            // luo ensin taulukko, missä alkiot ei ole järjestyksessä
            int[] taulukko = new int[size];
            // täytetään taulukko satunnaisluvuilla
            Random generaattori = new Random();

            for (int i = 0; i < taulukko.Length; i++)
            {
                taulukko[i] = generaattori.Next(size);
            }

          // return new int[size]; //instead of 
           return taulukko;
        }
      
        private static void InsertionSort(int[] arr)
        {
            // https://www.geeksforgeeks.org/insertion-sort/ 
            int i, key, j;

            int n = arr.Length;

            for (i = 1; i < n; i++)
            {
                key = arr[i];
                j = i - 1;

                /* Move elements of arr[0..i-1], that are  
                greater than key, to one position ahead  
                of their current position */
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }


        private static void InsertionSortDES(int[] arr)
        {
            // https://www.geeksforgeeks.org/insertion-sort/ 
            int i, key, j;

            int n = arr.Length;

            for (i = 1; i < n; i++)
            {
                key = arr[i];
                j = i - 1;

                /* Move elements of arr[0..i-1], that are  
                greater than key, to one position ahead  
                of their current position */
                while (j >= 0 && arr[j] < key) // HERE IS Chages
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }
        private static void SelectionSort(int[] num)
        {
            int i, j, first, temp;
            for (i = num.Length - 1; i > 0; i-- )
            {
                first = 0;   //initialize to subscript of first element
                for (j = 1; j <= i; j++)   //locate smallest element between positions 1 and i.
                {
                    if (num[j] > num[first])
                        first = j;
                }
                temp = num[first];   //swap smallest found with element in position i.
                num[first] = num[i];
                num[i] = temp;
            }
        }
                //Lisää vertailuun QuickSort NEW!
                
        private static void QuickSort(int[] a, int lo, int hi)
        {
            //  lo is the lower index, hi is the upper index
            //  of the region of array a that is to be sorted
            int i = lo, j = hi, h;

            // comparison element x
            int x = a[(lo + hi) / 2];

            //  partition
            do
            {
                while (a[i] < x) i++;
                while (a[j] > x) j--;
                if (i <= j)
                {
                    h = a[i];
                    a[i] = a[j];
                    a[j] = h;
                    i++; j--;
                }
            } while (i <= j);

            //  recursion
            if (lo < j) QuickSort(a, lo, j);
            if (i < hi) QuickSort(a, i, hi);
        }
        //from last qiestion иземенения метода, чтобы он был похож на делегата
        static void QuickSortMain(int[] num)
        {
            QuickSort(num, 0, num.Length - 1);
        }


        //4. Vertaa algoritmeja myös siten, että taulukko on nousevassa järjestyksessä ja laskevassa järjestyksessä
        // Tee metodi CreateAscendingTable, joka luo nousevassa järjestyksessä olevan taulukon



        static int[] CreateAscendingTable(int size) //MAIN PROGRAMM ex: CreateAscendingTable(100);
        {
            // luo ensin taulukko, missä alkiot ovat järjestyksessä
            int[] taulukko = new int[size];
            // täytetään taulukko luvuilla 0-taulukko.length
           

            for (int i = 0; i < taulukko.Length; i++)
            {
                taulukko[i] = i;
            }
            //check print 0 till 99
            //foreach (var item in taulukko)
            //{
            //    Console.WriteLine(item);
            //}

            return taulukko;

        }

        //Tee metodi CreateDescendingTable, joka luo laskevassa järjestyksessä olevan taulukon
        static int[] CreateDescendingTable(int size) //MAIN PROGRAMM ex: CreateDescendingTable(100);
        {
            // luo ensin taulukko, missä alkiot ovat järjestyksessä
            int[] taulukko = new int[size];
            // täytetään taulukko luvuilla 0-taulukko.length

            int j = 0; //to start fillig from 0 spot till 99
            for (int i = taulukko.Length-1; i > 0; i--)//from 99 till 0
            {
                
                taulukko[j] = i;
                j++;
            }
            //check print 99 till 0
           // foreach (var item in taulukko)
           // {
           //     Console.WriteLine(item);
           // }

            return taulukko;

        }
        static public void merge(int[] arr, int p, int q, int r)
        {
            int i, j, k;
            int n1 = q - p + 1;
            int n2 = r - q;
            int[] L = new int[n1];
            int[] R = new int[n2];
            for (i = 0; i < n1; i++)
            {
                L[i] = arr[p + i];
            }
            for (j = 0; j < n2; j++)
            {
                R[j] = arr[q + 1 + j];
            }
            i = 0;
            j = 0;
            k = p;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }
        static public void mergeSort(int[] arr, int p, int r)
        {
            if (p < r)
            {
                int q = (p + r) / 2;
                mergeSort(arr, p, q);
                mergeSort(arr, q + 1, r);
                merge(arr, p, q, r);
            }
        }


        static void MergeSortMain(int[] num)// дополниетельный метод привести сортировку к формату делегата
        {
            //Table to LisT                         /extra time to create list
            mergeSort(num, 0, num.Length - 1); //mergeSort(arr, 0, n - 1);

        }

        static void ArraySort(int[] num)// базовая сортивка
        {

            Array.Sort(num);
        }




        static void Metodi(SortDelegate del)
        {
            // luo taulukko (satunnaisluvuilla)
            int[] num = CreateTable(10000);
            //int[] num = new int[100]; //int[] taulukko = CreateTable(10000);
            // ota aika
            Stopwatch kello = Stopwatch.StartNew();
            del(num);
            // laske aikaero
            var elapsedTime = kello.Elapsed;
                     // tulosta
            Console.WriteLine("Sorting time: {0}", elapsedTime.TotalMilliseconds);
            
        }
        //Metod to use Sorted ASC Table

        static void MetodiSortedASC(SortDelegate del)
        {
            // luo taulukko (satunnaisluvuilla)
            int[] num = CreateAscendingTable(10000); //
            //int[] num = new int[100]; //int[] taulukko = CreateTable(10000);
            // ota aika
            Stopwatch kello = Stopwatch.StartNew();
            del(num);
            // laske aikaero
            var elapsedTime = kello.Elapsed;
                     // tulosta
            Console.WriteLine("Sorting time: {0}", elapsedTime.TotalMilliseconds);
            
        }

         //Metod to use Sorted ASC Table

        static void MetodiSortedDES(SortDelegate del)
        {
            // luo taulukko (satunnaisluvuilla)
            int[] num = CreateDescendingTable(10000); //
            //int[] num = new int[100]; //int[] taulukko = CreateTable(10000);
            // ota aika
            Stopwatch kello = Stopwatch.StartNew();
            del(num);
            // laske aikaero
            var elapsedTime = kello.Elapsed;
                     // tulosta
            Console.WriteLine("Sorting time: {0}", elapsedTime.TotalMilliseconds);
            
        }


        //MAIN PROGRAMM
        static void Main(string[] args)
        {
           SortDelegate ds1 = new SortDelegate(InsertionSort); //Sort1
            SortDelegate ds1DES = new SortDelegate(InsertionSortDES);
            SortDelegate ds2 = new SortDelegate(SelectionSort);
            SortDelegate quick = new SortDelegate(QuickSortMain);
            SortDelegate merge = new SortDelegate(MergeSortMain);
            SortDelegate  arraySort = new SortDelegate(ArraySort);

             Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("UNSORTED TABLE");

            // testataan INsertion Sort
              Console.WriteLine("Insertion Sort");
               Metodi(ds1);
               Console.WriteLine();

              // testataan INsertion Sort DES
              Console.WriteLine("Insertion Sort DES");
               Metodi(ds1DES);
               Console.WriteLine();
            
            Console.WriteLine("Selection Sort");
            // testataan Selection Sort
            Metodi(ds2);
            Console.WriteLine();
            
            Console.WriteLine("Quick Sort");
            // testataan Quick Sort 
            Metodi(quick);
            Console.WriteLine();
            Console.WriteLine("Merge Sort");
            // testataan Merge Sort
            Metodi(merge);

            Console.WriteLine();
            Console.WriteLine("Array Sort");
            // testataan Merge Sort
            Metodi(arraySort);


            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("SORTED TABLE ASC");
             // testataan INsertion Sort
              Console.WriteLine("Insertion Sort");
               MetodiSortedASC(ds1);
               Console.WriteLine();

            // testataan INsertion Sort DES
              Console.WriteLine("Insertion Sort DES");
               MetodiSortedASC(ds1DES);
               Console.WriteLine();
            
            Console.WriteLine("Selection Sort");
            // testataan Selection Sort
            MetodiSortedASC(ds2);
            Console.WriteLine();
            
            Console.WriteLine("Quick Sort");
            // testataan Quick Sort 
           MetodiSortedASC(quick);
            Console.WriteLine();
            Console.WriteLine("Merge Sort");
            // testataan Merge Sort
            MetodiSortedASC(merge);

            Console.WriteLine();
            Console.WriteLine("Array Sort");
            // testataan Merge Sort
            MetodiSortedASC(arraySort);

              Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("SORTED TABLE DESC");

                // testataan INsertion Sort
              Console.WriteLine("Insertion Sort");
              MetodiSortedDES(ds1);
               Console.WriteLine();

            // testataan INsertion Sort DES
              Console.WriteLine("Insertion Sort DES");
                MetodiSortedDES(ds1DES);
               Console.WriteLine();
            
            Console.WriteLine("Selection Sort");
            // testataan Selection Sort
             MetodiSortedDES(ds2);
            Console.WriteLine();
            
            Console.WriteLine("Quick Sort");
            // testataan Quick Sort 
            MetodiSortedDES(quick);
            Console.WriteLine();
            Console.WriteLine("Merge Sort");
            // testataan Merge Sort
            MetodiSortedASC(merge);

            Console.WriteLine();
            Console.WriteLine("Array Sort");
            // testataan Merge Sort
             MetodiSortedDES(arraySort);

            Console.WriteLine("-----------------------------------------------------------------");
            /*

            // CreateDescendingTable(100);
            //CreateAscendingTable(100);

            // luodaan taulukko
            int[] taulukko = CreateTable(10000);

            // käynnistä ajastin
            Stopwatch kello = Stopwatch.StartNew();
            SelectionSort(taulukko);
            // ota aika ja tulosta se
            var elapsedTime = kello.Elapsed;
            Console.WriteLine("Selection sort: {0}", elapsedTime);

            // ajanoton voi tehdä myös käyttämällä DateTime.Now.Tickiä 
            // long startTime = DateTime.Now.Ticks;
            // Algoritmi(taulukko);
            // long stopTime = DateTime.Now.Ticks;
            // long time = stopTime-startTime;
            Console.ReadLine();

            //Lisää vertailuun Array.Sort (valmis taulukon järjestäminen)

            int[] taulukko2 = CreateTable(10000);

            // käynnistä ajastin
            Stopwatch kello2 = Stopwatch.StartNew();
            Array.Sort(taulukko2); // Array.Sort (valmis taulukon järjestäminen)

            // ota aika ja tulosta se
            var elapsedTime2 = kello2.Elapsed;
            Console.WriteLine("Array.Sort: {0}", elapsedTime2);

            Console.ReadLine();

            //Lisää vertailuun QuickSort NEW!

            int[] taulukko3 = CreateTable(10000);

            // käynnistä ajastin
            Stopwatch kello3 = Stopwatch.StartNew();
            QuickSort(taulukko3, 0, taulukko3.Length - 1); //TO CHECK size-1 = taulukko3.Length - 1
             // Array.Sort (valmis taulukon ,järjestäminen)

            // ota aika ja tulosta se
            var elapsedTime3 = kello3.Elapsed;
            Console.WriteLine("QuickSort: {0}", elapsedTime3);

            Console.ReadLine();

            //7. Lisää vertailuun MergeSort
            */
            int[] taulukko4 = CreateTable(10);

            
           
            //  QuickSort(taulukko3, 0, taulukko3.Length - 1); //TO CHECK size-1 = taulukko3.Length - 1
            //TAULUKKO TO LisT
          /* List<int> unsorted4 = new List<int>();
            foreach (var item in taulukko4)
            {
                unsorted4.Add(item);
            }

            //Print to check list
            Console.WriteLine("printing list");
            foreach (var item in unsorted4)
            {
                Console.WriteLine(item);
            }       
                // käynnistä ajastin
            Stopwatch kello4 = Stopwatch.StartNew();
            List<int> sorted4 = MergeSort(unsorted4);                                          // Array.Sort (valmis taulukon ,järjestäminen)

            // ota aika ja tulosta se
            var elapsedTime4 = kello4.Elapsed;
            Console.WriteLine("MergeSort: {0}", elapsedTime4);

            foreach (var item in sorted4)
            {
                Console.WriteLine(item);
            }

    */
            Console.ReadLine();



        }
    }
}
