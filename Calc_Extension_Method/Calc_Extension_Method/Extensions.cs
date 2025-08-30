using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Calc_Extension_Method
{
     public static class Extensions
    {
        public static T Sum<T>(this IEnumerable<T> items) where T : INumber<T> 
        {
            T total = T.Zero;
            foreach (var item in items) 
            {
                total += item;
            }
            return total;
        }

        public static T Subtract<T>(this IEnumerable<T> items) where T : INumber<T>
        {
            T total = T.Zero;
            foreach (var item in items)
            {
                total = item - total;
            }
            
            return total;
        }

        public static T Multiplicate<T>(this IEnumerable<T> items) where T : INumber<T>
        {
            T total = T.One;
            foreach (var item in items)
            {
                total *= item;
            }
            return total;
        }

        public static T Division<T>(this IEnumerable<T> items) where T : INumber<T>
        {
            T total = T.One;
            foreach (var item in items)
            {
                total = item / total;
            }
            return total;
        }

        public static T Modulo<T>(this IEnumerable<T> items) where T : INumber<T>
        {
            T total = T.One;
            foreach (var item in items)
            {
                total %= item ;
            }
            return total;
        }
    }

}
