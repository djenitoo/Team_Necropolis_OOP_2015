namespace TaskManager.Common.Exception
{
    using System;

    public class InvalidRangeException<T> : ApplicationException
    {
        private T startRange;
        private T endRange;


        public InvalidRangeException(T startRange, T endRange, string message)
            : base(message)
        {
            this.startRange = startRange;
            this.endRange = endRange;
        }

        public T StartRange
        {
            get { return this.startRange; }
            private set { this.startRange = value; }
        }

        public T EndRange
        {
            get { return this.endRange; }
            private set { this.endRange = value; }
        }

    }
}
