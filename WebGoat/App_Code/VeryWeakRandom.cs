using System;

namespace OWASP.WebGoat.NET.App_Code
{
    public class VeryWeakRandom
    {
        private uint _seed = 7;
        private uint _helper = 1;

        public VeryWeakRandom() {}

        public VeryWeakRandom(uint seed)
        {
            _seed = seed;
        }

        public uint Next(uint min, uint max)
        {
            _seed = Peek(min, max);
            _helper++;

            return _seed;
        }

        public uint Peek(uint min, uint max)
        {
            if (min >= max)
                throw new Exception("Min must be smaller than max");

            var seed = _seed + _helper;

            if (seed > max)
                seed = min;

            return seed;
        }
    }
}
