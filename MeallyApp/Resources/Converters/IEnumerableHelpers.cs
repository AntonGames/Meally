using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;

namespace MeallyApp.Resources.Converters
{
    public static class IEnumerableHelpers
    {
        public static ObservableCollection<T> ConvertToObservableCollection<T>(IEnumerable<T> collection)
        {
            return new ObservableCollection<T>(collection);
        }

        public static IEnumerable<T> Swap<T>(IEnumerable<T> collection, int index1, int index2)
        {
            if (index1 < 0 || index1 >= collection.Count())
            {
                throw new ArgumentOutOfRangeException(nameof(index1));
            }

            if (index2 < 0 || index2 >= collection.Count())
            {
                throw new ArgumentOutOfRangeException(nameof(index2));
            }

            T[] collectionAsAnArray = collection.ToArray();
            T tmp = collectionAsAnArray[index1];
            collectionAsAnArray[index1] = collectionAsAnArray[index2];
            collectionAsAnArray[index2] = tmp;

            return collectionAsAnArray;
        }
    }
}
