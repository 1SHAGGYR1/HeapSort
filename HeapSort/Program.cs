using System;
using System.Collections.Generic;

namespace HeapSort
{
    class Program
    {
        const int n = 10;
        static List<int> heap;
        static int[] result = new int[n];
        static void Main(string[] args)
        {
            int[] test = new int[n];
            for (int i = 0; i < n; i++)
                test[i] = int.Parse(Console.ReadLine());
            CreateHeap(test);
            Sort();
            for (int i = 0; i<result.Length;i++)
                Console.Write(result[i] + " ");
            Console.ReadKey(true);
        }
        static void Sort ()
        {
            int pos = 0;
            while (heap.Count > 0)
            {
                result[pos] = heap[0];
                pos++;
                heap[0] = heap[heap.Count - 1];
                heap.RemoveAt(heap.Count - 1);
                if (heap.Count > 0)
                    SiftDown(0);
            }
        }
        static void CreateHeap(int[] arr)
        {
            heap = new List<int>(arr.Length);
            for (int i = 0; i < arr.Length; i++)
                heap.Add(arr[i]);
            for (int i = arr.Length / 2; i >= 0; i--)
                SiftDown(i);
        }
        private static void Swap(int a, int b)
        {
            int buffer = heap[a];
            heap[a] = heap[b];
            heap[b] = buffer;
        }
        private static void SiftDown(int i)
        {
            while (2*i+1 < heap.Count)
            {
                int left, right, j;
                left = 2 * i + 1;
                right = 2 * i + 2;
                j = left;
                if ((right < heap.Count)&&(heap[right] < heap[left]))
                {
                    j = right;
                }
                if (heap[i] <= heap[j])
                    break;
                else
                {
                    Swap(i, j);
                    i = j;
                }           
            }
        }
    }
}
