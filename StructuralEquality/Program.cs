using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralEquality
{
    //Structural Equality works with Arrays and Tuples. It requires a reference to System.Collections
    //Collections are structurally equal if they have the same elements in the same order.
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = { "apple", "orange", "pineapple" };
            string[] arr2 = { "apple", "orange", "pineapple" };

            Console.WriteLine(arr1 == arr2); //returns false, arrays are reference types
            Console.WriteLine(arr1.Equals(arr2)); //returns false, arrays are reference types

            var arrayEq = (IStructuralEquatable)arr1;
            bool structEqual = arrayEq.Equals(arr2, StringComparer.Ordinal);
            Console.WriteLine(structEqual);

            var arrayComp = (IStructuralComparable)arr1;
            int structComp = arrayComp.CompareTo(arr2, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine(structComp);
            Console.WriteLine();

            arr1 = new string[] { "apple", "orange", "pineapple" };
            arr2 = new string[] { "apple", "orange", "Pineapple" };

            arrayEq = (IStructuralEquatable)arr1;
            structEqual = arrayEq.Equals(arr2, StringComparer.Ordinal);
            Console.WriteLine(structEqual);
            arrayEq = (IStructuralEquatable)arr1;
            structEqual = arrayEq.Equals(arr2, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine(structEqual);

            arrayComp = (IStructuralComparable)arr1;
            structComp = arrayComp.CompareTo(arr2, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine(structComp);
            Console.WriteLine();

        }
    }
}
