
using System;

namespace Database
{
    public class Database
    {
        private int[] integerRepo;

        public Database(params int[] ints)
        {
            this.IntegerRepo = new int[16];
            PutIntsInRepo(ints);
            this.NextFreeIndex = ints.Length;
        }

        private void PutIntsInRepo(int[] ints)
        {
            if (ints.Length > 16)
            {
                throw new InvalidOperationException("Database cannot store more than 16 integers!");
            }

            for (int i = 0; i < ints.Length; i++)
            {
                this.IntegerRepo[i] = ints[i];
            }
        }

        public int[] IntegerRepo
        {
            get { return this.integerRepo; }
            private set
            {
                this.integerRepo = value;
            }
        }

        public int NextFreeIndex { get; private set; } = -1;

        public void Add(int newElement)
        {
            if (this.NextFreeIndex == 16)
            {
                throw new InvalidOperationException("Database cannot store more than 16 integers!");
            }
            this.IntegerRepo[this.NextFreeIndex] = newElement;
            this.NextFreeIndex++;
        }

        public void Remove()
        {
            if (this.NextFreeIndex == 0)
            {
                throw new InvalidOperationException("Database is empty, cannot remove element!");
            }

            this.IntegerRepo[this.NextFreeIndex - 1] = 0;
            this.NextFreeIndex--;
        }

        public int[] Fetch()
        {
            int[] fetchedArray = new int[this.NextFreeIndex];

            for (int i = 0; i < this.NextFreeIndex; i++)
            {
                fetchedArray[i] = this.IntegerRepo[i];
            }

            return fetchedArray;
        }
    }
}
