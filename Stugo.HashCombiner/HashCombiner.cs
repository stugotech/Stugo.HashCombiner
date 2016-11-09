using System.Collections.Generic;
using System.Linq;

namespace Stugo
{
    public static class HashCombiner
    {
        // these values nabbed from http://stackoverflow.com/a/34006336
        public const int DefaultSeed = 1009;
        public const int DefaultFactor = 9176;


        public static int CombineHash(params object[] objects)
        {
            return CombineHash(DefaultSeed, DefaultFactor, objects);
        }


        public static int CombineHash(IEnumerable<object> objects)
        {
            return CombineHash(DefaultSeed, DefaultFactor, objects);
        }


        public static int CombineHash(params int[] hashes)
        {
            return CombineHash(DefaultSeed, DefaultFactor, hashes);
        }


        public static int CombineHash(IEnumerable<int> hashes)
        {
            return CombineHash(DefaultSeed, DefaultFactor, hashes);
        }


        public static int CombineHash(int seed, int factor, params object[] objects)
        {
            return CombineHash(seed, factor, (IEnumerable<object>)objects);
        }


        public static int CombineHash(int seed, int factor, IEnumerable<object> objects)
        {
            return CombineHash(seed, factor, objects.Select(x => x.GetHashCode()));
        }


        public static int CombineHash(int seed, int factor, params int[] hashes)
        {
            return CombineHash(seed, factor, (IEnumerable<int>)hashes);
        }


        public static int CombineHash(int seed, int factor, IEnumerable<int> hashes)
        {
            unchecked
            {
                var hash = seed;

                foreach (var i in hashes)
                {
                    hash = hash * factor + i;
                }

                return hash;
            }
        }
    }
}
