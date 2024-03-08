using System;
using System.Text;

namespace BinaryHeapReCod
{
    internal class BinaryHeap
    {
        public int Size { get; private set; }
        public int Count { get; private set; }
        public int[] Arr;
        public BinaryHeap(int Size)
        {
            this.Size = Size;
            Arr = new int[Size];
        }
        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }
        private int GetChildLeft(int index)
        {
            return 2 * index + 1;
        }
        private int GetChildRight(int index)
        {
            return 2 * index + 2;
        }
        internal void Push(int v)
        {
            Count++;
            Arr[Count - 1] = v;
            BinaryHeapOrderUp(Count - 1);
        }

        private void BinaryHeapOrderUp(int index)
        {
            while (index > 0)
            {
                var parentIndex = GetParentIndex(index);
                if (Arr[parentIndex] > Arr[index])
                {
                    Swap(parentIndex, index);
                    index = parentIndex;
                }
                else
                {
                    break;
                }
            }
        }

        private void Swap(int parentIndex, int index)
        {
            int temp = Arr[parentIndex];
            Arr[parentIndex] = Arr[index];
            Arr[index] = temp;
        }

        internal int Pop()
        {
            int result = Arr[0];
            Arr[0] = Arr[Count - 1];
            Count--;
            BinaryHeapOrderDown();
            return result;
        }
        private void BinaryHeapOrderDown()
        {
            int index = 0;

            while (true)
            {
                var ChildLeftIndex = GetChildLeft(index);
                var ChildRightIndex = GetChildRight(index);
                var ExistChildLeft = ChildLeftIndex < Count;
                var ExistChildRight = ChildRightIndex < Count;

                if (!ExistChildLeft && !ExistChildRight)
                {
                    // No child then exists
                    break;
                }

                int smallerChildIndex = ChildLeftIndex;
                if (ExistChildRight && Arr[ChildRightIndex] < Arr[ChildLeftIndex])
                {
                    smallerChildIndex = ChildRightIndex;
                }

                if (Arr[index] > Arr[smallerChildIndex])
                {
                    Swap(index, smallerChildIndex);
                    index = smallerChildIndex;
                }
                else
                {
                    break;
                }
            }
        }
        public void Print()
        {
            //2^0 + 2^1 + 2^2 ...
            //2 ^ n 
            //1(2^n -1)
            var sb = new StringBuilder();
            int lv = 1;
            for (int i = 0; i < Count; i++)
            {
                var lvMaxCount = (int)Math.Pow(2, lv) - 1;
                if (i+1 > lvMaxCount)
                {
                    lv++;
                    sb.AppendLine("");
                }
                sb.Append(Arr[i] + ",");
            }
            sb.AppendLine();
            sb.AppendLine(new string('*', 10));
            Console.WriteLine(sb);
        }
    }
}