using System;

namespace Snark.Implementation
{
    public static class Extensions
    {
        public static T As<T>(this object o)
            where T : class
        {
            var obj = o as T;

            if (o == null)
            {
                throw new ArgumentException($"Unable to case object of type {o.GetType()} to {typeof(T)}");
            }

            return obj;
        }
    }
}
