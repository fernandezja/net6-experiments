using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008_collections
{
    public static class CollectionHelper
    {
        public static void AddToCollection<T, U>(U item, 
                                                 U key,
                                                 Dictionary<U, T> dictionary)
            where T : ICollection<U>, new()
        {
            if (!dictionary.ContainsKey(key)) {
                dictionary[key] = new T();
            }

            dictionary[key].Add(item);
        }

    }
}
