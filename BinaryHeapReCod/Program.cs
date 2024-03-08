using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeapReCod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var A = new List<int>()
            {
                6214, 8543, 9266 ,1150 ,
                7498, 7209, 9398, 1529,
                1032, 7384, 6784, 34,
                1449, 7598, 8795, 756,
                7803, 4112, 298, 4967,
                1261, 1724, 4272, 1100,
                9373
            };
            var result = cookies(3581, A);
            //BinaryHeap binaryHeap = new BinaryHeap(100);
            //binaryHeap.Push(1123);                  binaryHeap.Print();
            //binaryHeap.Push(4);                     binaryHeap.Print();
            //binaryHeap.Push(1);                     binaryHeap.Print();
            //binaryHeap.Push(6);                     binaryHeap.Print();
            //binaryHeap.Push(7);                     binaryHeap.Print();
            //binaryHeap.Push(9);                     binaryHeap.Print();
            //binaryHeap.Push(12);                    binaryHeap.Print();
            //binaryHeap.Push(16);                    binaryHeap.Print();
            //Console.WriteLine(binaryHeap.Pop());    binaryHeap.Print();
            //Console.WriteLine(binaryHeap.Pop());    binaryHeap.Print();
            //Console.WriteLine(binaryHeap.Pop());    binaryHeap.Print();
            //Console.WriteLine(binaryHeap.Pop());    binaryHeap.Print();
            //Console.WriteLine(binaryHeap.Pop());    binaryHeap.Print();
        }
        public static int cookies(int k, List<int> A)
        {
            BinaryHeap binaryHeap = new BinaryHeap(A.Count);
            for (int i = 0; i < A.Count; i++)
            {
                binaryHeap.Push(A[i]);
            }
            binaryHeap.Print();
            int WhileCount = 0;
            int min0, min1;
            while (true)
            {
                min0 = binaryHeap.Pop();
                if (min0 < k && binaryHeap.Count > 0)
                {
                    WhileCount++;
                    min1 = binaryHeap.Pop();
                    var sweetness = min0 + 2 * min1;
                    binaryHeap.Push(sweetness);
                }
                else
                {
                    break;
                }

            }
            if (min0 < k)
            {
                return -1;
            }
            binaryHeap.Print();
            return WhileCount;
        }
    }
}
