using System;

namespace ConsoleApp1
{
    public sealed class Option<T>
    {
        private readonly T _value;
        public static Option<T> Empty => new Option<T>();

        public bool HasValue { get; }

        public T Value
        {
            get
            {
                if (!HasValue)
                {
                    throw new InvalidOperationException("Option does not have a value");
                }
                return _value;
            }
        }
        public Option(T value)
        {
            HasValue = true;
            _value = value;
        }
        private Option()
        {
            HasValue = false;
            _value = default(T);
        }
    }

    public sealed class Option
    {
        public static Option<T> Create<T>(T value)
        {
            return new Option<T>(value);
        }
    }
}
