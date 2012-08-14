using System;

namespace OWASP.WebGoat.NET.App_Code
{
    public class WeakRandom
    {
        private uint _seed = 7;

        public WeakRandom() {}

        public WeakRandom(uint seed)
        {
            _seed = seed;
        }
        
        public uint Next(uint min, uint max)
        {
            if (min >= max)
                throw new Exception("Min must be smaller than max");
                
            unchecked //Just use next number from overflow
            {
                _seed = _seed * _seed + _seed;
            }
            
            return _seed % (max - min) + min;
        }

        public uint Peek(uint min, uint max)
        {
            if (min >= max)
                throw new Exception("Min must be smaller than max");

            unchecked //Just use next number from overflow
            {
                var seed = _seed * _seed + _seed;

                return seed % (max - min) + min;
            }
        }
    }
}